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
        private List<Component> _components;
        private int _collectedItems,_positionHeader,_positionStars,_positionBtns;
        #endregion

        #region Constructor
        public VictoryState(ContentManager _content, GraphicsDevice _graphicsDevice, Game1 _game, int _CollectedItems) : base(_content, _graphicsDevice, _game)
        {
            this._collectedItems = _CollectedItems;
           
            #region Load Content
            Texture2D _nextLevelBtnTexture = _content.Load<Texture2D>("Buttons/Play_BTN");
            Texture2D _exitBtnTexture = _content.Load<Texture2D>("Buttons/Close_BTN");
            Texture2D _replayBtnTexture = _content.Load<Texture2D>("Buttons/Replay_BTN");
            Texture2D _headerTexture = _content.Load<Texture2D>("Headers/WonHeader");
            Texture2D _emptyStarTexture = _content.Load<Texture2D>("Score/Star_empty");
            Texture2D _goldStarTexture = _content.Load<Texture2D>("Score/Star_filled");
            #endregion
    
            #region Assing value to the fields
            _positionHeader = _game.windowHeight / 2 - _headerTexture.Height / 2+50;
            _positionStars = (int)(_game.windowHeight * (1.0 / 4)) - _emptyStarTexture.Height / 2+10;
            _positionBtns = (int)(_game.windowHeight * (3.0/4)) - _nextLevelBtnTexture.Height / 2+50;
            #endregion
    
            #region Create Compontents
            #region Buttons
            button _replayLevelBtn = new button(_replayBtnTexture)
            {
                Position = new Vector2((int)(_game.windowWidth * (1.5 /6)) - _replayBtnTexture.Width / 2, _positionBtns),
            };
            _replayLevelBtn.Click += _replayLevelBtn_Click;
            button _nextLevelBtn = new button(_nextLevelBtnTexture)
            {
                Position = new Vector2((int)(_game.windowWidth * (3.0 / 6)) - _nextLevelBtnTexture.Width / 2, _positionBtns),
            };
            _nextLevelBtn.Click += _nextLevelBtn_Click;
            button _exitBtn = new button(_exitBtnTexture)
            {
                Position = new Vector2((int)(_game.windowWidth * (4.5 / 6)) - _nextLevelBtnTexture.Width / 2, _positionBtns),

            };
            _exitBtn.Click += _exitBtn_Click;
          
            
            #endregion
            
            #region Header
            Header _victoryHeader = new Header(_headerTexture)
            {
                Position = new Vector2(_game.windowWidth / 2 - _headerTexture.Width / 2,_positionHeader),

            };
            #endregion

            #region Score
            Star _firstStar = new Star(_emptyStarTexture)
            {
                Position = new Vector2((int)(_game.windowWidth / 1.2 - _emptyStarTexture.Width / 2 -50), _positionStars),
            };
            Star _secondStar = new Star(_emptyStarTexture)
            {
                Position = new Vector2(_game.windowWidth / 2 - _emptyStarTexture.Width / 2, _positionStars-50),
            };
            Star _thirdStar = new Star(_emptyStarTexture)
            {
                Position = new Vector2(_game.windowWidth / 6 - _emptyStarTexture.Width / 2+50, _positionStars),
            };
            #endregion

            #endregion

            #region Add components to the list
            _components = new List<Component>()
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
            foreach (Component _component  in _components)
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
            _game.ChangeState(new GameState(_content, _graphicsDevice, _game, _game.Level,_game.Song1));
        }

        private void _exitBtn_Click(object sender, EventArgs e)
        {
            _game.Exit();
        }

        private void _nextLevelBtn_Click(object sender, EventArgs e)
        {
            _game.CreateLevel(_game.Level2,_game.TexturesLevel2);
            _game.ChangeState(new GameState(_content, _graphicsDevice, _game, _game.Level,_game.Song2));
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
