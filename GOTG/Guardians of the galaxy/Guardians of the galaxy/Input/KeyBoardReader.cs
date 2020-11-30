using Guardians_of_the_galaxy.Interfaces;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;
using System;
using System.Collections.Generic;
using System.Text;

namespace Guardians_of_the_galaxy.Input
{
    public class KeyBoardReader : IInputReader
    {
        public Vector2 readInput()
        {
            var direction = Vector2.Zero;
            KeyboardState state = Keyboard.GetState();
            if (state.IsKeyDown(Keys.Left))
                direction = new Vector2(-1, 0);
            if (state.IsKeyDown(Keys.Right))
                direction = new Vector2(1, 0);
            return direction;
        }
    }
}
