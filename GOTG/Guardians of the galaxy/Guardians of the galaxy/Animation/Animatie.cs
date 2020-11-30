using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Text;

namespace Guardians_of_the_galaxy.Animation
{
    public class Animatie
    {
        public AnimationFrame current;
        private List<AnimationFrame> frames;
        private int counter;
        private double frameMovement = 0;
        public Animatie()
        {
            frames = new List<AnimationFrame>();
        }

        public void addFrame(AnimationFrame animationFrame)
        {
            frames.Add(animationFrame);
            current = frames[0];
        }

        public void update(GameTime gameTime)
        {
            current = frames[counter];
            frameMovement += current.SourceRectangle.Width * gameTime.ElapsedGameTime.TotalSeconds;

            if (frameMovement>=current.SourceRectangle.Width/5)
            {
                counter++;
                frameMovement = 0;
            }

            if (counter>=frames.Count)
            {
                counter = 0;
            }
        }
    }
}
