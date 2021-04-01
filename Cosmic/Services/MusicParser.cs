using AngleSharp;
using Cosmic.Models;
using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace Cosmic.Services
{
    static class MusicParser
    {
        private const string NodeUrl = "https://mp3trip.info";

        public async static Task<List<MusicItem>> GetMusicItems(string source)
        {
            List<MusicItem> musicItems = new List<MusicItem>();
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
            string source = GetRequest(url);
            List<MusicItem> musicItems = GetMusicItems(source).Result;
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
    }
}
