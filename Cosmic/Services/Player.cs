using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cosmic.Services
{
    static class Player
    {
       public static WMPLib.WindowsMediaPlayer wplayer = new WMPLib.WindowsMediaPlayer();
        public static void Play(string url)
        {
            wplayer.URL = url;
            wplayer.settings.volume = 2;
            wplayer.controls.play();
        }

        public static void Pause()
        {
            wplayer.controls.pause();
        }
        public static void Resume()
        {
            wplayer.controls.play();
        }
        public static bool IsPlaying()
        {
            if ((int)wplayer.playState == 3)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}
