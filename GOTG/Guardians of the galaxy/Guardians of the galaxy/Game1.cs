using Guardians_of_the_galaxy.GameObjects;
using Guardians_of_the_galaxy.Input;
using Guardians_of_the_galaxy.Sprites;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System;
using System.Collections.Generic;
using System.Diagnostics;

namespace Guardians_of_the_galaxy
{
    public class Game1 : Game
    {
        private GraphicsDeviceManager _graphics;
        private SpriteBatch _spriteBatch;

        private List<sprite> _sprites;

        int windowWidth = 1000;
        int windowHeight = 800;
        public Game1()
        {
            _graphics = new GraphicsDeviceManager(this);
            _graphics.PreferredBackBufferWidth = windowWidth;
            _graphics.PreferredBackBufferHeight = windowHeight;
            Content.RootDirectory = "Content";
            IsMouseVisible = true;
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
            _sprites = new List<sprite>()
            {
                new Hero(_yonduTexture,_yonduNormalSize)
                {
                    Input=new input()
                    {
                        Left=Keys.Left,
                        Right=Keys.Right,
                        Space=Keys.Space,
                        

                    },Position=new Vector2(100,100),speed=5f
                    
                },
                 new Block(_blockTexture)
                {
                    Position=new Vector2(200,300)

                },
                 new Block(_blockTexture)
                {
                    Position=new Vector2(200+66,300)

                },
                 new Block(_blockTexture)
                {
                    Position=new Vector2(0,600)

                },
                  new Block(_blockTexture)
                {
                    Position=new Vector2(0,534)

                },
                new Block(_blockTexture)
                {
                    Position=new Vector2(66,600)

                },
                new Block(_blockTexture)
                {
                    Position=new Vector2(132,600)

                },
                new Block(_blockTexture)
                {
                    Position=new Vector2(198,600)

                },
                new Block(_blockTexture)
                {
                    Position=new Vector2(264,600)

                },
                new Block(_blockTexture)
                {
                    Position=new Vector2(330,600)

                },
                new Block(_blockTexture)
                {
                    Position=new Vector2(396,600)

                },
                new Block(_blockTexture)
                {
                    Position=new Vector2(462,600)

                }, new Block(_blockTexture)
                {
                    Position=new Vector2(462,600-66)

                }

            };
            // TODO: use this.Content to load your game content here
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
