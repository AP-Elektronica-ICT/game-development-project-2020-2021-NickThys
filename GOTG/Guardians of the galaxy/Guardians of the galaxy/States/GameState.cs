using Guardians_of_the_galaxy.GameObjects;
using Guardians_of_the_galaxy.Sprites;
using Guardians_of_the_galaxy.WorldDesign;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Media;
using System;
using System.Collections.Generic;
using System.Text;

namespace Guardians_of_the_galaxy.States
{
    public class GameState : State
    {
        #region Fields
        private bool HeroDied;
        private int _nbrOfCollectedItems;
        private Level _level;
        private List<sprite> _sprites;
        private Camera _camera;
        #endregion

        #region Constructor
        public GameState(ContentManager content, GraphicsDevice graphicsDevice, Game1 game,Level _level,Song _song) : base(content, graphicsDevice, game)
        {
            HeroDied = false;
            this._level = _level;
            _sprites = game.sprites;
            _camera = game.Camera;
            _game = game;
            _graphicsDevice = graphicsDevice;
            foreach (sprite _sprite in _sprites)
            {
                if (_sprite is Hero)
                {
                    Hero _hero = _sprite as Hero;
                    _hero.HasDied=_hero.HasWon = false;
                    _hero.Position = new Vector2(66, 546);
                    _hero.NbrOfCollectedItems = 0;
                }
                if (_sprite is Collectable)
                {
                    Collectable _collectable = _sprite as Collectable;
                    _collectable.IsCollected = false;
                }
                if(_sprite is Enemy)
                {
                    Enemy _enemy = _sprite as Enemy;
                    _enemy.HasDied = false;
                }
            }
            MediaPlayer.Play(_song);
        }
        #endregion

        #region Methods
        public override void Draw(GameTime gameTime, SpriteBatch spriteBatch)
        {
            
            Vector2 PlayerPosition = new Vector2(_sprites[0].Rectangle.X + (_sprites[0].Rectangle.Width / 2) - 400,0);
            var _viewMatrix = _camera.GetViewMatrix(PlayerPosition);
            spriteBatch.Begin(transformMatrix: _viewMatrix);
            foreach (var sprite in _sprites)
            {
                if (sprite is Collectable)
                {
                    Collectable _collectable = sprite as Collectable;
                    if (!_collectable.IsCollected)
                        _collectable.Draw(spriteBatch);
                    //else
                       // _nbrOfCollectedItems++;
                }
                else if (sprite is Enemy)
                {
                    Enemy _enemy = sprite as Enemy;
                    if (!_enemy.HasDied)
                        _enemy.Draw(spriteBatch);
                    //else
                    // _nbrOfCollectedItems++;
                }
                else
                sprite.Draw(spriteBatch);
            }

            spriteBatch.End();
        }

        public override void PostUpdate(GameTime gameTime)
        {
        }

        public override void Update(GameTime gameTime)
        {
            foreach (var sprite in _sprites)
            {

                sprite.Update(gameTime, _sprites);
                if (sprite is Hero)
                {
                    Hero yondu = sprite as Hero;
                    if (yondu.HasDied)
                    {
                        HeroDied = true;
                        _game.ChangeState(new DeathState(_content, _graphicsDevice, _game));
                    }
                    if (yondu.HasWon)
                    {
                        _game.ChangeState(new VictoryState(_content, _graphicsDevice, _game,yondu.NbrOfCollectedItems));
                    }
                }
            }
        }
        #endregion
    }
}

