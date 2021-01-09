using Guardians_of_the_galaxy.Sprites;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Text;

namespace Guardians_of_the_galaxy.GameObjects
{
    class Collectable : sprite
    {
        #region Fields
        private Texture2D _collectableTexture;
        #endregion
        #region Properties
        public bool IsCollected { get; set; }
        #endregion
        #region Constructor
        public Collectable(Texture2D texture) : base(texture)
        {
            _collectableTexture = texture;
        }

        #endregion
        #region Methodes
        public override void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(_collectableTexture, this.Position, new Rectangle(0, 0, _collectableTexture.Width, _collectableTexture.Height), Color.White, 0, new Vector2(0, 0), 1f, SpriteEffects.None, 0);
        }

        public override void Update(GameTime gameTime, List<sprite> sprites)
        {
        } 
        #endregion
    }
}
