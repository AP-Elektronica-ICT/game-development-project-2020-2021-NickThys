using Guardians_of_the_galaxy.GameObjects;
using Guardians_of_the_galaxy.Input;
using Guardians_of_the_galaxy.Sprites;
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
        private GraphicsDeviceManager _graphics;
        private SpriteBatch _spriteBatch;
        private Level _level; 
        private List<sprite> _sprites;
        private Song _song;

        int windowWidth = 990;
        int windowHeight = 792;
        public Game1()
        {
            _graphics = new GraphicsDeviceManager(this);
            _graphics.PreferredBackBufferWidth = windowWidth;
            _graphics.PreferredBackBufferHeight = windowHeight;
            Content.RootDirectory = "Content";
            IsMouseVisible = true;
            MediaPlayer.IsRepeating = true;
        }

        protected override void Initialize()
        {
            // TODO: Add your initialization logic here


            base.Initialize();
           
        }

        protected override void LoadContent()
        {
            _spriteBatch = new SpriteBatch(GraphicsDevice);
            Texture2D _yonduNormalSize = Content.Load<Texture2D>("Yondu_jumping");
            Texture2D _yonduTexture = Content.Load<Texture2D>("Yondu_V2");
            Texture2D _blockTexture= Content.Load<Texture2D>("TestBlock");
            _level = new Level(_blockTexture);
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
                        

                    },Position=new Vector2(66,546),speed=5f
                    
                }
            };
            // TODO: use this.Content to load your game content here
            _sprites.AddRange(_level.getBlocks());
            _song = Content.Load<Song>("Come and Get Your Love [8 Bit Tribute to Redbone & Guardians of the Galaxy] - 8 Bit Universe");
            MediaPlayer.Volume = 0.5f;

            MediaPlayer.Play(_song);
        }

        private void InitializeGameObjects()
        {
         
        }

        protected override void Update(GameTime gameTime)
        {
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
                Exit();

            foreach (var sprite in _sprites)
            {
                
                sprite.Update(gameTime, _sprites);
                if (sprite is Hero)
                {
                    Hero yondu = sprite as Hero;
                    if (yondu.HasDied)
                    {
                        Exit();

                    }
                }
            }
       
            // TODO: Add your update logic here
           
            base.Update(gameTime);
        }

        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.BurlyWood);

            // TODO: Add your drawing code here

            _spriteBatch.Begin();
            foreach (var sprite in _sprites)
            {
                sprite.Draw(_spriteBatch);
            }
            _spriteBatch.End();


            base.Draw(gameTime);
        }
    }
}
