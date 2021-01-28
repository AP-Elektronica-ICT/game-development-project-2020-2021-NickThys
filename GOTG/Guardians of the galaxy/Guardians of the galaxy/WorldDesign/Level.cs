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
        private Texture2D _blockTexture, _flagTexture, _collectableTexture, _ronanTexture, _ronanNormalTexture;
        private static byte[,] _tileArray;
        private sprite[,] _blokArray;
        #endregion

        #region Constructor
        public Level(byte[,] _tileMap)
        {
            _tileArray = _tileMap;
            _blockTexture = Globals.ContentLoader.Load<Texture2D>("Sprites/TestBlock");
            _flagTexture = Globals.ContentLoader.Load<Texture2D>("Sprites/Flag");
            _collectableTexture = Globals.ContentLoader.Load<Texture2D>("Sprites/STAR");
            _ronanTexture = Globals.ContentLoader.Load<Texture2D>("Sprites/RonanSprite");
            _ronanNormalTexture = Globals.ContentLoader.Load<Texture2D>("Sprites/Ronan");
            _blokArray = new sprite[_tileArray.GetLength(0), _tileArray.GetLength(1)];

            for (int x = 0; x < _tileArray.GetLength(0); x++)
            {
                for (int y = 0; y < _tileArray.GetLength(1); y++)
                {
                    switch(_tileArray[x, y])
                    {
                        case 1:
                            _blokArray[x, y] = new Block(_blockTexture) { Position = new Vector2(y * _blockTexture.Width, x * _blockTexture.Height) };
                            break;
                        case 2:
                            _blokArray[x, y] = new Flag(_flagTexture) { Position = new Vector2(y * _flagTexture.Width, x * _flagTexture.Height) };
                            break;
                        case 3:
                            _blokArray[x, y] = new Collectable(_collectableTexture) { Position = new Vector2(y * _blockTexture.Width, x * _blockTexture.Height) };
                            break;
                        case 4:
                            _blokArray[x, y] = new Enemy(_ronanTexture,
                            _ronanNormalTexture,
                            new Vector2(y * _blockTexture.Width, (x + 1) * _blockTexture.Height - _ronanNormalTexture.Height),
                            y * _blockTexture.Width - 2 * _ronanNormalTexture.Width,
                            y * _blockTexture.Width +  _ronanNormalTexture.Width);
                            break;
                    }

                }
            }

        }
        #endregion
        #region Methodes
     
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
