using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Text;

namespace Guardians_of_the_galaxy.Components
{
    public class Header : Component
    {
        #region Fields
        private Texture2D _headerTexture;
        #endregion

        #region Constructor
        public Header(Texture2D headerTexture)
        {
            _headerTexture = headerTexture;
        }
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

        #region Methodes
        public override void Draw(GameTime _gameTime, SpriteBatch _spriteBatch)
        {
            _spriteBatch.Draw(_headerTexture, Rectangle, Color.White);
        }

        public override void Update(GameTime _gameTime)
        {
        }
        #endregion

    }
}
