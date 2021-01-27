using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Text;

namespace Guardians_of_the_galaxy.Components
{
   public abstract class Component
    {
        public abstract void Draw(GameTime _gameTime);
        public abstract void Update(GameTime _gameTime);
    }
}
