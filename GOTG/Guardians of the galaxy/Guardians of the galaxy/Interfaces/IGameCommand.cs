using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Text;

namespace Guardians_of_the_galaxy.Interfaces
{
    public interface IGameCommand
    {
        void execute(ITransform transform, Vector2 direction);
    }
}
