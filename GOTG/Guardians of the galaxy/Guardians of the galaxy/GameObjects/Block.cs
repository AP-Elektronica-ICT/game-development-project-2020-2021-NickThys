using Guardians_of_the_galaxy.Interfaces;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Text;

namespace Guardians_of_the_galaxy.GameObjects
{
    class Block : ICollision
    {
        public Texture2D _texture{ get; set; }
        public Vector2 _position { get; set; }
        public Rectangle CollisionRectangle { get ; set; }
        public Block(Texture2D texture,Vector2 position)
        {
            _texture = texture;
            _position = position;
            CollisionRectangle = new Rectangle((int)_position.X, (int)_position.Y, 66,66);
        }
        public void Draw(SpriteBatch sprite)
        {
            sprite.Draw(_texture, _position, Color.White);
        }
    }
}
