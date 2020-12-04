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
            if (state.IsKeyDown(Keys.Left)||state.IsKeyDown(Keys.Q))
                direction = new Vector2(-2, 0);

            if (state.IsKeyDown(Keys.Right) || state.IsKeyDown(Keys.D))
                direction = new Vector2(2, 0);
            if (state.IsKeyDown(Keys.Space))
                direction = new Vector2(0, -10);

            return direction;
        }
    }
}
