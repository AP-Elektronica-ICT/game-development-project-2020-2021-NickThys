using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Text;

namespace Guardians_of_the_galaxy.States
{
   public abstract class State
    {
        #region Fields
        protected ContentManager _content;
        protected GraphicsDevice _graphicsDevice;
        protected Game1 _game;
        #endregion

        #region Methods
        public abstract void Draw(GameTime _gameTime, SpriteBatch _spriteBatch);
        public abstract void PostUpdate(GameTime _gameTime);
        
        protected State(ContentManager _content, GraphicsDevice _graphicsDevice, Game1 _game)
        {
            this._content = _content;
            this._graphicsDevice = _graphicsDevice;
            this._game = _game;
        }
        public abstract void Update(GameTime _gameTime);
        #endregion
    }
}
