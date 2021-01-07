using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Text;
using Guardians_of_the_galaxy.Components;

namespace Guardians_of_the_galaxy.States
{
   public class MenuState : State
    {
        #region Fields
        private List<Component> _components;
        private button _newGameButton, _exitButton, _soundButton;
        private Texture2D _startButttonTexture, _endButttonTexture, _soundButttonTexture, _activeSoundButttonTexture;
        private SpriteFont _buttonFont;
#endregion

        #region Constructor
        public MenuState(ContentManager content, GraphicsDevice graphicsDevice, Game1 game) : base(content, graphicsDevice, game)
        {
             _startButttonTexture = _content.Load<Texture2D>("Buttons/Start_BTN");
             _endButttonTexture = _content.Load<Texture2D>("Buttons/Exit_BTN");
             _soundButttonTexture = _content.Load<Texture2D>("Buttons/Sound_BTN");
             _activeSoundButttonTexture = _content.Load<Texture2D>("Buttons/ActiveSound_BTN");
             _buttonFont = _content.Load<SpriteFont>("Font1");
            _newGameButton = new button(_startButttonTexture, _buttonFont)
            {
                Position=new Vector2(_game.windowWidth/2- _startButttonTexture.Width/2,
                                     _game.windowHeight/2- _startButttonTexture.Height),
                Text=""
            };
            _newGameButton.Click += NewGameButton_Click;
            _exitButton = new button(_endButttonTexture, _buttonFont)
            {
                Position = new Vector2(_game.windowWidth / 2 - _endButttonTexture.Width/2,
                                       _game.windowHeight / 2 + _endButttonTexture.Height/2),
                Text = ""
            };
            _exitButton.Click += ExitButton_Click;
            _soundButton = new button(_soundButttonTexture, _buttonFont)
            {
                Position = new Vector2(50,50),
                Text = "",
            };
            _soundButton.Click += _soundButton_Click;
           
            _components = new List<Component>()
            {
                _newGameButton,
                _exitButton,
                _soundButton
            };
        }


        #endregion

        #region On click handlers
        private void ExitButton_Click(object sender, EventArgs e)
        {
            _game.Exit();
        }

        private void NewGameButton_Click(object sender, EventArgs e)
        {
            _game.CreateLevel(_game.Level1,_game.TexturesLevel1);
            _game.ChangeState(new GameState(_content, _graphicsDevice, _game,_game.Level,_game.Song1));
        }
        private void _soundButton_Click(object sender, EventArgs e)
        {
            _game.MusicIsPlaying = !_game.MusicIsPlaying;
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
            if (_game.MusicIsPlaying)
                _soundButton.Texture = _activeSoundButttonTexture;
            else
                _soundButton.Texture = _soundButttonTexture;
        }
        #endregion

    }
}
