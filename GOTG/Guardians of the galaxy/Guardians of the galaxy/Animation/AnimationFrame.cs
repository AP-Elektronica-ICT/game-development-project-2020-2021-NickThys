using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;



namespace Guardians_of_the_galaxy.Animation
{
    public class AnimationFrame
    {
        public Rectangle SourceRectangle { get; set; }

        public AnimationFrame(Rectangle rectangle)
        {
            SourceRectangle = rectangle;
        }

    }
}
