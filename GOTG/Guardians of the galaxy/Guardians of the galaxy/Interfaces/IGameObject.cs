using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Text;

namespace Guardians_of_the_galaxy.Interfaces
{
    interface IGameObject
    {
        void update(GameTime gameTime);
        void draw(SpriteBatch spriteBatch);
    }
}
