using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Text;

namespace Guardians_of_the_galaxy.Components
{
    public class RegularButton : button
    {

        #region Constructor
        public RegularButton(Texture2D _texture, Vector2 _position)
        {
            Texture = _texture;
            Position = _position;
        }
        #endregion

    }
}
