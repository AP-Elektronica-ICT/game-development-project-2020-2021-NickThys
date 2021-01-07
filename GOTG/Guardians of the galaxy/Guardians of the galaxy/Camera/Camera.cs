using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Text;

namespace Guardians_of_the_galaxy

{
    public class Camera
    {
        #region Variables
        private float Rotation { get; set; }
        private float Zoom { get; set; }
        private Vector2 Origin { get; set; }
        private Vector2 ViewportCenter
        {
            get
            {
                return new Vector2(ScreenViewport.Width * 0.5f, ScreenViewport.Height * 0.5f);
            }
        }

        private readonly Viewport ScreenViewport;
        #endregion

        #region Constructors
        public Camera(Viewport viewport)
        {
            ScreenViewport = viewport;
            Rotation = 0;
            Zoom = 1;
            Origin = new Vector2(viewport.Width / 2f, viewport.Height / 2f);
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
