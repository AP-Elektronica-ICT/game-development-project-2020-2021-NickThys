using Guardians_of_the_galaxy.Sprites;
using System;
using System.Collections.Generic;
using System.Text;

namespace Guardians_of_the_galaxy.Collision
{
   public class CollisionManager
    {
        #region Fields
        private sprite _thisSprite;
        private int _offset;
        #endregion
        #region Properties

        #endregion
        #region Constructor
        public CollisionManager(sprite _sprite,int _offset)
        {
            _thisSprite = _sprite;
            this._offset = _offset;
        }

        #endregion
        #region Methodes
        protected bool IsTouchingLeft(sprite sprite)
        {
            return _thisSprite.Rectangle.Right + _thisSprite.Velocity.X > sprite.Rectangle.Left + _offset &&
                _thisSprite.Rectangle.Left < sprite.Rectangle.Left &&
                _thisSprite.Rectangle.Bottom > sprite.Rectangle.Top &&
                _thisSprite.Rectangle.Top < sprite.Rectangle.Bottom;
        }
        protected bool IsTouchingRight(sprite sprite)
        {
            return _thisSprite.Rectangle.Left + _thisSprite.Velocity.X < sprite.Rectangle.Right &&
                _thisSprite.Rectangle.Right > sprite.Rectangle.Right &&
                _thisSprite.Rectangle.Bottom > sprite.Rectangle.Top &&
                _thisSprite.Rectangle.Top < sprite.Rectangle.Bottom;
        }
        protected bool IsTouchingTop(sprite sprite)
        {
            return _thisSprite.Rectangle.Bottom + _thisSprite.Velocity.Y > sprite.Rectangle.Top &&
                _thisSprite.Rectangle.Top < sprite.Rectangle.Top &&
                _thisSprite.Rectangle.Right > sprite.Rectangle.Left + _offset &&
                _thisSprite.Rectangle.Left < sprite.Rectangle.Right;
        }
        protected bool IsTouchingBottom(sprite sprite)
        {
            return _thisSprite.Rectangle.Top + _thisSprite.Velocity.Y < sprite.Rectangle.Bottom &&
                _thisSprite.Rectangle.Bottom > sprite.Rectangle.Bottom &&
                _thisSprite.Rectangle.Right > sprite.Rectangle.Left + _offset &&
                _thisSprite.Rectangle.Left < sprite.Rectangle.Right;
        }
        #endregion
    }
}
