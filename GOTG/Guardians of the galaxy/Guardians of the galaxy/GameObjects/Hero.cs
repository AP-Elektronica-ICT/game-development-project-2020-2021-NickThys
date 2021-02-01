using Guardians_of_the_galaxy.Animation;
using Guardians_of_the_galaxy.GameObjects;
using Guardians_of_the_galaxy.Input;
using Guardians_of_the_galaxy.Interfaces;
using Guardians_of_the_galaxy.Sprites;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System.Collections.Generic;

namespace Guardians_of_the_galaxy
{
    public class Hero : sprite
    {
        #region Fields
        private Texture2D _heroTexture;
        private SpriteEffects _spriteEffect;
        private bool _isJumping, _hasDied, _hasWon, _isChanged;
        private Animatie animationR, animationL, currentAnimation, animationStanding, animationJumping;
        private int _nbrOfCollectedItems;
        private Keys _lastKeyPressed;
        #endregion

        #region Properties
        public int NbrOfCollectedItems
        {
            get { return _nbrOfCollectedItems; }
            set { _nbrOfCollectedItems = value; }
        }
        public bool HasDied
        {
            get { return _hasDied; }
            set { _hasDied = value; }
        }
        public bool HasWon
        {
            get { return _hasWon; }
            set { _hasWon = value; }
        }
        #endregion

        #region Constructor
        public Hero(Texture2D texture, Texture2D NormalTexture) : base(NormalTexture)
        {
            _isJumping = true;
            _hasDied = false;
            _hasWon = false;
            _spriteEffect = SpriteEffects.None;
            _heroTexture = texture;
            _lastKeyPressed = Keys.Right;
            #region add frames to animation       
            animationJumping = new Animatie();
            animationJumping.addFrame(new AnimationFrame(new Rectangle(0, 0, 72, 90)));

            animationStanding = new Animatie();
            for (int i = 0; i < 217; i += 72)
            {
                animationStanding.addFrame(new AnimationFrame(new Rectangle(i, 90, 72, 90)));

            }

            animationL = new Animatie();
            for (int j = 0; j < 361; j += 144)
            {
                animationL.addFrame(new AnimationFrame(new Rectangle(j, 180, 72, 90)));
            }

            animationR = new Animatie();
            for (int k = 0; k < 361; k += 144)
            {
                animationR.addFrame(new AnimationFrame(new Rectangle(k, 270, 72, 90)));

            }
            #endregion
            currentAnimation = animationStanding;
        }
        #endregion

        #region Methods
        public override void Draw()
        {
            Globals.SpriteBatch.Draw(_heroTexture, this.Position, currentAnimation.Current.SourceRectangle, Color.White, 0, new Vector2(0, 0), 1f, _spriteEffect, 0);
        }

        public override void Update(GameTime gameTime, List<sprite> sprites)
        {
            _isChanged = false;
            _spriteEffect = SpriteEffects.None;
            Move();
            foreach (var sprite in sprites)
            {
                #region Check if the sprite is the hero
                if (sprite == this)
                    continue;
                #endregion

                #region Check if the sprite is a block
                if (sprite is Block)
                {
                    #region Check if the hero has collided with the left or right side of the sprite
                    if (this.Velocity.X > 0 && this.CollisionManager.IsTouchingLeft(sprite) || this.Velocity.X < 0 && this.CollisionManager.IsTouchingRight(sprite))
                        this.Velocity.X = 0;
                    #endregion

                    #region Check if the hero has collided with the left or right side of the sprite
                    if ((this.Velocity.Y > 0 && this.CollisionManager.IsTouchingTop(sprite) || this.Velocity.Y < 0 && this.CollisionManager.IsTouchingBottom(sprite)))
                    {
                        if (this.Velocity.Y < 0 && this.CollisionManager.IsTouchingBottom(sprite))
                        {
                            this.Position.Y = sprite.Position.Y + sprite.CollisionRectangle.Height;

                        }
                        if (this.CollisionManager.IsTouchingTop(sprite))
                        {
                            _isJumping = false;
                            _isChanged = true;
                            this.Velocity.Y = 0;

                        }

                    }
                    #endregion

                    else
                    {
                        if (!_isChanged)
                        {
                            _isJumping = true;
                        }
                    }
                    if (this.Position.Y > Globals.WindowHeight - currentAnimation.Current.SourceRectangle.Height)
                    {
                        _hasDied = true;
                    }

                }
                #endregion

                #region Check if the hero has colided with the flag
                if (sprite is Flag)
                    if (this.CollisionRectangle.Intersects(sprite.CollisionRectangle))
                        _hasWon = true;

                #endregion

                #region Check if hero has Colided with a Collectable
                if (sprite is Collectable)
                    if (this.CollisionRectangle.Intersects(sprite.CollisionRectangle))
                    {
                        Collectable _collectable = sprite as Collectable;
                        if (!_collectable.IsCollected)
                            _nbrOfCollectedItems++;

                        _collectable.IsCollected = true;

                    }
                #endregion

                #region Check if the hero has collided with the enemy
                if (sprite is Enemy)
                {
                    Enemy _ronan = sprite as Enemy;

                    if (this.CollisionRectangle.Intersects(_ronan.CollisionRectangle))
                    {
                        if (!_ronan.HasDied)
                        {
                            if (this.CollisionManager.IsTouchingTop(_ronan))
                                _ronan.HasDied = true;
                            else if (this.CollisionManager.IsTouchingLeft(_ronan) || this.CollisionManager.IsTouchingRight(_ronan))
                                this.HasDied = true;
                        }
                    }
                }
                #endregion
            }
            #region Set animation
            if (Velocity.X < 0)
                currentAnimation = animationL;
            else if (Velocity.X > 0)
                currentAnimation = animationR;
            if (Velocity.Y != 0)
            {
                currentAnimation = animationJumping;
                if (Velocity.X < 0)
                    _spriteEffect = SpriteEffects.FlipHorizontally;
                if ( Velocity.X == 0)
                {
                    if (_lastKeyPressed == Keys.L)
                    {
                        _spriteEffect = SpriteEffects.FlipHorizontally;
                    }
                }
            }
            if (Velocity.Y==0&&Velocity.X==0)
            {
                currentAnimation = animationStanding;
                if (_lastKeyPressed==Keys.L)
                {
                    _spriteEffect = SpriteEffects.FlipHorizontally;
                }
            }
            currentAnimation.update(gameTime);
            #endregion

            #region set Velocity
            Position.X += Velocity.X;
            Position.Y += Velocity.Y;
            Velocity.X = 0;
            #endregion
        }

        private void Move()
        {
            if (Keyboard.GetState().IsKeyDown(Input.Left))
            {
                Velocity.X = -speed;
                _lastKeyPressed = Keys.L;
            }
            else if (Keyboard.GetState().IsKeyDown(Input.Right))
            {
                Velocity.X = speed;
                _lastKeyPressed = Keys.R;
            }
            if (Keyboard.GetState().IsKeyDown(Input.Space) && !_isJumping)
            {
                Position.Y -= 10f;
                Velocity.Y = -25f;
                _isJumping = true;
            }
            if (_isJumping)
            {
                float i = 1;
                Velocity.Y += 1.5f * i;
            }
            if (!_isJumping)
                Velocity.Y = 0f;
        }
        #endregion
    }
}
