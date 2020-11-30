using Guardians_of_the_galaxy.Interfaces;
using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Text;

namespace Guardians_of_the_galaxy.Command
{
    public class MoveToCommand : IGameCommand
    {
        private Vector2 speed;

        public MoveToCommand()
        {
            speed = new Vector2(1, 0);
        }

        public void execute(ITransform transform, Vector2 direction)
        {
            direction = Vector2.Add(direction, -transform.Postition);
            direction.Normalize();
            direction = Vector2.Multiply(direction, 6f);

            speed += direction;
            speed = limit(speed, 5);
            transform.Postition += speed;

        }
        private Vector2 limit(Vector2 v, float max)
        {
            if (v.Length() > max)
            {
                var ratio = max / v.Length();
                v.X *= ratio;
                v.Y *= ratio;
            }
            return v;
        }
    }
   
}
