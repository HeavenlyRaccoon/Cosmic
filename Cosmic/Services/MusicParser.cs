using AngleSharp;
using Cosmic.Models;
using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using WMPLib;

namespace Cosmic.Services
{
    static class MusicParser
    {
        private const string NodeUrl = "https://mp3trip.info";

        //For mp3trip
        public async static Task<List<MusicItem>> GetMusicItems(string source)
        {
            List<MusicItem> musicItems = new List<MusicItem>(45);
            var config = Configuration.Default;
            var context = BrowsingContext.New(config);
            var document = await context.OpenAsync(req => req.Content(source));
            var tracks = document.GetElementsByClassName("track-item");
            foreach(var track in tracks)
            {
                MusicItem musicItem = new MusicItem();
                musicItem.Title = track.GetAttribute("data-title");
                musicItem.Artist = track.GetAttribute("data-artist");
                musicItem.TrackTime = track.GetElementsByClassName("track-time")[0].TextContent;
                musicItem.ImgData = NodeUrl + track.GetAttribute("data-img");
                musicItem.MusicData = NodeUrl + track.GetAttribute("data-track");
                musicItems.Add(musicItem);
            }

            return musicItems;
        }

        //For megapesni.com
        public async static Task<List<MusicItem>> GetDayMusicItems(string source)
        {
            List<MusicItem> musicItems = new List<MusicItem>();
            var config = Configuration.Default;
            var context = BrowsingContext.New(config);
            var document = await context.OpenAsync(req => req.Content(source));
            var tracks = document.GetElementsByClassName("playlist__item");
            foreach (var track in tracks)
            {
                MusicItem musicItem = new MusicItem();
                musicItem.Title = track.GetElementsByClassName("playlist__heading").First().GetElementsByTagName("a").Last().TextContent;
                musicItem.Artist = track.GetElementsByClassName("playlist__heading").First().GetElementsByTagName("a").First().TextContent;
                musicItem.ImgData = "https://www.pngkey.com/png/full/120-1205949_dj-record-png-graphic-freeuse-library-circle.png";
                musicItem.MusicData =$"https://musify.club{track.GetElementsByClassName("playlist__control play").First().GetAttribute("data-url")}";
                musicItem.TrackTime = track.GetElementsByClassName("text-muted")[1].TextContent;
                musicItems.Add(musicItem);
            }
            return musicItems;
        }

        public static string GetRequest(string url)
        {
            using (var webClient = new WebClient())
            {
                var response = webClient.DownloadData(url);
                return System.Text.Encoding.UTF8.GetString(response);
            }
        }

        public static string PostRequest(string url, NameValueCollection valueCollection)
        {
            using (var webClient = new WebClient())
            { 
                var response = webClient.UploadValues(url, valueCollection);
                return System.Text.Encoding.UTF8.GetString(response);
            }
        }

        public static List<MusicItem> Playlist(string url)
        {
            List<MusicItem> musicItems = new List<MusicItem>();
            string source = GetRequest(url);
            musicItems = GetMusicItems(source).Result;
            return musicItems;
        }
        public static List<MusicItem> DayPlaylist(string url)
        {
            List<MusicItem> musicItems = new List<MusicItem>();
            string source = GetRequest(url);
            musicItems = GetDayMusicItems(source).Result;
            return musicItems;
        }

        public static List<MusicItem> Search(string text)
        {
            NameValueCollection valueCollection = new NameValueCollection();
            valueCollection.Add("do", "search");
            valueCollection.Add("subaction", "search");
            valueCollection.Add("story", text);
            string source = PostRequest(NodeUrl + '/', valueCollection);
            List<MusicItem> musicItems = GetMusicItems(source).Result;
            return musicItems;
        }

        public static bool ConnectionAvailable()
        {
            try
            {
                HttpWebRequest reqFP = (HttpWebRequest)HttpWebRequest.Create("http://www.google.com");

                HttpWebResponse rspFP = (HttpWebResponse)reqFP.GetResponse();
                if (HttpStatusCode.OK == rspFP.StatusCode)
                {
                    rspFP.Close();
                    return true;
                }
                else
                {
                    rspFP.Close();
                    return false;
                }
            }
            catch (WebException)
            {
                return false;
            }
        }
    }
}
