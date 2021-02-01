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
        private List<sprite> _sprites;
        private Camera _camera;
        private Song _song;
        #endregion

        #region Constructor    
        public GameState(Game1 game) : base(game)
        {
            switch (Globals.CurrentLevel)
            {
                case 1:
                    _sprites = Globals.SpritesLevel1;
                    _song = Globals.SongLevel1;
                    break;
                default:
                    _sprites = Globals.SpritesLevel2;
                    _song = Globals.SongLevel2;
                    break;
            }

            _camera = Globals.GameCamera;
            _game = game;
           foreach (sprite _sprite in _sprites)
            {
                if (_sprite is Hero)
                {
                    Hero _hero = _sprite as Hero;
                    _hero.HasDied = _hero.HasWon = false;
                    _hero.Position = new Vector2(66, 546);
                    _hero.NbrOfCollectedItems = 0;
                }
                if (_sprite is Collectable)
                {
                    Collectable _collectable = _sprite as Collectable;
                    _collectable.IsCollected = false;
                }
                if (_sprite is Enemy)
                {
                    Enemy _enemy = _sprite as Enemy;
                    _enemy.HasDied = false;
                }
            }
            Globals.MusicPlayer.PlaySong(_song);
        }
        #endregion

        #region Methods
        public override void Draw(GameTime gameTime)
        {

            Vector2 PlayerPosition = new Vector2(_sprites[0].CollisionRectangle.X + (_sprites[0].CollisionRectangle.Width / 2) - 400, 0);
            var _viewMatrix = _camera.GetViewMatrix(PlayerPosition);

            Globals.SpriteBatch.Begin(transformMatrix: _viewMatrix);
            foreach (var sprite in _sprites)
            {
                if (sprite is Collectable)
                {
                    Collectable _collectable = sprite as Collectable;
                    if (!_collectable.IsCollected)
                        _collectable.Draw();

                }
                else if (sprite is Enemy)
                {
                    Enemy _enemy = sprite as Enemy;
                    if (!_enemy.HasDied)
                        _enemy.Draw();
                }
                else
                    sprite.Draw();
            }

            Globals.SpriteBatch.End();
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
                        Globals.StateManager.ChangeState(new DeathState(_game));
                    }
                    if (yondu.HasWon)
                        Globals.StateManager.ChangeState(new VictoryState(_game, yondu.NbrOfCollectedItems));

                }
            }
        }
        #endregion
    }
}

