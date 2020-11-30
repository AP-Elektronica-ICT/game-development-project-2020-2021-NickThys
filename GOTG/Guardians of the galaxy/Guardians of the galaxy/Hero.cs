

using Guardians_of_the_galaxy.Animation;
using Guardians_of_the_galaxy.Command;
using Guardians_of_the_galaxy.Input;
using Guardians_of_the_galaxy.Interfaces;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace Guardians_of_the_galaxy
{
    public class Hero:IGameObject,ITransform
    {
        private Texture2D heroTexture;
        private Animatie animationR, animationL,currentAnimation;
        
        private Vector2 speed;
        private Vector2 acceleration;
        private Vector2 mouseVector;

        private IInputReader inputReader;
        private IInputReader mouseReader;

        private IGameCommand moveCommand;
        private IGameCommand moveToCommand;

        public Vector2 Postition { get; set; }
        
        public Hero(Texture2D texture,IInputReader reader)
        {
            heroTexture = texture;
            animationR = new Animatie();
            for (int i = 0; i < 721; i+= 144)
            {
                animationR.addFrame(new AnimationFrame(new Rectangle(i, 180, 144, 180)));

            }
            animationL = new Animatie();
            for (int j = 0;j < 721; j+=144)
            {
                animationL.addFrame(new AnimationFrame(new Rectangle(j, 0, 144, 180)));
            }

            //Postition = new Vector2(10, 10);
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
            spriteBatch.Draw(heroTexture, Postition, currentAnimation.current.SourceRectangle, Color.White, 0, new Vector2(0, 0), 0.6f, SpriteEffects.None, 0);
        }
        private void Move(Vector2 mouse)
        {
            moveToCommand.execute(this, mouse);
          


          /*  if (Postition.X>600|| Postition.X<0)
            { 
                speed.X *= -1;
                acceleration.X *= -1;
            }
            if (Postition.Y>400|| Postition.Y<0)
            {
                speed.Y *= -1;
                acceleration.Y *= -1;

            }*/
        }
       
        public void moveHor(Vector2 direction)
        {
            moveCommand.execute(this, direction);
        }
        public void update(GameTime gameTime)
        {
            KeyboardState keyboardState = Keyboard.GetState();
            var direction = inputReader.readInput();
            Postition += direction;
            if (keyboardState.IsKeyDown(Keys.Left))
            {
                currentAnimation = animationL;
            }
            else if(keyboardState.IsKeyDown(Keys.Right))
            {
                currentAnimation = animationR;
            }
            currentAnimation.update(gameTime);
        }
    }
}
