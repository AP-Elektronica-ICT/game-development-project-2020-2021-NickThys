using Microsoft.Xna.Framework.Media;
using System;
using System.Collections.Generic;
using System.Text;

namespace Guardians_of_the_galaxy.Music
{
    public class MusicPlayer
    {
        #region Fields
        private Song _currentSong;
        #endregion
        #region Constructor
        public MusicPlayer()
        {
            MediaPlayer.Volume = Globals.Volume;
            MediaPlayer.IsRepeating = true;
            MediaPlayer.Volume = 1f;
        }
        #endregion
        #region Methodes
        public void PlaySong(Song song)
        {
            if (!MediaPlayer.Equals(_currentSong, song))
            {
                MediaPlayer.Play(song);
                _currentSong = song;
            }
        }
        public void Update()
        {
            if (Globals.MusicIsPlaying)
                MediaPlayer.Volume = Globals.Volume;
            else
                MediaPlayer.Volume = 0f;
        } 
        #endregion
    }
}
