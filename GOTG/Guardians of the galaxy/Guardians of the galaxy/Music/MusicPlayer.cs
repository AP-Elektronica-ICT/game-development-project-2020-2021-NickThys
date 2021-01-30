using Microsoft.Xna.Framework.Media;
using System;
using System.Collections.Generic;
using System.Text;

namespace Guardians_of_the_galaxy.Music
{
    public class MusicPlayer
    {
        private Song _currentSong;
        public MusicPlayer()
        {
            MediaPlayer.Volume = Globals.Volume;
            MediaPlayer.IsRepeating = true;
            MediaPlayer.Volume = 1f;
        }
        public void PlaySong(Song song)
        {
            if (!MediaPlayer.Equals(_currentSong,song))
            {
                MediaPlayer.Play(song);
                _currentSong = song;
            }
        }
        public void Update()
        {
            if (Globals.MusicIsPlaying )
                MediaPlayer.Volume = Globals.Volume;
            else
                MediaPlayer.Volume = 0f;
        }
    }
}
