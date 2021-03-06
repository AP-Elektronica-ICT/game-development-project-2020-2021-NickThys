﻿using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System;
using System.Collections.Generic;
using System.Text;

namespace Guardians_of_the_galaxy.Components
{
   public abstract class button : IComponent
    {
        #region Fields
        private MouseState _currentMouse,_previousMouse;
        private bool _isHovering;
        #endregion
      
        #region Properties
        public event EventHandler Click;
        public bool Clicked { get; private set; }
        public Vector2 Position { get; set; }
        public Texture2D Texture { get; set; }
        public Rectangle Rectangle {
            get
            {
             return new Rectangle((int)Position.X,(int) Position.Y, Texture.Width, Texture.Height);
            }
        }
        #endregion

        #region Methods
        public virtual void Draw(GameTime _gameTime)
        {
            var colour = Color.White;
            if (_isHovering)
                colour = Color.Gray;
            Globals.SpriteBatch.Draw(Texture, Rectangle, colour);
          
        }

        public virtual void Update(GameTime _gameTime)
        {
            _previousMouse = _currentMouse;
            _currentMouse = Mouse.GetState();
            var mouseRectangle = new Rectangle(_currentMouse.X, _currentMouse.Y, 1, 1);
            _isHovering = false;
            if (mouseRectangle.Intersects(new Rectangle((int)Position.X, (int)Position.Y, Texture.Width, Texture.Height)))
            {
                _isHovering = true;
                if (_currentMouse.LeftButton == ButtonState.Released && _previousMouse.LeftButton == ButtonState.Pressed)
                {
                    Click?.Invoke(this, new EventArgs());
                }
            }
        }
        #endregion

    }
}
