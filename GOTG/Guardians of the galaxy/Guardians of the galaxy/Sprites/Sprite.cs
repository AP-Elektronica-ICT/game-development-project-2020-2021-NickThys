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
        private int offset ;
        protected Texture2D _texture;
        public Vector2 Position;
        public Vector2 Velocity;
        public float speed;
        public input Input;
        #endregion

        #region Properties
        public Rectangle Rectangle
        {
            get
            {
                return new Rectangle((int)Position.X,(int) Position.Y, _texture.Width, _texture.Height);
            }
            set { 
            }
        }

        public Rectangle CollisionRectangle { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        #endregion

        #region Constructor
        public sprite(Texture2D texture)
        {
            offset = 15;
            _texture = texture;
            _collisionManager = new CollisionManager(this, offset);
        }
        #endregion

        #region Methodes
        public virtual void update(GameTime gameTime)
        {
        }

        public virtual void draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(_texture, Position, Color.White);
        }
        #endregion
    }
}
