using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.IO;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using AngleSharp;
using AngleSharp.Html.Parser;

namespace CosmicWPFTest
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            //string url = "https://m.mp3ha.org/search/%D0%BC%D1%83%D0%BA%D0%BA%D0%B0%20%D0%BF%D0%B8%D0%B6%D0%B0%D0%BC%D0%B0";
            //using (var webClient = new WebClient())
            //{
            //    var response = webClient.DownloadData(url);
            //    string str = System.Text.Encoding.UTF8.GetString(response);
            //    TextBlock1.Text = str;
            //}

            //Play(TextBlock1);
        }

        public static void Play(TextBox textBlock)
        {
            WMPLib.WindowsMediaPlayer wplayer = new WMPLib.WindowsMediaPlayer();
            string url = "https://mp3trip.info/"+textBlock.Text;
            wplayer.URL = url;
            wplayer.settings.volume = 2;
            wplayer.controls.play();
        }

        private void Button_Click1(object sender, RoutedEventArgs e)
        {
            Pars(TextBlock2);
        }

        public void Pars(TextBox textBlock)
        {

            List<MusicItem> musicItems = MusicParser.Search("Талия");
            textBlock.Text = musicItems[0].Title;
        }

        private async void Go(object sender, RoutedEventArgs e)
        {
            
        }
    }

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
            foreach (var track in tracks)
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
                var response = webClient.DownloadString(url);
                return response;
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

    class MusicItem
    {
        public string Title { get; set; }
        public string Artist { get; set; }
        public string TrackTime { get; set; }
        public string ImgData { get; set; }
        public string MusicData { get; set; }
    }
}
