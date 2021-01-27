using Guardians_of_the_galaxy.Animation;
using Guardians_of_the_galaxy.Sprites;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Text;

namespace Guardians_of_the_galaxy.GameObjects
{
    class Enemy : sprite
    {
        #region Fields
        private SpriteEffects _spriteEffect;
        private bool _hasDied;
        private int _boundryLeft,_boundryRight,_dir;
        private Animatie _animationRunning;
        #endregion
        #region Properties
        public bool HasDied
        {
            get {return _hasDied; }
            set { _hasDied = value; }
        }
        public Texture2D EnemyTexture { get; }
        #endregion
        #region Constructor
        public Enemy(Texture2D texture,Texture2D _normalTexture, Vector2 _position,int _boundryLeft, int _boundryRight) : base(_normalTexture)
        {
            EnemyTexture = texture;
            _hasDied = false;
            _spriteEffect = SpriteEffects.None;
            this.Position = _position;
            this._boundryLeft = _boundryLeft;
            this._boundryRight = _boundryRight- 94;
            Velocity.X = 3;
            _dir = 3;
            _animationRunning = new Animatie();
            for (int j = 0; j < 471; j += 94)
            {
                _animationRunning.addFrame(new AnimationFrame(new Rectangle(j, 0, 94, 90)));
            }
        }
        #endregion

        #region Methodes
        public override void Draw()
        {
            Globals.SpriteBatch.Draw(EnemyTexture, this.Position, _animationRunning.Current.SourceRectangle, Color.White, 0, new Vector2(0, 0), 1f, _spriteEffect, 0);
        }

        public override void Update(GameTime gameTime, List<sprite> sprites)
        {
            _spriteEffect = SpriteEffects.None;
            Move();
            foreach (var sprite in sprites)
            {
                #region Check if the sprite is the hero
                if (sprite == this)
                {
                    if (Position.X >= _boundryRight)
                        if (_dir != -3)
                            _dir = -3;
                    if (Position.X <= _boundryLeft)
                        if (_dir != 3)
                            _dir = 3;
                }
                #endregion
            }
            #region Set animation
            if (Velocity.X < 0)
            {
                _spriteEffect = SpriteEffects.FlipHorizontally;
            }
            _animationRunning.update(gameTime);
            #endregion

            #region set Velocity
            Position.X += Velocity.X;
            #endregion
        }

        private void Move()
        {
            Velocity.X = _dir;
        } 
        #endregion
    }
}
