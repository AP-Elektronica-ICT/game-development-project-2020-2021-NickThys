using Guardians_of_the_galaxy.Interfaces;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;
using System;
using System.Collections.Generic;
using System.Text;

namespace Guardians_of_the_galaxy.Input
{
    public class MouseReader : IInputReader
    {
        public bool ReadFollower()
        {
            throw new NotImplementedException();
        }

        public Vector2 readInput()
        {
            MouseState state = Mouse.GetState();
            var mouseVector = new Vector2(state.X, state.Y);
            return mouseVector;
        }
    }
}
