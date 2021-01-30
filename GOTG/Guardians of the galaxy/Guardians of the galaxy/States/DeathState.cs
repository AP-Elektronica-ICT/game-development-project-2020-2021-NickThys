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
   

        #region Constructor
        public DeathState(Game1 _game) : base(_game)
        {
            #region Load Content
            Texture2D _restartBtnTexture = Globals.ContentLoader.Load<Texture2D>("Buttons/Replay_BTN");
            Texture2D _exitBtnTexture = Globals.ContentLoader.Load<Texture2D>("Buttons/Close_BTN");
            Texture2D _headerTexture = Globals.ContentLoader.Load<Texture2D>("Headers/LostHeader");
            #endregion
            #region Create buttons & header
            button _reStartBtn = new button(_restartBtnTexture)
            {
                Position = new Vector2(Globals.WindowWidth / 3 - _restartBtnTexture.Width / 2, Globals.WindowHeight / 3 + _restartBtnTexture.Height / 2),
            };
            _reStartBtn.Click += _reStartBtn_Click;
            button _exitBtn = new button(_exitBtnTexture)
            {
                Position = new Vector2(Globals.WindowWidth / 3 * 2 - _restartBtnTexture.Width / 2, Globals.WindowHeight / 3 + _restartBtnTexture.Height / 2),

            };
            _exitBtn.Click += _exitBtn_Click;

            Header _deathHeader = new Header(_headerTexture)
            {
                Position = new Vector2(Globals.WindowWidth / 2 - _headerTexture.Width / 2, Globals.WindowHeight / 6 + _headerTexture.Height / 2),
            };
            #endregion
            #region Add buttons to the list
            Components = new List<IComponent>()
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
            Globals.StateManager.ChangeState(new GameState(_game));
        }
        #endregion 

      
    }
}
