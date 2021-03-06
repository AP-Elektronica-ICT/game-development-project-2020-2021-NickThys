﻿using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Text;

namespace Guardians_of_the_galaxy.Components
{
    public class Header : IComponent
    {
        #region Fields
        private Texture2D _headerTexture;
        #endregion
        #region Properties
        public Vector2 Position { get; set; }
        public Rectangle Rectangle
        {
            get
            {
                return new Rectangle((int)Position.X, (int)Position.Y, _headerTexture.Width, _headerTexture.Height);
            }
        }
        #endregion
        #region Constructor
        public Header(Texture2D headerTexture)
        {
            _headerTexture = headerTexture;
        }
        #endregion    
        #region Methodes
        public  void Draw(GameTime _gameTime)
        {
            Globals.SpriteBatch.Draw(_headerTexture, Rectangle, Color.White);
        }
        #endregion

    }
}
