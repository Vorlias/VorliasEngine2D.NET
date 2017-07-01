﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VorliasEngine2D.Entities.Components;
using VorliasEngine2D.System;

namespace VorliasEngine2D.Entities.Components.UI
{
    public static class UIExtension
    {
        public static UIImageButton AddImageButton(this Entity parent, string textureId, UICoordinates position = default(UICoordinates), UICoordinates size = default(UICoordinates))
        {
            Entity entity = parent.SpawnEntity();
            UIImageButton uiImage = entity.AddComponent<UIImageButton>();
            uiImage.TextureId = textureId;
            UITransform transform = entity.GetComponent<UITransform>();
            transform.Position = position;
            transform.Size = size;

            return uiImage;
        }

        public static UIImage AddImage(this Entity parent, string textureId, UICoordinates position = default(UICoordinates), UICoordinates size = default(UICoordinates))
        {
            Entity entity = parent.SpawnEntity();
            UIImage uiImage = entity.AddComponent<UIImage>();
            uiImage.TextureId = textureId;
            UITransform transform = entity.GetComponent<UITransform>();
            transform.Position = position;
            transform.Size = size;

            return uiImage;
        }

        public static UIText AddText(this Entity parent, string text, uint fontSize, UICoordinates position = default(UICoordinates))
        {
            Entity entity = parent.SpawnEntity();
            UIText uiText = entity.AddComponent<UIText>();
            uiText.Text = text;
            uiText.FontSize = fontSize;
            entity.GetComponent<UITransform>().Position = position;
            return uiText;
        }
    }
}
