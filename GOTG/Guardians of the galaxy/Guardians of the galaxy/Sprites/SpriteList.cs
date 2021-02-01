using System;
using System.Collections.Generic;
using System.Text;

namespace Guardians_of_the_galaxy.Sprites
{
    class SpriteList
    {
        #region Fields
        private List<sprite> _sprites;
        #endregion
        #region Constructor
        public SpriteList()
        {
            _sprites = new List<sprite>();

        }
        #endregion
        #region Methodes
        public void AddOneSpriteToList(sprite _sprite)
        {
            _sprites.Add(_sprite);
        }
        public void AddListOfSpritesToList(List<sprite> _spriteList)
        {
            _sprites.AddRange(_spriteList);
        }
        public List<sprite> GetSpriteList()
        {
            return _sprites;
        } 
        #endregion
    }
}
