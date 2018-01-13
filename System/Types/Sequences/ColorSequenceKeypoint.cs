﻿using System;
using SFML.Graphics;

namespace Andromeda2D.System.SequenceTypes
{
    public struct ColorSequenceKeypoint : ISequenceKeyframe<Color>
    {
        public Color Value
        {
            get;
        }

        public float Time
        {
            get;
        }

        public ColorSequenceKeypoint(float time, Color color)
        {
            if (time > 1.0f || time < 0.0f)
            {
                throw new KeypointTimeException(time);
            }

            Time = time;
            Value = color;
        }
    }
}