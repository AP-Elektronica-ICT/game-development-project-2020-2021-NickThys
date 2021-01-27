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
        private Song _mainTheme, _song1, _song2;
        private Texture2D[] _texturesLevel1, _texturesLevel2;
        static private Texture2D _yonduNormalSize, _yonduTexture, _blockTexture, _flagTexture, _collectableTexture, _ronanTexture, _ronanNormalTexture;
        private Background _background;
        private Camera _camera;
        private Level _level;
        private List<sprite> _sprites;

        #endregion

        #region Properties
      
        public Camera Camera
        {
            get { return _camera; }
            set { _camera = value; }
        }


        public Level Level
        {
            get { return _level; }
            set { _level = value; }
        }

        public List<sprite> sprites
        {
            get { return _sprites; }
            set { _sprites = value; }
        }

        public byte[,] Level1 { get; } = new Byte[,]
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
        public byte[,] Level2 { get; } = new Byte[,]
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

        public Texture2D[] TexturesLevel1
        {
            get { return _texturesLevel1; }
        }
        public Texture2D[] TexturesLevel2
        {
            get { return _texturesLevel2; }
        }
        public Song Song1
        {
            get { return _song1; }
        }
        public Song Song2
        {
            get { return _song2; }
        }
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
            _graphics.PreferredBackBufferWidth = Globals.WindowWidth;
            _graphics.PreferredBackBufferHeight = Globals.WindowHeight;
            _graphics.ApplyChanges();

            Globals.MusicIsPlaying = true;
            base.Initialize();

        }

        protected override void LoadContent()
        {
            Globals.SpriteBatch = new SpriteBatch(GraphicsDevice);
            Globals.ContentLoader = this.Content;

            #region Load content
            _yonduNormalSize = Content.Load<Texture2D>("Sprites/Yondu_jumping_rsz");
            _yonduTexture = Content.Load<Texture2D>("Sprites/Yondu_V2_rsz");

            _background = new Background("BackGround/BackGround");

            _mainTheme = Content.Load<Song>("Music/MainTheme");
            Globals.SongLevel1 = Content.Load<Song>("Music/ComeAndGetYourLove");
            Globals.SongLevel2 = Content.Load<Song>("Music/MrBlueSky");
            #endregion
            _texturesLevel1 = new Texture2D[]
            {
                _blockTexture,
                _flagTexture,
                _collectableTexture,
                                _ronanTexture,
                _ronanNormalTexture,
            };
            _texturesLevel2 = new Texture2D[]
           {
                _blockTexture,
                _flagTexture,
                _collectableTexture,
                                _ronanTexture,
                _ronanNormalTexture,
           };
            _camera = new Camera(GraphicsDevice.Viewport);
            Globals.Level1 = new Level(Level1, TexturesLevel1);
            Globals.Level1.CreateWorld();
            Globals.SpritesLevel1 = new List<sprite>()
            {
                  new Hero(_yonduTexture,_yonduNormalSize)
                {
                    Input=new input()
                    {
                        Left=Keys.Left,
                        Right=Keys.Right,
                        Space=Keys.Space,


                    },Position=new Vector2(66,546),speed=6f

                },

            };
            Globals.SpritesLevel1.AddRange(Globals.Level1.getBlocks());

            Globals.Level2 = new Level(Level2, TexturesLevel2);
            Globals.Level2.CreateWorld();
            Globals.SpritesLevel2 = new List<sprite>()
            {
                  new Hero(_yonduTexture,_yonduNormalSize)
                {
                    Input=new input()
                    {
                        Left=Keys.Left,
                        Right=Keys.Right,
                        Space=Keys.Space,


                    },Position=new Vector2(66,546),speed=6f

                },

            };
            Globals.SpritesLevel2.AddRange(Globals.Level2.getBlocks());

            _currentState = new MenuState(this);

            #region Music
            MediaPlayer.Volume = 0.15f;
            MediaPlayer.Play(_mainTheme);
            #endregion
        }
        
        public void ChangeState(State state)
        {
            _nextState = state;
        }

        protected override void Update(GameTime gameTime)
        {

            if (Globals.MusicIsPlaying)
                MediaPlayer.Volume = 0.15f;
            else
                MediaPlayer.Volume = 0f;
            if (_nextState != null)
            {
                _currentState = _nextState;
                _nextState = null;
            }
            _currentState.Update(gameTime);

            base.Update(gameTime);
        }

        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.BurlyWood);
            Globals.SpriteBatch.Begin();

            _background.Draw();
            Globals.SpriteBatch.End();
            _currentState.Draw(gameTime);

            base.Draw(gameTime);
        }
        #endregion
    }
}
