using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System;
using System.Collections.Generic;
using System.Text;

namespace Guardians_of_the_galaxy.Components
{
   public class button : Component
    {
        #region Fields
        private MouseState _currentMouse,_previousMouse;
        private SpriteFont _font;
        private bool _isHovering;
        private Texture2D _texture;
        #endregion
      
        #region Properties
        public event EventHandler Click;
        public bool Clicked { get; private set; }
        public Color PenColor { get; set; }
        public Vector2 Position { get; set; }
        public Texture2D Texture {
            get { return _texture; }
            set { _texture = value; }
        }
        public Rectangle Rectangle {
            get
            {
             return new Rectangle((int)Position.X,(int) Position.Y,_texture.Width,_texture.Height);
            }
        }
        public string Text { get; set; }
        #endregion
       
        #region Methods
        public button(Texture2D texture,SpriteFont font)
        {
            _texture = texture;
            _font = font;
            PenColor = Color.Black;
        }

        public override void Draw(GameTime _gameTime, SpriteBatch _spriteBatch)
        {
            var colour = Color.White;
            if (_isHovering)
                colour = Color.Gray;
            _spriteBatch.Draw(_texture, Rectangle, colour);
            if (!String.IsNullOrEmpty(Text))
            {
                var x = (Rectangle.X + (Rectangle.Width / 2)) - (_font.MeasureString(Text).X / 2);
                var y = (Rectangle.Y + (Rectangle.Height / 2)) - (_font.MeasureString(Text).Y / 2);
                _spriteBatch.DrawString(_font, Text,new Vector2(x, y), PenColor);
            }
        }

        public override void Update(GameTime _gameTime)
        {
            _previousMouse = _currentMouse;
            _currentMouse = Mouse.GetState();
            var mouseRectangle = new Rectangle(_currentMouse.X, _currentMouse.Y, 1, 1);
            _isHovering = false;
            if (mouseRectangle.Intersects(new Rectangle((int)Position.X, (int)Position.Y, _texture.Width, _texture.Height)))
            {
                _isHovering = true;
                if (_currentMouse.LeftButton == ButtonState.Released && _previousMouse.LeftButton == ButtonState.Pressed)
                {
                    Click?.Invoke(this, new EventArgs());
                }
            }
        }
        #endregion

    }
}
