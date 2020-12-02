

using Guardians_of_the_galaxy.Animation;
using Guardians_of_the_galaxy.Command;
using Guardians_of_the_galaxy.Input;
using Guardians_of_the_galaxy.Interfaces;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace Guardians_of_the_galaxy
{
    public class Hero:IGameObject,ICollision
    {
        private Texture2D heroTexture;
        private Animatie animationR, animationL,currentAnimation,animationStanding,animationJumping;
        private MoveCommand moveCommand;
        private Vector2 speed;
        private Vector2 acceleration;

        private IInputReader inputReader;



        public Vector2 Postition;
        public Vector2 startPosition;

        public Rectangle CollisionRectangle { get; set; }
        private Rectangle _collisionRectangle;
        public Hero(Texture2D texture,IInputReader reader)
        {
            Postition = new Vector2(050, 300);
            startPosition = new Vector2(050, 300);


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
            _collisionRectangle = new Rectangle((int)Postition.X, (int)Postition.Y, 115, 180);
            this.inputReader = reader;
            currentAnimation = animationR;
       }

        public void draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(heroTexture, Postition, currentAnimation.current.SourceRectangle, Color.White, 0, new Vector2(0, 0), 0.8f, SpriteEffects.None, 0);
        }

        public void update(GameTime gameTime)
        {
 
            var direction = inputReader.readInput();
            Postition += direction;

            #region keyboardread
            if (direction.X==-2)
            {
                currentAnimation = animationL;
            }
            else if(direction.X==2)
            {
                currentAnimation = animationR;
            }
            else
            {
                currentAnimation = animationStanding;
            }
            #endregion
            _collisionRectangle.X = (int)Postition.X;
            CollisionRectangle = _collisionRectangle;
            currentAnimation.update(gameTime);
        }
    }
}
