using Guardians_of_the_galaxy.Interfaces;
using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Text;

namespace Guardians_of_the_galaxy.Command
{
    public class MoveCommand : IGameCommand
    {
        public Vector2 speed;
        public MoveCommand()
        {
            this.speed = new Vector2(5, 5);
        }
        public void execute(ITransform transform, Vector2 direction)
        {
            direction *= speed;
            transform.Postition += direction;
        }
    }
}
