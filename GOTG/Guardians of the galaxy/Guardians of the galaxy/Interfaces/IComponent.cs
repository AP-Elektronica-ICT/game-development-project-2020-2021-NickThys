using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Text;

namespace Guardians_of_the_galaxy.Components
{
   public interface IComponent
    {
        public  void Draw(GameTime _gameTime);
        public virtual void Update(GameTime _gameTime) { }
    }
}
