using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;



namespace Guardians_of_the_galaxy.Animation
{
    public class AnimationFrame
    {
        #region Properties
        public Rectangle SourceRectangle { get; set; }
        #endregion
  
        #region Constructor
        public AnimationFrame(Rectangle rectangle)
        {
            SourceRectangle = rectangle;
        }
        #endregion 
    }
}
