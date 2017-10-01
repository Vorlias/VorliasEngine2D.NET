﻿using SFML.Graphics;
using SFML.System;
using SFML.Window;
using Andromeda2D.Entities.Components.Internal;
using Andromeda2D.System;
using Andromeda2D.Linq;
using System;
using Andromeda2D.System.Utility;

namespace Andromeda2D.Entities.Components.UI
{

    /// <summary>
    /// Abstract UI class for interactive elements, like buttons etc.
    /// </summary>
    public abstract class UIInteractable : UIComponent, IInteractableInterfaceComponent
    {
        public event InterfaceEvent OnMouseEnter, OnMouseLeave;

        public virtual bool PreventsFallthrough => true;

        bool _isFallThrough = false;
        public bool IsPreventingFallthrough
        {
            get => _isFallThrough;
        }

        /// <summary>
        /// The UserInterface this transform is attached to
        /// </summary>
        public UserInterface UserInterface
        {
            get
            {
                entity.Ancestors.FirstComponent(out UserInterface ui);
                return ui;
            }
        }

        public override abstract string Name
        {
            get;
        }

        private bool mouseDown = false;

        /// <summary>
        /// Whether or not the mouse is down
        /// </summary>
        public bool IsMouseDown
        {
            get
            {
                return mouseDown;
            }
        }

        /// <summary>
        /// Used to determine collision between button and mouse (For hover detection)
        /// </summary>
        [Obsolete]
        public PolygonRectCollider ButtonCollider
        {
            get
            {
                return Entity.GetComponent<PolygonRectCollider>();
            }
        }

        public abstract override void OnComponentCopy(Entity source, Entity copy);

        public abstract void OnButtonInit(Entity entity);

        public override void OnComponentInit(Entity entity)
        {
            var rectCollider = Entity.AddComponent<PolygonRectCollider>();
            rectCollider.CreateRectCollider(new Vector2f(100, 20));

            OnButtonInit(entity);
        }

        public abstract override void Draw(RenderTarget target, RenderStates states);

        private void HandleMouseButtonClick(MouseInputAction inputAction, bool inside)
        {
            MouseButtonClicked(inputAction, inside);
        }

        public abstract void MouseButtonClicked(MouseInputAction inputAction, bool inside);

        public virtual void MouseButtonReleased(MouseInputAction inputAction)
        {

        }

        protected Vector2f MouseRelativePosition
        {
            get
            {
                Vector2i globalMousePosition = StateApplication.Application.MousePosition;

                return globalMousePosition.ToFloat() - Transform.GlobalPosition.GlobalAbsolute;
            }
        }

        public void InputRecieved(UserInputAction inputAction)
        {
            var mouseAction = inputAction.Mouse;
            if (mouseAction?.InputState == InputState.Active && mouseAction?.Button == Mouse.Button.Left && Visible)
            {
                // if left click
                if (IsMouseOver && !IsMouseDown)
                {
                    mouseDown = true;
                    HandleMouseButtonClick(mouseAction, true);
                }
                else if (!IsMouseDown)
                {
                    HandleMouseButtonClick(mouseAction, false);
                }
            }
            else if (mouseAction?.InputState == InputState.Inactive && mouseAction.Button == Mouse.Button.Left)
            {
                if (mouseDown)
                    MouseButtonReleased(mouseAction);

                mouseDown = false;
                
            }
        }

        bool hoverState = false;
        public override void Update()
        {
            if (IsMouseOver && !hoverState && Visible)
            {
                hoverState = true;
                OnMouseEnter?.Invoke(new UserInterfaceAction(UIActionType.MouseEnter, this));
            }
            else if (!IsMouseOver && hoverState && Visible)
            {
                hoverState = false;
                OnMouseLeave?.Invoke(new UserInterfaceAction(UIActionType.MouseLeave, this));
            }
        }
    }
}
