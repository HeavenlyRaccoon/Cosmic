using Cosmic.Models;
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
        public static void Play(List<MusicItem> items, MusicItem item)
        {
            List<MusicItem> musicItems = items;
            MusicItem musicItem = item;
            wplayer.currentPlaylist.clear();
            foreach(var i in musicItems)
            {
                wplayer.currentPlaylist.appendItem(wplayer.mediaCollection.add(i.MusicData));
            }
            Task.Factory.StartNew(() =>
            {
                for(int i = 0; i < wplayer.currentPlaylist.count; i++)
                {
                    if (wplayer.currentPlaylist.Item[i].sourceURL == musicItem.MusicData)
                    {
                        wplayer.controls.playItem(wplayer.currentPlaylist.Item[i]);
                        break;
                    }
                }
            });
        }

        public static void Play(string url)
        {
            Task.Factory.StartNew(() =>
            {
                wplayer.URL = url;
                wplayer.settings.volume = 50;
                wplayer.controls.play();
            });
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

        public static void Next()
        {
            wplayer.controls.next();
        }

        public static void Previous()
        {
            wplayer.controls.previous();
        }
    }
}
