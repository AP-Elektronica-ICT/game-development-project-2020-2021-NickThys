using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Text;

namespace Guardians_of_the_galaxy.Collision
{
    class CollisionManager
    {
        public bool CheckCollision(Rectangle rect1,Rectangle rect2)
        {
            if (rect1.Intersects(rect2))
                return true;
            return false;

        }
    }
}
