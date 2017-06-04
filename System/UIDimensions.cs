﻿using SFML.Graphics;
using SFML.System;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VorliasEngine2D.System.Utility;

namespace VorliasEngine2D.System
{
    public class UIAxis
    {
        public float Scale
        {
            get;
            set;
        }

        public float Offset
        {
            get;
            set;
        }

        internal UIAxis(float scale, float offset)
        {
            Scale = scale;
            Offset = offset;
        }
    }

    /// <summary>
    /// A vector that represents a UI coordinate
    /// (scale, offset) for (x, y)
    /// </summary>
    public class UICoordinates // TODO: Think of better name
    {
        UIAxis x;
        UIAxis y;

        public UIAxis X
        {
            get
            {
                return x;
            }
        }

        public UIAxis Y
        {
            get
            {
                return y;
            }
        }

        public UICoordinates(float scaleX, float offsetX, float scaleY, float offsetY)
        {
            x = new UIAxis(scaleX, offsetX);
            y = new UIAxis(scaleY, offsetY);
        }

        /// <summary>
        /// Returns the absolute Vector2 based on the RenderTarget size
        /// </summary>
        /// <param name="window"></param>
        /// <returns></returns>
        internal Vector2f Absolute(RenderTarget window)
        {
            Vector2f windowSize = window.Size.ToFloatVector();
            return new Vector2f(windowSize.X * x.Scale + x.Offset, windowSize.Y * y.Scale + y.Offset);
        }
    }
}
