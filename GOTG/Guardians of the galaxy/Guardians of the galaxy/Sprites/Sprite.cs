using Guardians_of_the_galaxy.Input;
using Guardians_of_the_galaxy.Interfaces;
using Guardians_of_the_galaxy.Collision;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Text;

namespace Guardians_of_the_galaxy.Sprites
{
   public class sprite:IGameObject,ICollision
    {
        #region Fields
        private CollisionManager _collisionManager;
        protected Texture2D _texture;
        public Vector2 Position;
        public Vector2 Velocity;
        public float speed;
        public input Input;
        #endregion

        #region Properties
        public Rectangle CollisionRectangle {
            get
            {
                return new Rectangle((int)Position.X, (int)Position.Y, _texture.Width, _texture.Height);
            }
           
        }
        public CollisionManager CollisionManager
        {
            get { return _collisionManager; }
        }
        #endregion

        #region Constructor
        public sprite(Texture2D texture)
        {
            _texture = texture;
            _collisionManager = new CollisionManager(this, Globals.Offset);
        }
        #endregion

        #region Methodes
        public virtual void Update(GameTime gameTime, List<sprite> sprites)
        {
        }

        public virtual void Draw()
        {
            Globals.SpriteBatch.Draw(_texture, Position, Color.White);
        }
        #endregion
    }
}
