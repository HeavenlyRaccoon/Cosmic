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

        public async void Pars(TextBox textBlock)
        {
            string url = "https://mp3trip.info/";
            using (var webClient = new WebClient())
            {
                var pars = new NameValueCollection();

                pars.Add("do", "search");
                pars.Add("subaction", "search");
                pars.Add("story", "Талия");

                var response = webClient.UploadValues(url, pars);
                string source = System.Text.Encoding.UTF8.GetString(response);

                var config = Configuration.Default;
                var context = BrowsingContext.New(config);
                var document = await context.OpenAsync(req => req.Content(source));
                var elements = document.GetElementsByClassName("track-item");
                textBlock.Text = elements[5].GetAttribute("data-track");
                Play(textBlock);
            }
        }
    }
}
