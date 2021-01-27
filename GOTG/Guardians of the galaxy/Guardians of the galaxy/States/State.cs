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
        protected Game1 _game;
        #endregion

        #region Methods
        public abstract void Draw(GameTime _gameTime);
        
        protected State( Game1 _game)
        {
            this._game = _game;
        }
        public abstract void Update(GameTime _gameTime);
        #endregion
    }
}
