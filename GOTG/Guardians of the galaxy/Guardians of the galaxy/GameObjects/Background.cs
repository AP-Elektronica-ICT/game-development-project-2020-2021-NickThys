using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Text;

namespace Guardians_of_the_galaxy.GameObjects
{
    class Background
    {
        #region Variables
        private Texture2D _sprite;
        private Vector2 _dimension,_position;
        #endregion
        #region Constructor
        public Background(string _path)
        {
            _sprite = Globals.ContentLoader.Load<Texture2D>(_path);
            _dimension = new Vector2(Globals.WindowWidth, Globals.WindowHeight);
            _position = Vector2.Zero;
        }
        #endregion
        #region Functions
        public virtual void Draw()
        {
            Globals.SpriteBatch.Draw(_sprite, new Rectangle((int)_position.X, (int)_position.Y, (int)_dimension.X, (int)_dimension.Y), Color.White);
        }
        #endregion
    }
}
