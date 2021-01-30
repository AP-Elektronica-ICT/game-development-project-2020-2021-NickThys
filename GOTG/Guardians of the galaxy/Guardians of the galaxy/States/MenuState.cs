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
        private List<IComponent> _components;
        private button _newGameButton, _exitButton, _soundButton;
        private Texture2D _startButttonTexture, _endButttonTexture, _soundButttonTexture, _activeSoundButttonTexture;
#endregion

        #region Constructor
        public MenuState( Game1 game) : base( game)
        {
             _startButttonTexture = Globals.ContentLoader.Load<Texture2D>("Buttons/Start_BTN");
             _endButttonTexture = Globals.ContentLoader.Load<Texture2D>("Buttons/Exit_BTN");
             _soundButttonTexture = Globals.ContentLoader.Load<Texture2D>("Buttons/Sound_BTN");
             _activeSoundButttonTexture = Globals.ContentLoader.Load<Texture2D>("Buttons/ActiveSound_BTN");

            _newGameButton = new button(_startButttonTexture)
            {
                Position=new Vector2(Globals.WindowWidth/2- _startButttonTexture.Width/2,
                                     Globals.WindowHeight/2- _startButttonTexture.Height)
            };
            _newGameButton.Click += NewGameButton_Click;
            _exitButton = new button(_endButttonTexture)
            {
                Position = new Vector2(Globals.WindowWidth/ 2 - _endButttonTexture.Width/2,
                                       Globals.WindowHeight/ 2 + _endButttonTexture.Height/2)
            };
            _exitButton.Click += ExitButton_Click;
            _soundButton = new button(_soundButttonTexture)
            {
                Position = new Vector2(50,50)
            };
            _soundButton.Click += _soundButton_Click;
           
            _components = new List<IComponent>()
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
            Globals.StateManager.ChangeState(new GameState( _game));
        }
        private void _soundButton_Click(object sender, EventArgs e)
        {
            Globals.MusicIsPlaying = !Globals.MusicIsPlaying;
        }
        #endregion

        #region Methodes
        public override void Draw(GameTime _gameTime)
        {
            Globals.SpriteBatch.Begin();
            foreach (var component in _components)
                component.Draw(_gameTime);
            Globals.SpriteBatch.End();
        }

   
        public override void Update(GameTime _gameTime)
        {
            foreach (var component in _components)
                component.Update(_gameTime);
            if (Globals.MusicIsPlaying)
                _soundButton.Texture = _activeSoundButttonTexture;
            else
                _soundButton.Texture = _soundButttonTexture;
        }
        #endregion

    }
}
