using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Text;

namespace Guardians_of_the_galaxy

{
    public class Camera
    {
        #region Fields
        private float Rotation;
        private float Zoom;
     
        #endregion

        #region Constructors
        public Camera()
        {
            Rotation = 0;
            Zoom = 1;
        }
        public Camera(float rotation,float zoom)
        {
            Rotation = rotation;
            Zoom = zoom;
        }
        #endregion

        #region Methods
        public Matrix GetViewMatrix(Vector2 position)
        {
            Matrix m =
                Matrix.CreateTranslation(new Vector3(-position, 0)) *
                Matrix.CreateRotationZ(Rotation) *
                Matrix.CreateScale(Zoom, Zoom, 1);

            return m;
        }
        #endregion  

    }
}
