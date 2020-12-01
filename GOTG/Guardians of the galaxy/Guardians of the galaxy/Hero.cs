

using Guardians_of_the_galaxy.Animation;
using Guardians_of_the_galaxy.Command;
using Guardians_of_the_galaxy.Input;
using Guardians_of_the_galaxy.Interfaces;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace Guardians_of_the_galaxy
{
    public class Hero:IGameObject
    {
        private Texture2D heroTexture;
        private Animatie animationR, animationL,currentAnimation,animationStanding,animationJumping;
        
        private Vector2 speed;
        private Vector2 acceleration;
        private Vector2 mouseVector;

        private IInputReader inputReader;
        private IInputReader mouseReader;

        private IGameCommand moveCommand;
        private IGameCommand moveToCommand;

        public Vector2 Postition;
        public Vector2 startPosition;
        float gravity = 0.3f;
        public Hero(Texture2D texture,IInputReader reader)
        {
            Postition = new Vector2(0, 300);
            startPosition = new Vector2(0, 300);


            heroTexture = texture;
            
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

            speed = new Vector2(1, 1);
            acceleration = new Vector2(0.1f, 0.1f);

            this.inputReader = reader;
            mouseReader = new MouseReader();

            moveCommand = new MoveCommand();
            moveToCommand = new MoveToCommand();

            currentAnimation = animationR;
       }

        public void draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(heroTexture, Postition, currentAnimation.current.SourceRectangle, Color.White, 0, new Vector2(0, 0), 0.8f, SpriteEffects.None, 0);
        }

       
  
  
        
        public void update(GameTime gameTime)
        {
            KeyboardState keyboardState = Keyboard.GetState();
            var direction = inputReader.readInput();
            Postition += direction;
            if (Postition.X < 0) Postition.X = 0;
            if (Postition.X > 725) Postition.X = 750;
            if (Postition.Y < 0) Postition.Y = 0;
            if (Postition.Y < startPosition.Y)
            {
                Postition.Y += gravity;
                gravity += 0.1f;
                if (gravity>2f)
                {
                    gravity = 3f;
                }
            }


            #region keyboardread
            if (keyboardState.IsKeyDown(Keys.Left))
            {
                currentAnimation = animationL;
            }
            else if(keyboardState.IsKeyDown(Keys.Right))
            {
                currentAnimation = animationR;
            }
            else if (keyboardState.IsKeyDown(Keys.Space))
            {
                currentAnimation = animationJumping;
            }
            else if(currentAnimation==animationJumping&&Postition.Y<startPosition.Y) 
            {
                Postition.Y += gravity;
                gravity += 0.1f;
                if (gravity>2f)
                {
                    gravity = 2f;
                }
            }
            else
            {
                currentAnimation = animationStanding;
            }
#endregion
        
            currentAnimation.update(gameTime);
        }
    }
}
