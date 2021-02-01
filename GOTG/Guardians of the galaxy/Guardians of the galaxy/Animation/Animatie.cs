using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Text;

namespace Guardians_of_the_galaxy.Animation
{
    public class Animatie
    {
        #region Fields
        private AnimationFrame _current;
        private List<AnimationFrame> _frames;
        private int _counter;
        private double _frameMovement = 0;
        #endregion
   
        #region Properties
        public AnimationFrame Current
        {
            get { return _current; }
            set { _current = value; }
        }
        #endregion
       
        #region Constructor
        public Animatie()
        {
            _frames = new List<AnimationFrame>();
        }
        #endregion
      
        #region Methodes
        public void addFrame(AnimationFrame animationFrame)
        {
            _frames.Add(animationFrame);
            _current = _frames[0];
        }

        public void update(GameTime gameTime)
        {
            _current = _frames[_counter];
            _frameMovement += _current.SourceRectangle.Width * gameTime.ElapsedGameTime.TotalSeconds;

            if (_frameMovement>=_current.SourceRectangle.Width/10)
            {
                _counter++;
                _frameMovement = 0;
            }

            if (_counter>=_frames.Count)
                _counter = 0;

        }
        #endregion
    }
}
