using Guardians_of_the_galaxy.GameObjects;
using Guardians_of_the_galaxy.Sprites;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Text;

namespace Guardians_of_the_galaxy.WorldDesign
{
    class Level
    {
        Texture2D _texture;
        public byte[,] tileArray = new Byte[,]
        {
            {0,0,0,0,0,0 },
            {0,0,0,0,0,0 },
            {1,0,1,0,1,0 },
            {0,1,0,1,0,1 },
        };
        private Block[,] blokArray = new Block[4, 6];
        public Level(Texture2D texture)
        {
            _texture = texture;
        }
        public void CreateWorld()
        {
            for (int x = 0; x < 4; x++)
            {
                for (int y = 0; y < 6; y++)
                {
                    if (tileArray[x, y] == 1)
                    {
                        blokArray[x, y] = new Block(_texture) {Position= new Vector2(y * 128, x * 64) };
                    }
                }
            }
        }
        public List<sprite> getBlocks()
        {
            List<sprite> allBlocks=new List<sprite>();
            for (int x = 0; x < 4; x++)
            {
                for (int y = 0; y < 6; y++)
                {
                    if (blokArray[x, y] !=null)
                    {
                        allBlocks.Add(blokArray[x, y]);
                    }
                }
            }
            return allBlocks;
        }
    }
}
