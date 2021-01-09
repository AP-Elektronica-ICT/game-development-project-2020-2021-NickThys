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
        private SpriteBatch _spriteBatch;
        private State _currentState, _nextState;
        private Song _mainTheme,_song1,_song2;
        private Texture2D[] _texturesLevel1, _texturesLevel2;
        private bool _musicIsPlaying;
        static private Texture2D _backGround,_yonduNormalSize, _yonduTexture, _blockTexture, _flagTexture, _collectableTexture,_ronanTexture, _ronanNormalTexture;
        public int windowWidth = 990;
        public int windowHeight = 792;
        #endregion

        #region Properties
        private Camera _camera;

        public Camera Camera
        {
            get { return _camera; }
            set { _camera = value; }
        }

        private Level _level;

        public Level Level
        {
            get { return _level; }
            set { _level = value; }
        }
        private List<sprite> _sprites;

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
        public bool MusicIsPlaying { get { return _musicIsPlaying; } set { _musicIsPlaying = value; } }
        #endregion

        #region Constructor
        public Game1()
        {
            _graphics = new GraphicsDeviceManager(this);
            _graphics.PreferredBackBufferWidth = windowWidth;
            _graphics.PreferredBackBufferHeight = windowHeight;
            Content.RootDirectory = "Content";
            IsMouseVisible = true;
            MediaPlayer.IsRepeating = true;
        }
        #endregion

        #region Methodes
        protected override void Initialize()
        {
            // TODO: Add your initialization logic here
            _musicIsPlaying = true;
            base.Initialize();
            
        }

        protected override void LoadContent()
        {
            _spriteBatch = new SpriteBatch(GraphicsDevice);
            #region Load content
            _yonduNormalSize = Content.Load<Texture2D>("Sprites/Yondu_jumping_rsz");
            _yonduTexture = Content.Load<Texture2D>("Sprites/Yondu_V2_rsz");
            _blockTexture = Content.Load<Texture2D>("Sprites/TestBlock");
            _flagTexture = Content.Load<Texture2D>("Sprites/Flag");
            _collectableTexture = Content.Load<Texture2D>("Sprites/STAR");
            _ronanTexture = Content.Load<Texture2D>("Sprites/RonanSprite");
            _ronanNormalTexture = Content.Load<Texture2D>("Sprites/Ronan");
            _backGround=Content.Load<Texture2D>("BackGround/BackGround");
            _mainTheme = Content.Load<Song>("Music/MainTheme");
            _song1 = Content.Load<Song>("Music/ComeAndGetYourLove");
            _song2 = Content.Load<Song>("Music/MrBlueSky");
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
                       
           
            _currentState = new MenuState(Content, GraphicsDevice, this);
            
            #region Music
             MediaPlayer.Volume = 0.15f;
             MediaPlayer.Play(_mainTheme);
            #endregion
        }
        public void CreateLevel(byte[,] _tileMap,Texture2D[] _textureArary)
        {
            
            _level = new Level(_tileMap,_textureArary);
            _level.CreateWorld();
            _sprites = new List<sprite>()
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
            _sprites.AddRange(_level.getBlocks());
        }
        public void ChangeState(State state)
        {
            _nextState = state;
        }

        private void InitializeContent()
        {
        }

        protected override void Update(GameTime gameTime)
        {
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
                Exit();
            if(_musicIsPlaying)
                MediaPlayer.Volume = 0.15f;
            else
                MediaPlayer.Volume = 0f;
            if (_nextState != null)
            {
                _currentState = _nextState;
                _nextState = null;
            }
            _currentState.Update(gameTime);
            _currentState.PostUpdate(gameTime);
           
            base.Update(gameTime);
        }

        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.BurlyWood);
            _spriteBatch.Begin();

            _spriteBatch.Draw(_backGround, new Rectangle(0, 0, windowWidth, windowHeight), Color.White);

            _spriteBatch.End();
            _currentState.Draw(gameTime, _spriteBatch);

            base.Draw(gameTime);
        }
        #endregion
    }
}
