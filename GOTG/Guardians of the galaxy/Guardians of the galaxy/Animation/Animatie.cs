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

        public Animatie()
        {
            frames = new List<AnimationFrame>();
        }

        public void addFrame(AnimationFrame animationFrame)
        {
            frames.Add(animationFrame);
            current = frames[0];
        }

        public void update()
        {
            current = frames[counter];
            counter++;
            if (counter>=frames.Count)
            {
                counter = 0;
            }
        }
    }
}
