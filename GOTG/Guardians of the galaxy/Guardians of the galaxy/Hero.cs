

using Guardians_of_the_galaxy.Animation;
using Guardians_of_the_galaxy.Interfaces;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace Guardians_of_the_galaxy
{
    public class Hero:IGameObject
    {
        private Texture2D heroTexture;
        private Animatie animation;
        private Vector2 positie;
        private Vector2 speed;
        private Vector2 acceleration;
        IInputReader inputReader;

        public Hero(Texture2D texture,IInputReader reader)
        {
            heroTexture = texture;
            animation = new Animatie();
            animation.addFrame(new AnimationFrame(new Rectangle(0, 0, 144, 180)));
            animation.addFrame(new AnimationFrame(new Rectangle(144, 0, 144, 180)));
            animation.addFrame(new AnimationFrame(new Rectangle(288, 0, 144, 180)));
            animation.addFrame(new AnimationFrame(new Rectangle(432, 0, 144, 180)));
            animation.addFrame(new AnimationFrame(new Rectangle(576, 0, 144, 180)));
            animation.addFrame(new AnimationFrame(new Rectangle(720, 0, 144, 180)));
            positie = new Vector2(10, 10);
            speed = new Vector2(1, 1);
            acceleration = new Vector2(0.2f, 0.1f);
            this.inputReader = reader;
       }

        public void draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(heroTexture,positie,animation.current.SourceRectangle, Color.White);
        }
        private void move(Vector2 mouse)
        {

            var direction = Vector2.Add(mouse, -positie);
            direction.Normalize();

            direction = Vector2.Multiply(direction, 6f);
            speed += direction;
            speed = limit(speed, 5);
            positie += speed;


            if (positie.X>600||positie.X<0)
            {
                speed.X *= -1;
                acceleration.X *= -1;
            }
            if (positie.Y>400||positie.Y<0)
            {
                speed.Y *= -1;
                acceleration.Y *= -1;

            }
        }
        private Vector2 limit(Vector2 v,float max)
        {
            if (v.Length() > max)
            {
                var ratio = max / v.Length();
                v.X *= ratio;
                v.Y *= ratio;
            }
            return v;
        }
        public void update(GameTime gameTime)
        {
            var direction = inputReader.readInput();
            direction *= 4;
            positie += direction;
            animation.update(gameTime);
        }

    }
}
