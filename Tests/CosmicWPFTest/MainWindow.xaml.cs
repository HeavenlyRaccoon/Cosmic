using SpotifyAPI.Web;
using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.ComponentModel;
using System.Linq;
using System.Media;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

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

            Prof(TextBlock1);
            //Task.WaitAll(Prof(TextBlock1));
        }

        public static async Task Prof(TextBox textBlock)
        {
            //var config = SpotifyClientConfig.CreateDefault();

            //var request = new ClientCredentialsRequest("e38f5549120e4f7885ed1472dc58adb6", "0e255d6f56d9433da52bfab4e8e3cf4b");
            //var response = new OAuthClient(config).RequestToken(request);
            //var spotify = new SpotifyClient(config.WithToken(response.Result.AccessToken));
            //// textBlock.Text = response.Id.ToString();
            //var song = await spotify.Search.Item(new SearchRequest(SearchRequest.Types.Track, "Талия"));
            //FullTrack track = new FullTrack();
            //var tracks = spotify.PaginateAll(song.Tracks, (s) => s.Tracks);
            //track = tracks.Result[0];
            //textBlock.Text = track.Uri;

            WMPLib.WindowsMediaPlayer wplayer = new WMPLib.WindowsMediaPlayer();
            wplayer.URL = "https://hotmo.org/get/music/20200223/MUKKA_Tri_dnya_dozhdya_-_Ne_Kiryajj_68502009.mp3";
            wplayer.settings.volume = 30;
            wplayer.controls.play();

        }


    }
}
