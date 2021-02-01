using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Text;

namespace Guardians_of_the_galaxy.States
{
    public class StateManager
    {
        #region Fields
        private State _currentState, _nextState;
        #endregion
        #region Constructor
        public StateManager(State _currentState)
        {
            this._currentState = _currentState;
        }
        #endregion
        #region Methodes
        public void Update(GameTime gameTime)
        {
            if (_nextState != null)
            {
                _currentState = _nextState;
                _nextState = null;
            }
            _currentState.Update(gameTime);
        }

        public void ChangeState(State state)
        {
            _nextState = state;
        }
        public void Draw(GameTime gameTime)
        {
            _currentState.Draw(gameTime);
        } 
        #endregion


    }
}
