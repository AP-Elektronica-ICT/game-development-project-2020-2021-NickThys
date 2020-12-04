

using Guardians_of_the_galaxy.Animation;
using Guardians_of_the_galaxy.Input;
using Guardians_of_the_galaxy.Interfaces;
using Guardians_of_the_galaxy.Sprites;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System.Collections.Generic;

namespace Guardians_of_the_galaxy
{
    public class Hero : sprite
    {
        public bool isJumping;
        public float gravity = 0f;
        public Hero(Texture2D texture) : base(texture)
        {
            isJumping = true;
        }
        public override void Update(GameTime gameTime, List<sprite> sprites)
        {
            int IsChanged = 0;

            Move();
            foreach (var sprite in sprites)
            {
                if (sprite==this)
                    continue;
                if (this.Velocity.X > 0 && this.IsTouchingLeft(sprite)|| this.Velocity.X < 0 && this.IsTouchingRight(sprite))
                    this.Velocity.X = 0;
                if ((this.Velocity.Y > 0 && this.IsTouchingTop(sprite) || this.Velocity.Y < 0 && this.IsTouchingBottom(sprite)))
                {
                    this.Velocity.Y = 0;
                    isJumping = false;
                    IsChanged = 1;
                }
                else
                {
                    if (IsChanged==0)
                    {
                        isJumping = true;

                    }
                }
                

            }
            Position += Velocity;
            Velocity = Vector2.Zero;
        }

        private void Move()
        {
            if (Keyboard.GetState().IsKeyDown(Input.Left))
                Velocity.X = -speed;
            else if (Keyboard.GetState().IsKeyDown(Input.Right))
                Velocity.X = speed;
            if (Keyboard.GetState().IsKeyDown(Input.Space)&&!isJumping)
            {
                Position.Y -= 400;
                isJumping = true;
            }
            else if(isJumping)
            {
                Velocity.Y += gravity;
                gravity+= 0.15f;
                if (gravity>2f)
                {
                    gravity = 2f;
                }
            }

        }





        /*  public Texture2D heroTexture { get; set; }
          private Animatie animationR, animationL,currentAnimation,animationStanding,animationJumping;
          private Vector2 speed;
          private Vector2 acceleration;




          public Vector2 Postition;
          public Vector2 startPosition;

          public Rectangle CollisionRectangle { get; set; }
          private Rectangle _collisionRectangle;
          public Hero(Texture2D texture,Vector2 position)
          {
              Postition = position;
              startPosition = position;


              heroTexture = texture;

              #region add frames to animation       
              animationJumping = new Animatie();
              animationJumping.addFrame(new AnimationFrame(new Rectangle(0, 0, 144, 180)));

              animationStanding = new Animatie();
              for (int i = 0; i < 433; i += 144)
              {
                  animationStanding.addFrame(new AnimationFrame(new Rectangle(i, 180, 144, 180)));

              }

              animationL = new Animatie();
              for (int j = 0;j < 721; j+=144)
              {
                  animationL.addFrame(new AnimationFrame(new Rectangle(j, 360, 144, 180)));
              }

              animationR = new Animatie();
              for (int k = 0; k < 721; k += 144)
              {
                  animationR.addFrame(new AnimationFrame(new Rectangle(k, 540, 144, 180)));

              }
              #endregion

              speed = new Vector2(1, 1);
              acceleration = new Vector2(0.1f, 0.1f);
              _collisionRectangle = new Rectangle((int)Postition.X, (int)Postition.Y, 55, 90);
              currentAnimation = animationR;
         }

          public void draw(SpriteBatch spriteBatch)
          {
              spriteBatch.Draw(heroTexture, Postition, currentAnimation.current.SourceRectangle, Color.White, 0, new Vector2(0, 0), 0.5f, SpriteEffects.None, 0);
          }

          public void update(GameTime gameTime)
          {

              var direction = new Vector2(0,3) ;
              Postition += direction;

              if (Postition.Y<startPosition.Y)
              {
                  Postition.Y += 1f;
              }


              #region keyboardread
              if (direction.X==-2)
              {
                  currentAnimation = animationL;
              }
              else if(direction.X==2)
              {
                  currentAnimation = animationR;
              }
              else if (direction.Y==-5)
              {
                  currentAnimation = animationJumping;
              }
              else
              {
                  currentAnimation = animationStanding;
              }
              #endregion
              _collisionRectangle.Y = (int)Postition.Y;
              _collisionRectangle.X = (int)Postition.X;
              CollisionRectangle = _collisionRectangle;
              currentAnimation.update(gameTime);
          }
     */
    }
}
