using Guardians_of_the_galaxy.GameObjects;
using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Text;

namespace Guardians_of_the_galaxy.Collision
{
    class CollisionManager
    {
        public bool CheckCollision(Hero hero,Block block)
        {
            if (hero.CollisionRectangle.Intersects(block.CollisionRectangle))
                return true;
            return false;

        }
    }
}
