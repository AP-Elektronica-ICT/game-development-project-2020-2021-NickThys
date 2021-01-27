using Guardians_of_the_galaxy.Sprites;
using Guardians_of_the_galaxy.WorldDesign;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Media;
using System;
using System.Collections.Generic;
using System.Text;

namespace Guardians_of_the_galaxy
{
    class Globals
    {
        public static bool MusicIsPlaying;
        public static int WindowWidth, WindowHeight;
        public static SpriteBatch SpriteBatch;
        public static ContentManager ContentLoader;
        public static Level Level1, Level2;
        public static Song SongLevel1, SongLevel2;
        public static List<sprite> SpritesLevel1, SpritesLevel2;
        public static int CurrentLevel;
    }
}
