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
        private button _newGameButton, _exitButton, _soundButton;
        private Texture2D _startButttonTexture, _endButttonTexture;
        #endregion

        #region Constructor
        public MenuState(Game1 game) : base(game)
        {
            _startButttonTexture = Globals.ContentLoader.Load<Texture2D>("Buttons/Start_BTN");
            _endButttonTexture = Globals.ContentLoader.Load<Texture2D>("Buttons/Exit_BTN");


            #region StartGameButton
            _newGameButton = new RegularButton(_startButttonTexture, new Vector2(Globals.WindowWidth / 2 - _startButttonTexture.Width / 2, Globals.WindowHeight / 2 - _startButttonTexture.Height)) { };
            _newGameButton.Click += NewGameButton_Click; 
            #endregion

            #region ExitButton
            _exitButton = new RegularButton(_endButttonTexture, new Vector2(Globals.WindowWidth / 2 - _endButttonTexture.Width / 2, Globals.WindowHeight / 2 + _endButttonTexture.Height / 2)) { };
            _exitButton.Click += ExitButton_Click;
            #endregion

            #region SoundButton
            _soundButton = new SoundButton() { };
            _soundButton.Click += _soundButton_Click;
            #endregion

            Components = new List<IComponent>()
            {
                _newGameButton,
                _exitButton,
                _soundButton
            };
            Globals.MusicPlayer.PlaySong(Globals.MainTheme);
        }


        #endregion

        #region On click handlers
        private void ExitButton_Click(object sender, EventArgs e)
        {
            _game.Exit();
        }
        private void NewGameButton_Click(object sender, EventArgs e)
        {
            Globals.StateManager.ChangeState(new GameState(_game));
        }
        private void _soundButton_Click(object sender, EventArgs e)
        {
            Globals.MusicIsPlaying = !Globals.MusicIsPlaying;

        }
        #endregion
    }
}
