using Guardians_of_the_galaxy.Input;
using Guardians_of_the_galaxy.Interfaces;
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
        private int offset =15;
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
        #endregion
 
        #region Constructor
        public sprite(Texture2D texture)
        {
            _texture = texture;
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
        #region collision
        protected bool IsTouchingLeft(sprite sprite)
        {
            return this.Rectangle.Right + this.Velocity.X > sprite.Rectangle.Left+ offset &&
                this.Rectangle.Left < sprite.Rectangle.Left &&
                this.Rectangle.Bottom > sprite.Rectangle.Top &&
                this.Rectangle.Top < sprite.Rectangle.Bottom;
        }
        protected bool IsTouchingRight(sprite sprite)
        {
            return this.Rectangle.Left + this.Velocity.X < sprite.Rectangle.Right &&
                this.Rectangle.Right > sprite.Rectangle.Right&&
                this.Rectangle.Bottom > sprite.Rectangle.Top &&
                this.Rectangle.Top < sprite.Rectangle.Bottom;
        }
        protected bool IsTouchingTop(sprite sprite)
        {
            return this.Rectangle.Bottom + this.Velocity.Y > sprite.Rectangle.Top &&
                this.Rectangle.Top < sprite.Rectangle.Top &&
                this.Rectangle.Right > sprite.Rectangle.Left + offset &&
                this.Rectangle.Left < sprite.Rectangle.Right;
        }
        protected bool IsTouchingBottom(sprite sprite)
        {
            return this.Rectangle.Top + this.Velocity.Y < sprite.Rectangle.Bottom &&
                this.Rectangle.Bottom > sprite.Rectangle.Bottom &&
                this.Rectangle.Right > sprite.Rectangle.Left + offset &&
                this.Rectangle.Left < sprite.Rectangle.Right;
        }

      
        #endregion
        #endregion
    }
}
