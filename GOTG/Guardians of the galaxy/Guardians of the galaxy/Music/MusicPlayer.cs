using Microsoft.Xna.Framework.Media;
using System;
using System.Collections.Generic;
using System.Text;

namespace Guardians_of_the_galaxy.Music
{
    public class MusicPlayer
    {
        public MusicPlayer()
        {
            MediaPlayer.Volume = Globals.Volume;
            MediaPlayer.IsRepeating = true;
            MediaPlayer.Volume = 0.15f;
        }
        public void PlaySong(Song song)
        {
            MediaPlayer.Play(song);
        }
        public void Update()
        {
            if (Globals.MusicIsPlaying)
                MediaPlayer.Volume = Globals.Volume;
            else
                MediaPlayer.Volume = 0f;

        }
    }
}
