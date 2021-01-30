using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Text;

namespace Guardians_of_the_galaxy.Components
{
    public class SoundButton:button
    {
        private Texture2D _textureBtnOff, _textureBtnOn;
        public SoundButton()
        {
            Position = new Vector2(50, 50);
            _textureBtnOff= Globals.ContentLoader.Load<Texture2D>("Buttons/Sound_BTN");
            _textureBtnOn= Globals.ContentLoader.Load<Texture2D>("Buttons/ActiveSound_BTN");
        }
        public SoundButton(Vector2 position,Texture2D textureOff,Texture2D textureOn)
        {
            Position = position;
            _textureBtnOff = textureOff;
            _textureBtnOn = textureOn;
        }
        
        public override void Update(GameTime _gameTime)
        {
            if (Globals.MusicIsPlaying)
                Texture = _textureBtnOn;
            else
                Texture = _textureBtnOff;
            base.Update(_gameTime);

        }
    }
}
