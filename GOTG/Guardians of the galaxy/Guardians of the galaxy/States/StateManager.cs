using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Text;

namespace Guardians_of_the_galaxy.States
{
    public class StateManager
    {
        private State _currentState,_nextState;
        public StateManager(State _currentState ) {
            this._currentState = _currentState;
        }
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


    }
}
