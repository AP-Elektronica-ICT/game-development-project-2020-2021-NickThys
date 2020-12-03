using Guardians_of_the_galaxy.Collision;
using Guardians_of_the_galaxy.GameObjects;
using Guardians_of_the_galaxy.Input;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System;
using System.Diagnostics;

namespace Guardians_of_the_galaxy
{
    public class Game1 : Game
    {
        private GraphicsDeviceManager _graphics;
        private SpriteBatch _spriteBatch;

        private Texture2D YonduTexture,BlockTexture;
        private int CollidedCount; 
        Hero yondu;
        Block TestBock;
        CollisionManager _collisionManager;

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
            _collisionManager = new CollisionManager();
            CollidedCount = 0;
        }

        protected override void LoadContent()
        {
            _spriteBatch = new SpriteBatch(GraphicsDevice);
            YonduTexture = Content.Load<Texture2D>("Yondu_V2");
            BlockTexture = Content.Load<Texture2D>("TestBlock");
            InitializeGameObjects();
            // TODO: use this.Content to load your game content here
        }

        private void InitializeGameObjects()
        {
            yondu = new Hero(YonduTexture,new KeyBoardReader(), new Vector2(400, 600));
            TestBock = new Block(BlockTexture, new Vector2(200,420));
        }

        protected override void Update(GameTime gameTime)
        {
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
                Exit();

            // TODO: Add your update logic here
            yondu.update(gameTime);
            if (_collisionManager.CheckCollision(yondu,TestBock))
            {

                //right
                if (yondu.Postition.X>TestBock._position.X -  TestBock.CollisionRectangle.Width && yondu.CollisionRectangle.Bottom > TestBock.CollisionRectangle.Bottom)
                {
                    yondu.Postition.X += 3 ;
                }
                //left
                 if(yondu.Postition.X<TestBock._position.X + TestBock.CollisionRectangle.Width && yondu.CollisionRectangle.Bottom > TestBock.CollisionRectangle.Bottom)
                {
                    yondu.Postition.X -=3;
                }
                 //top
                if(yondu.Postition.Y<TestBock._position.Y-66)
                {
                    yondu.Postition.Y = TestBock._position.Y-yondu.CollisionRectangle.Height;
                }
                //bottom
                 if (yondu.Postition.Y>TestBock._position.Y-66)
                {
                    yondu.Postition.Y = TestBock._position.Y+66;
                }
            }
            base.Update(gameTime);
        }

        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.BurlyWood);

            // TODO: Add your drawing code here

            _spriteBatch.Begin();

            yondu.draw(_spriteBatch);
            TestBock.Draw(_spriteBatch);

            _spriteBatch.End();


            base.Draw(gameTime);
        }
    }
}
