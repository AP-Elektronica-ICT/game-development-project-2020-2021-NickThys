using Guardians_of_the_galaxy.Components;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Media;
using System;
using System.Collections.Generic;
using System.Text;

namespace Guardians_of_the_galaxy.States
{
    public class DeathState : State
    {
        #region Fields
        private List<Component> _components;
        private Song _levelSong;
        #endregion

        #region Constructor
        public DeathState(ContentManager _content, GraphicsDevice _graphicsDevice, Game1 _game) : base(_content, _graphicsDevice, _game)
        {
            #region Load Content
            Texture2D _restartBtnTexture = _content.Load<Texture2D>("Buttons/Replay_BTN");
            Texture2D _exitBtnTexture = _content.Load<Texture2D>("Buttons/Close_BTN");
            Texture2D _headerTexture = _content.Load<Texture2D>("Headers/LostHeader");
            #endregion
            #region Create buttons & header
            button _reStartBtn = new button(_restartBtnTexture)
            {
                Position = new Vector2(Globals.WindowWidth/3 - _restartBtnTexture.Width / 2, Globals.WindowHeight / 3 + _restartBtnTexture.Height/2),
            };
            _reStartBtn.Click += _reStartBtn_Click;
            button _exitBtn = new button(_exitBtnTexture)
            {
                Position = new Vector2(Globals.WindowWidth / 3*2 - _restartBtnTexture.Width / 2, Globals.WindowHeight / 3 + _restartBtnTexture.Height / 2),

            };
            _exitBtn.Click += _exitBtn_Click;

            Header _deathHeader = new Header(_headerTexture)
            {
                Position = new Vector2(Globals.WindowWidth / 2 - _headerTexture.Width / 2, Globals.WindowHeight / 6 + _headerTexture.Height / 2),

            };
            #endregion
            #region Add buttons to the list
            _components = new List<Component>()
            {
                _reStartBtn,
                _exitBtn,
                _deathHeader,
            };
            #endregion
        }
        #endregion
   
        #region On click handlers
        private void _exitBtn_Click(object sender, EventArgs e)
        {
            _game.Exit();
        }

        private void _reStartBtn_Click(object sender, EventArgs e)
        {

            switch (_game.LevelNr)
            {
                case 1:
                    _levelSong = _game.Song1;
                    break;
                case 2:
                    _levelSong = _game.Song2;
                    break;
               
            }
            _game.ChangeState(new GameState(_content, _graphicsDevice, _game,_game.Level,_levelSong));
        }
        #endregion 

        #region Methodes
        public override void Draw(GameTime _gameTime, SpriteBatch _spriteBatch)
        {
            _spriteBatch.Begin();
            foreach (var component in _components)
            {
                component.Draw(_gameTime, _spriteBatch);
            }
            _spriteBatch.End();
        }

        public override void PostUpdate(GameTime _gameTime)
        {
        }

        public override void Update(GameTime _gameTime)
        {
            foreach (var component in _components)
                component.Update(_gameTime);

        }
        #endregion
    }
}
