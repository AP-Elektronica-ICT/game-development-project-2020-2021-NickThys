using Guardians_of_the_galaxy.GameObjects;
using Guardians_of_the_galaxy.Input;
using Guardians_of_the_galaxy.Sprites;
using Guardians_of_the_galaxy.States;
using Guardians_of_the_galaxy.WorldDesign;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Audio;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Media;
using System;
using System.Collections.Generic;
using System.Diagnostics;

namespace Guardians_of_the_galaxy
{
    public class Game1 : Game
    {
        #region Fields
        private GraphicsDeviceManager _graphics;
        private State _currentState, _nextState;
        private Song _mainTheme;
        static private Texture2D _yonduNormalSize, _yonduTexture;
        private Background _background;
        private byte[,] _level1Map, _level2Map;
        #endregion

        #region Properties

        #endregion

        #region Constructor
        public Game1()
        {
            _graphics = new GraphicsDeviceManager(this);

            Content.RootDirectory = "Content";
            IsMouseVisible = true;
            MediaPlayer.IsRepeating = true;
        }
        #endregion

        #region Methodes
        protected override void Initialize()
        {
            // TODO: Add your initialization logic here
            Globals.WindowWidth = 990;
            Globals.WindowHeight = 792;
            Globals.CurrentLevel = 1;
            Globals.SpritesLevel1  = new List<sprite>();
            Globals.SpritesLevel2 = new List<sprite>();
            _graphics.PreferredBackBufferWidth = Globals.WindowWidth;
            _graphics.PreferredBackBufferHeight = Globals.WindowHeight;
            _graphics.ApplyChanges();
            /*
             1=blok
             2=Flag
             3=Collectable
             4=Enemy
             */
            _level1Map = new Byte[,]
        {
            {0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0},
            {0,2,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,1,1,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0},
            {1,1,1,1,1,0,0,0,0,0,0,0,1,0,1,0,1,1,0,0,0,0,0,0,0,0,0,0,1,1,1,0,0,1,1,1,0,0,0,0,0,0,4,0,0,0,0,0,0,0,0,0,0,0,0,1,1,1,1,0,0,0,0},
            {0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,1,1,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,1,1,1,1,1,1,0,0,0,1,1,1,0,0,0,0,0,0,0,0,0,0,0},
            {0,0,0,0,0,0,0,1,1,1,1,0,0,0,0,0,0,0,0,0,0,0,0,1,1,1,1,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0},
            {0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,3,0,0,0,0,0,0,0,0,0,1,1,1,1},
            {0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,3,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,1,1,1,0,0,0,0,0,0,0,0,0,0,0},
            {0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,3,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0},
            {0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,1,1,1,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,1,1,1,1,0,0,0,0},
            {0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,4,0,0,0,0,0,0,0,0,0,0,0,0,0,0,1,1,1,1,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0},
            {1,0,0,0,2,0,0,0,0,0,0,1,1,1,1,1,1,1,1,1,1,1,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0},
            {1,1,1,1,1,1,0,0,0,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,0,0,0,0,0,0,0,0,0,0,1,1,1,1,1,1,1,1,1,1,1,0,0,1,1,1,1,1,1,1,1,1,1,1,1,1},
         };
            _level2Map = new Byte[,]
      {
            {0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0},
            {0,2,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,1,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0},
            {1,1,1,1,1,0,0,0,0,0,0,0,1,0,1,0,1,1,0,0,0,0,0,0,0,0,0,0,1,0,0,1,0,0,1,0,0,0,0,0,0,0,4,0,0,0,0,0,0,0,0,0,0,0,0,1,1,1,1,0,0,0,0},
            {0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,1,1,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,1,1,1,1,1,1,0,0,0,1,1,1,0,0,0,0,0,0,0,0,0,0,0},
            {0,0,0,0,0,0,0,1,0,1,1,0,0,0,0,0,0,0,0,0,0,0,0,1,0,1,1,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0},
            {0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,3,0,0,0,0,0,0,0,0,0,1,1,1,0},
            {0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,3,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,1,1,1,0,0,0,0,0,0,0,0,0,0,0},
            {0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0},
            {0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,1,1,1,1,1,1,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,1,1,1,0,0,0,0},
            {0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,4,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0},
            {1,0,0,0,0,0,0,0,0,0,0,1,1,1,1,1,1,1,1,1,1,1,0,0,0,0,0,0,4,0,0,3,4,0,0,0,0,4,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0},
            {1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1},
            };

            Globals.MusicIsPlaying = true;
            base.Initialize();

        }

        protected override void LoadContent()
        {
            Globals.SpriteBatch = new SpriteBatch(GraphicsDevice);
            Globals.ContentLoader = this.Content;
            Globals.StateManager = new StateManager(new MenuState(this));

            #region Load content
            _yonduNormalSize = Content.Load<Texture2D>("Sprites/Yondu_jumping_rsz");
            _yonduTexture = Content.Load<Texture2D>("Sprites/Yondu_V2_rsz");

            _background = new Background("BackGround/BackGround");

            _mainTheme = Content.Load<Song>("Music/MainTheme");
            Globals.SongLevel1 = Content.Load<Song>("Music/ComeAndGetYourLove");
            Globals.SongLevel2 = Content.Load<Song>("Music/MrBlueSky");
            #endregion
            Globals.GameCamera = new Camera(GraphicsDevice.Viewport);
            Globals.Level1 = new Level(_level1Map);

            SpriteList _tempList = new SpriteList();
            _tempList.AddOneSpriteToList(
                new Hero(_yonduTexture, _yonduNormalSize)
                {
                    Input = new input()
                    {
                        Left = Keys.Left,
                        Right = Keys.Right,
                        Space = Keys.Space,


                    },
                    Position = new Vector2(66, 546),
                    speed = 6f

                });
            _tempList.AddListOfSpritesToList(Globals.Level1.getBlocks());
            Globals.SpritesLevel1.AddRange(_tempList.GetSpriteList());

            Globals.Level2 = new Level(_level2Map);
            _tempList = new SpriteList();
            _tempList.AddOneSpriteToList(
                   new Hero(_yonduTexture, _yonduNormalSize)
                   {
                       Input = new input()
                       {
                           Left = Keys.Left,
                           Right = Keys.Right,
                           Space = Keys.Space,


                       },
                       Position = new Vector2(66, 546),
                       speed = 6f

                   });
            _tempList.AddListOfSpritesToList(Globals.Level2.getBlocks());
            Globals.SpritesLevel2.AddRange(_tempList.GetSpriteList());
            _currentState = new MenuState(this);

            #region Music
            MediaPlayer.Volume = 0.15f;
            MediaPlayer.Play(_mainTheme);
            #endregion
        }
      
        protected override void Update(GameTime gameTime)
        {

            if (Globals.MusicIsPlaying)
                MediaPlayer.Volume = 0.15f;
            else
                MediaPlayer.Volume = 0f;
            Globals.StateManager.Update(gameTime);

            base.Update(gameTime);
        }

        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.BurlyWood);
            Globals.SpriteBatch.Begin();

            _background.Draw();

            Globals.SpriteBatch.End();
            Globals.StateManager.Draw(gameTime);

            base.Draw(gameTime);
        }
        #endregion
    }
}
