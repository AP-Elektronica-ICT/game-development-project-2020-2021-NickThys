using Guardians_of_the_galaxy.Components;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Text;

namespace Guardians_of_the_galaxy.States
{
    class VictoryState:State
    {
        #region Fields
        private List<IComponent> _components;
        private int _collectedItems,_positionStars,_positionBtns;
        #endregion

        #region Constructor
        public VictoryState( Game1 _game, int _CollectedItems) : base(  _game)
        {
            this._collectedItems = _CollectedItems;
           
            #region Load Content
            Texture2D _nextLevelBtnTexture = Globals.ContentLoader.Load<Texture2D>("Buttons/Play_BTN");
            Texture2D _exitBtnTexture = Globals.ContentLoader.Load<Texture2D>("Buttons/Close_BTN");
            Texture2D _replayBtnTexture = Globals.ContentLoader.Load<Texture2D>("Buttons/Replay_BTN");
            Texture2D _headerTexture = Globals.ContentLoader.Load<Texture2D>("Headers/WonHeader");
            Texture2D _emptyStarTexture = Globals.ContentLoader.Load<Texture2D>("Score/Star_empty");
            Texture2D _goldStarTexture = Globals.ContentLoader.Load<Texture2D>("Score/Star_filled");
            #endregion
    
            #region Assing value to the fields
            _positionStars = (int)(Globals.WindowHeight* (1.0 / 4)) - _emptyStarTexture.Height / 2+10;
            _positionBtns = (int)(Globals.WindowHeight* (3.0/4)) - _nextLevelBtnTexture.Height / 2+50;
            #endregion
    
            #region Create Compontents
            #region Buttons
            button _replayLevelBtn = new button(_replayBtnTexture)
            {
                Position = new Vector2((int)(Globals.WindowWidth * (1.5 /6)) - _replayBtnTexture.Width / 2, _positionBtns),
            };
            _replayLevelBtn.Click += _replayLevelBtn_Click;
            button _nextLevelBtn = new button(_nextLevelBtnTexture)
            {
                Position = new Vector2((int)(Globals.WindowWidth * (3.0 / 6)) - _nextLevelBtnTexture.Width / 2, _positionBtns),
            };
            _nextLevelBtn.Click += _nextLevelBtn_Click;
            button _exitBtn = new button(_exitBtnTexture)
            {
                Position = new Vector2((int)(Globals.WindowWidth * (4.5 / 6)) - _nextLevelBtnTexture.Width / 2, _positionBtns),

            };
            _exitBtn.Click += _exitBtn_Click;
          
            
            #endregion
            
            #region Header
            Header _victoryHeader = new Header(_headerTexture)
            {
                Position = new Vector2(Globals.WindowWidth / 2 - _headerTexture.Width / 2, Globals.WindowHeight / 2 - _headerTexture.Height / 2 + 50),

        };
            #endregion

            #region Score
            Star _firstStar = new Star(_emptyStarTexture)
            {
                Position = new Vector2((int)(Globals.WindowWidth / 1.2 - _emptyStarTexture.Width / 2 -50), _positionStars),
            };
            Star _secondStar = new Star(_emptyStarTexture)
            {
                Position = new Vector2(Globals.WindowWidth / 2 - _emptyStarTexture.Width / 2, _positionStars-50),
            };
            Star _thirdStar = new Star(_emptyStarTexture)
            {
                Position = new Vector2(Globals.WindowWidth / 6 - _emptyStarTexture.Width / 2+50, _positionStars),
            };
            #endregion

            #endregion

            #region Add components to the list
            _components = new List<IComponent>()
            {
                _replayLevelBtn,
                _nextLevelBtn,
                _exitBtn,
                _victoryHeader,
                _secondStar,
                _thirdStar,
                _firstStar,
            };
            int i = 1;
            //Show number of collected stars
            foreach (IComponent _component  in _components)
            {
                if (_component is Star && i<=_collectedItems)
                {
                    Star _star = _component as Star;
                    _star.StarTexture = _goldStarTexture;
                    i++;
                }
            }
            #endregion
        }

        #endregion

        #region On click handlers
        private void _replayLevelBtn_Click(object sender, EventArgs e)
        {
            Globals.StateManager.ChangeState(new GameState( _game));
        }

        private void _exitBtn_Click(object sender, EventArgs e)
        {
            _game.Exit();
        }

        private void _nextLevelBtn_Click(object sender, EventArgs e)
        {
            Globals.CurrentLevel++;
            if (Globals.CurrentLevel != 3)
            {
                Globals.StateManager.ChangeState(new GameState( _game));
            }
            else
            {
                //End game state
            }

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
        }
        #endregion
    }
}
