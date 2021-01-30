using Guardians_of_the_galaxy.Sprites;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Text;

namespace Guardians_of_the_galaxy.GameObjects
{
    class Flag : sprite
    {
        #region Fields
        private Texture2D _flagTexture;
        #endregion

        #region Constructor
        public Flag(Texture2D texture) : base(texture)
        {
            _flagTexture = texture;
        }
        #endregion

        #region Methodes
        public override void Draw()
        {
            Globals.SpriteBatch.Draw(_flagTexture, this.Position, new Rectangle(0,0,_flagTexture.Width,_flagTexture.Height), Color.White, 0, new Vector2(0, 0), 1f, SpriteEffects.None, 0);
        }

        public override void Update(GameTime gameTime, List<sprite> sprites)
        {

        }
        #endregion
    }
}
