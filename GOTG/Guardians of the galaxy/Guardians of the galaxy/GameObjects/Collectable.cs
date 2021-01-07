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
        private bool _isCollected;
        #endregion
        
        public bool IsCollected
        {
            get {return _isCollected; }
            set {_isCollected=value; }
        }
        #region Constructor
        public Collectable(Texture2D texture) : base(texture)
        {
            _collectableTexture = texture;
        }

        #endregion
        public override void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(_collectableTexture, this.Position, new Rectangle(0, 0, _collectableTexture.Width, _collectableTexture.Height), Color.White, 0, new Vector2(0, 0), 1f, SpriteEffects.None, 0);
        }

        public override void Update(GameTime gameTime, List<sprite> sprites)
        {
        }
    }
}
