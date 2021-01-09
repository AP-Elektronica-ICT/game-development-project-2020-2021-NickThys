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
        public Texture2D heroTexture { get; set; }
        public SpriteEffects _spriteEffect;
        public bool isJumping;
        public float gravity = 0f;
        public bool HasDied = false,HasWon=false;
        private Animatie animationR, animationL, currentAnimation, animationStanding, animationJumping;
        private int _nbrOfCollectedItems;
        #endregion

        #region Properties
        public int NbrOfCollectedItems
        {
            get { return _nbrOfCollectedItems; }
            set { _nbrOfCollectedItems = value; }
        }
      
        #endregion

        #region Constructor
        public Hero(Texture2D texture, Texture2D NormalTexture) : base(NormalTexture)
        {
            isJumping = true;
            _spriteEffect =SpriteEffects.None;
            heroTexture = texture;

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


        public override void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(heroTexture, this.Position, currentAnimation.Current.SourceRectangle, Color.White, 0, new Vector2(0, 0), 1f, _spriteEffect, 0);
        }
 
        public override void Update(GameTime gameTime, List<sprite> sprites)
        {
            int IsChanged = 0;
            _spriteEffect = SpriteEffects.None;
            currentAnimation = animationStanding;
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
                            this.Position.Y = sprite.Position.Y + sprite.Rectangle.Height;

                        }
                        if (this.CollisionManager.IsTouchingTop(sprite))
                        {
                            isJumping = false;
                            IsChanged = 1;

                        }
                        this.Velocity.Y = 0;

                    }
                    #endregion

                    else
                    {
                         if (IsChanged == 0)
                           {
                               isJumping = true;

                           }
                         }
                    if (this.Position.Y > 792 - currentAnimation.Current.SourceRectangle.Height)
                    {
                        HasDied = true;
                    }
                  
                }
                #endregion

                #region Check if the hero has colided with the flag
                if (sprite is Flag)
                {
                    if (this.Rectangle.Intersects(sprite.Rectangle))
                    {
                        HasWon = true;
                    }
                }
                #endregion

                #region Check if hero has Colided with a Collectable
                if (sprite is Collectable)
                {
                    if (this.Rectangle.Intersects(sprite.Rectangle))
                    {
                        Collectable _collectable = sprite as Collectable;
                        if(!_collectable.IsCollected)
                            _nbrOfCollectedItems++;

                        _collectable.IsCollected = true;

                    }
                }
                #endregion

                #region Check if the hero has collided with the enemy
                if (sprite is Enemy)
                {
                    Enemy _ronan = sprite as Enemy;

                    if (this.Rectangle.Intersects(_ronan.Rectangle))
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
            if (Velocity.X <0)
            {
                currentAnimation = animationL;
            }
            else if (Velocity.X >0)
            {
                currentAnimation = animationR;
            }
           if (Velocity.Y != 0)
            {
                currentAnimation = animationJumping;
                if (Velocity.X < 0)
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
                Velocity.X = -speed;
            else if (Keyboard.GetState().IsKeyDown(Input.Right))
                Velocity.X = speed;
            if (Keyboard.GetState().IsKeyDown(Input.Space) && !isJumping)
            {
                Position.Y -= 10f;
                Velocity.Y = -25f;
                isJumping = true;
            }
            if (isJumping)
            {
                float i =1;
                Velocity.Y += 1.5f * i;
            }
            if (!isJumping)
            {
                Velocity.Y = 0f;
            }

        }
        #endregion
    }
}
