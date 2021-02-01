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

        #region Constructor
        public CollisionManager(sprite _sprite,int _offset)
        {
            _thisSprite = _sprite;
            this._offset = _offset;
        }
        #endregion
      
        #region Methodes
        public bool IsTouchingLeft(sprite sprite)
        {
            return _thisSprite.CollisionRectangle.Right + _thisSprite.Velocity.X > sprite.CollisionRectangle.Left + _offset &&
                _thisSprite.CollisionRectangle.Left < sprite.CollisionRectangle.Left &&
                _thisSprite.CollisionRectangle.Bottom > sprite.CollisionRectangle.Top &&
                _thisSprite.CollisionRectangle.Top < sprite.CollisionRectangle.Bottom;
        }
        public bool IsTouchingRight(sprite sprite)
        {
            return _thisSprite.CollisionRectangle.Left + _thisSprite.Velocity.X < sprite.CollisionRectangle.Right &&
                _thisSprite.CollisionRectangle.Right > sprite.CollisionRectangle.Right &&
                _thisSprite.CollisionRectangle.Bottom > sprite.CollisionRectangle.Top &&
                _thisSprite.CollisionRectangle.Top < sprite.CollisionRectangle.Bottom;
        }
        public bool IsTouchingTop(sprite sprite)
        {
            return _thisSprite.CollisionRectangle.Bottom + _thisSprite.Velocity.Y > sprite.CollisionRectangle.Top &&
                _thisSprite.CollisionRectangle.Top < sprite.CollisionRectangle.Top &&
                _thisSprite.CollisionRectangle.Right > sprite.CollisionRectangle.Left + _offset &&
                _thisSprite.CollisionRectangle.Left < sprite.CollisionRectangle.Right;
        }
        public bool IsTouchingBottom(sprite sprite)
        {
            return _thisSprite.CollisionRectangle.Top + _thisSprite.Velocity.Y < sprite.CollisionRectangle.Bottom &&
                _thisSprite.CollisionRectangle.Bottom > sprite.CollisionRectangle.Bottom &&
                _thisSprite.CollisionRectangle.Right > sprite.CollisionRectangle.Left + _offset &&
                _thisSprite.CollisionRectangle.Left < sprite.CollisionRectangle.Right;
        }
        #endregion
    }
}
