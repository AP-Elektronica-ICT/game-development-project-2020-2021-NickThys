

using Guardians_of_the_galaxy.Animation;
using Guardians_of_the_galaxy.Interfaces;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;



namespace Guardians_of_the_galaxy
{
    public class Hero:IGameObject
    {
        Texture2D heroTexture;
        Animatie animation;

        public Hero(Texture2D texture)
        {
            heroTexture = texture;
            animation = new Animatie();
            animation.addFrame(new AnimationFrame(new Rectangle(0, 0, 144, 180)));
            animation.addFrame(new AnimationFrame(new Rectangle(144, 0, 144, 180)));
            animation.addFrame(new AnimationFrame(new Rectangle(288, 0, 144, 180)));
            animation.addFrame(new AnimationFrame(new Rectangle(432, 0, 144, 180)));
            animation.addFrame(new AnimationFrame(new Rectangle(576, 0, 144, 180)));
            animation.addFrame(new AnimationFrame(new Rectangle(720, 0, 144, 180)));
       }

        public void draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(heroTexture, new Vector2(10, 10),animation.current.SourceRectangle, Color.White);
        }

        public void update(GameTime gameTime)
        {
            animation.update(gameTime);
        }

    }
}
