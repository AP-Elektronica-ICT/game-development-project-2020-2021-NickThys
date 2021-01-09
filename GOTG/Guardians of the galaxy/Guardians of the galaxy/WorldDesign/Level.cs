using Guardians_of_the_galaxy.GameObjects;
using Guardians_of_the_galaxy.Sprites;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Text;

namespace Guardians_of_the_galaxy.WorldDesign
{
    public class Level
    {
        #region Fields
        private Texture2D _texture, _flagTexture, _collectableTexture, _ronanTexture, _ronanNormalTexture;
        private static byte[,] _tileArray;
        private sprite[,] _blokArray;
        #endregion

        #region Constructor
        public Level(byte[,] _tileMap, Texture2D[] _textureArray)
        {
            _tileArray = _tileMap;
            _texture = _textureArray[0];
            _flagTexture = _textureArray[1];
            _collectableTexture = _textureArray[2];
            _ronanTexture = _textureArray[3];
            _ronanNormalTexture = _textureArray[4];
            _blokArray = new sprite[_tileArray.GetLength(0), _tileArray.GetLength(1)];
        }
        #endregion
        #region Methodes
        public void CreateWorld()
        {
            for (int x = 0; x < _tileArray.GetLength(0); x++)
            {
                for (int y = 0; y < _tileArray.GetLength(1); y++)
                {
                    if (_tileArray[x, y] == 1)
                        _blokArray[x, y] = new Block(_texture) { Position = new Vector2(y * _texture.Width, x * _texture.Height) };
                    if (_tileArray[x, y] == 2)
                        _blokArray[x, y] = new Flag(_flagTexture) { Position = new Vector2(y * _flagTexture.Width, x * _flagTexture.Height) };
                    if (_tileArray[x, y] == 3)
                        _blokArray[x, y] = new Collectable(_collectableTexture){Position = new Vector2(y * _texture.Width, x * _texture.Height)};
                    if (_tileArray[x, y] == 4)
                        _blokArray[x, y] = new Enemy(_ronanTexture,_ronanNormalTexture,new Vector2(y * _texture.Width, (x + 1) * _texture.Height - _ronanNormalTexture.Height), y * _texture.Width - 2 * _ronanNormalTexture.Width, y * _texture.Width + 2 * _ronanNormalTexture.Width);
                }
            }
        }
        public List<sprite> getBlocks()
        {
            List<sprite> allBlocks = new List<sprite>();
            for (int x = 0; x < _tileArray.GetLength(0); x++)
            {
                for (int y = 0; y < _tileArray.GetLength(1); y++)
                {
                    if (_blokArray[x, y] != null)
                        allBlocks.Add(_blokArray[x, y]);
                }
            }
            return allBlocks;
        }
        #endregion
    }
}
