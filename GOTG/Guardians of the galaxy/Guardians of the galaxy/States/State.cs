using Guardians_of_the_galaxy.Components;
using Guardians_of_the_galaxy.Interfaces;
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
        private List<IComponent> _components;

        public List<IComponent> Components { get => _components; set => _components = value; }

        #endregion

        #region Methods
        public virtual void Draw(GameTime _gameTime)
        {
            Globals.SpriteBatch.Begin();

            foreach (var component in _components)
                component.Draw(_gameTime);
            Globals.SpriteBatch.End();

        }

        protected State( Game1 _game)
        {
            this._game = _game;
        }
        public virtual void Update(GameTime _gameTime) {
            foreach (var component in _components)
                component.Update(_gameTime);
        }
        #endregion
    }
}
