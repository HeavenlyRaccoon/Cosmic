using Cosmic.Infastructure.Commands;
using Cosmic.Models;
using Cosmic.Services;
using Cosmic.ViewModels.Base;
using Cosmic.Views.Pages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;

namespace Cosmic.ViewModels
{
    class PagesView: ViewModelBase
    {
        #region Хиты 2021

        private static List<MusicItem> _Hit2021;
        public List<MusicItem> Hit2021
        {
            get => _Hit2021;
        }


        #endregion
        #region Tik Tok 2021

        private static List<MusicItem> _TikTok;
        public List<MusicItem> TikTok
        {
            get => _TikTok;
        }


        #endregion
        #region Новая Музыка

        private static List<MusicItem> _NewMusic;
        public List<MusicItem> NewMusic
        {
            get => _NewMusic;
        }
        #endregion
        #region Популярная музыка

        private static List<MusicItem> _PopularMusic;
        public List<MusicItem> PopularMusic
        {
            get => _PopularMusic;
        }
        #endregion
        #region Страница Новинки

        private static List<MusicItem> _NewMusicPage;
        public List<MusicItem> NewMusicPage
        {
            get => _NewMusicPage;
        }
        #endregion
        #region Страница Наш Чарт

        private static List<MusicItem> _TopPage;
        public List<MusicItem> TopPage
        {
            get => _TopPage;
        }
        #endregion
        #region Страница Хиты 2021

        private static List<MusicItem> _Hit2021Page;
        public List<MusicItem> Hit2021Page
        {
            get => _Hit2021Page;
        }
        #endregion
        #region Страница Хиты 2020

        private static List<MusicItem> _Hit2020Page;
        public List<MusicItem> Hit2020Page
        {
            get => _Hit2020Page;
        }
        #endregion
        #region Страница Хиты 2019

        private static List<MusicItem> _Hit2019Page;
        public List<MusicItem> Hit2019Page
        {
            get => _Hit2019Page;
        }
        #endregion
        #region Страница Хиты 2018

        private static List<MusicItem> _Hit2018Page;
        public List<MusicItem> Hit2018Page
        {
            get => _Hit2018Page;
        }
        #endregion
        #region Страница Хиты 2017

        private static List<MusicItem> _Hit2017Page;
        public List<MusicItem> Hit2017Page
        {
            get => _Hit2017Page;
        }
        #endregion
        #region Страница Клубная музыка

        private static List<MusicItem> _ClubMusicPage;
        public List<MusicItem> ClubMusicPage
        {
            get => _ClubMusicPage;
        }
        #endregion
        #region Страница Музыка в машину

        private static List<MusicItem> _CarMusicPage;
        public List<MusicItem> CarMusicPage
        {
            get => _CarMusicPage;
        }
        #endregion
        #region Страница Музыка из аниме

        private static List<MusicItem> _AnimeMusicPage;
        public List<MusicItem> AnimeMusicPage
        {
            get => _AnimeMusicPage;
        }
        #endregion
        #region Страница Музыка Тик Ток

        private static List<MusicItem> _TikTokMusicPage;
        public List<MusicItem> TikTokMusicPage
        {
            get => _TikTokMusicPage;
        }
        #endregion
        #region Страница Русский рэп

        private static List<MusicItem> _RussianRapPage;
        public List<MusicItem> RussianRapPage
        {
            get => _RussianRapPage;
        }
        #endregion
        #region Страница Новогодние

        private static List<MusicItem> _NewYearPage;
        public List<MusicItem> NewYearPage
        {
            get => _NewYearPage;
        }
        #endregion
        #region Страница Зарубежный рок

        private static List<MusicItem> _ForeignRockPage;
        public List<MusicItem> ForeignRockPage
        {
            get => _ForeignRockPage;
        }
        #endregion
        #region Страница Русский поп

        private static List<MusicItem> _RussianPopPage;
        public List<MusicItem> RussianPopPage
        {
            get => _RussianPopPage;
        }
        #endregion
        #region Страница Зарубежный рэп

        private static List<MusicItem> _ForeignRapPage;
        public List<MusicItem> ForeignRapPage
        {
            get => _ForeignRapPage;
        }
        #endregion
        #region Страница Зарубежный поп

        private static List<MusicItem> _ForeignPopPage;
        public List<MusicItem> ForeignPopPage
        {
            get => _ForeignPopPage;
        }
        #endregion
        #region Страница Дискотека 80-90ых

        private static List<MusicItem> _OldMusicPage;
        public List<MusicItem> OldMusicPage
        {
            get => _OldMusicPage;
        }
        #endregion
        #region Страница Топ Shazam

        private static List<MusicItem> _ShazamPage;
        public List<MusicItem> ShazamPage
        {
            get => _ShazamPage;
        }
        #endregion

        #region MusicItem

        private static MusicItem _MusicItem;
        public MusicItem MusicItem
        {
            get => _MusicItem;
            set => Set(ref _MusicItem, value);
        }


        #endregion
        #region Response

        private static List<MusicItem> _Response = new List<MusicItem>();
        public List<MusicItem> Response
        {
            get => _Response;
            set => Set(ref _Response, value);
        }


        #endregion
        #region ResponseInfo

        private static string _ResponseInfo;
        public string ResponseInfo
        {
            get => _ResponseInfo;
            set => Set(ref _ResponseInfo, value);
        }

        #endregion

        #region OpenHit2021PageCommand
        public ICommand OpenHit2021PageCommand { get; }

        private void OnOpenHit2021PageCommandExecuted(object p)
        {
            var context = (MainWindowViewModel)((Window)Application.Current.MainWindow).DataContext;
            context.OpenHit2021PageCommand.Execute(p);
        }

        private bool CanOpenHit2021PageCommandExecute(object p) => true;
        #endregion
        #region OpenTikTokMusicPageCommand
        public ICommand OpenTikTokMusicPageCommand { get; }

        private void OnOpenTikTokMusicPageCommandExecuted(object p)
        {
            var context = (MainWindowViewModel)((Window)Application.Current.MainWindow).DataContext;
            context.OpenTikTokMusicPageCommand.Execute(p);
        }

        private bool CanOpenTikTokMusicPageCommandExecute(object p) => true;
        #endregion
        #region OpenNewMusicPageCommand
        public ICommand OpenNewMusicPageCommand { get; }

        private void OnOpenNewMusicPageCommandExecuted(object p)
        {
            var context = (MainWindowViewModel)((Window)Application.Current.MainWindow).DataContext;
            context.OpenNewMusicPageCommand.Execute(p);
        }

        private bool CanOpenNewMusicPageCommandExecute(object p) => true;
        #endregion
        #region OpenTopMusicPageCommand
        public ICommand OpenTopMusicPageCommand { get; }

        private void OnOpenTopMusicPageCommandExecuted(object p)
        {
            var context = (MainWindowViewModel)((Window)Application.Current.MainWindow).DataContext;
            context.OpenTopMusicPageCommand.Execute(p);
        }

        private bool CanOpenTopMusicPageCommandExecute(object p) => true;
        #endregion
        #region PlayMusicCommand
        public ICommand PlayMusicCommand { get; }

        private void OnPlayMusicCommandExecuted(object p)
        {
            var context = (MainWindowViewModel)((Window)Application.Current.MainWindow).DataContext;
            context.Popup = false;
            context.Popup = true;
            context.MusicItem = (MusicItem)p;

        }

        private bool CanPlayMusicCommandExecute(object p) => true;
        #endregion


        public PagesView()
        {
            OpenHit2021PageCommand = new LamdaCommand(OnOpenHit2021PageCommandExecuted, CanOpenHit2021PageCommandExecute);
            OpenTikTokMusicPageCommand = new LamdaCommand(OnOpenTikTokMusicPageCommandExecuted, CanOpenTikTokMusicPageCommandExecute);
            OpenNewMusicPageCommand = new LamdaCommand(OnOpenNewMusicPageCommandExecuted, CanOpenNewMusicPageCommandExecute);
            OpenTopMusicPageCommand = new LamdaCommand(OnOpenTopMusicPageCommandExecuted, CanOpenTopMusicPageCommandExecute);
            PlayMusicCommand = new LamdaCommand(OnPlayMusicCommandExecuted, CanPlayMusicCommandExecute);
        }

        static PagesView()
        {
            _Hit2021 = MusicParser.Playlist("https://mp3trip.info/muzykalnye-hity-2021/").GetRange(0, 5);
            _TikTok = MusicParser.Playlist("https://mp3trip.info/muzyka-iz-tik-tok/").GetRange(0, 5);
            _NewMusic = MusicParser.Playlist("https://mp3trip.info/novye-postuplenija-mp3/").GetRange(0, 13);
            _PopularMusic = MusicParser.Playlist("https://mp3trip.info/populyarnye/").GetRange(0, 13);
            _NewMusicPage = MusicParser.Playlist("https://mp3trip.info/novye-postuplenija-mp3/").GetRange(0, 45);
            _TopPage = MusicParser.Playlist("https://mp3trip.info/populyarnye/").GetRange(0, 45);
            _Hit2021Page = MusicParser.Playlist("https://mp3trip.info/muzykalnye-hity-2021/").GetRange(0, 45);
            _Hit2020Page = MusicParser.Playlist("https://mp3trip.info/muzykalnye-hity-2020/").GetRange(0, 45);
            _Hit2019Page = MusicParser.Playlist("https://mp3trip.info/hity-2019/").GetRange(0, 45);
            _Hit2018Page = MusicParser.Playlist("https://mp3trip.info/hity-2018/").GetRange(0, 45);
            _Hit2017Page = MusicParser.Playlist("https://mp3trip.info/hity-2017/").GetRange(0, 45);
            _ClubMusicPage = MusicParser.Playlist("https://mp3trip.info/klubnaya-muzyka/").GetRange(0, 45);
            _CarMusicPage = MusicParser.Playlist("https://mp3trip.info/muzyka-v-mashinu/").GetRange(0, 45);
            _AnimeMusicPage = MusicParser.Playlist("https://mp3trip.info/muzyka-iz-anime/").GetRange(0, 45);
            _TikTokMusicPage = MusicParser.Playlist("https://mp3trip.info/muzyka-iz-tik-tok/").GetRange(0, 45);
            _RussianRapPage = MusicParser.Playlist("https://mp3trip.info/russkiy-rep/").GetRange(0, 45);
            _NewYearPage = MusicParser.Playlist("https://mp3trip.info/novogodnie-pesni-2019-2020/").GetRange(0, 45);
            _ForeignRockPage = MusicParser.Playlist("https://mp3trip.info/zarubezhnyy-rok/").GetRange(0, 45);
            _RussianPopPage = MusicParser.Playlist("https://mp3trip.info/russkiy-pop/").GetRange(0, 45);
            _ForeignRapPage = MusicParser.Playlist("https://mp3trip.info/zarubezhnyy-rep/").GetRange(0, 45);
            _ForeignPopPage = MusicParser.Playlist("https://mp3trip.info/zarubezhnyy-pop/").GetRange(0, 45);
            _OldMusicPage = MusicParser.Playlist("https://mp3trip.info/diskoteka-80-90x/").GetRange(0, 45);
            _ShazamPage = MusicParser.Playlist("https://mp3trip.info/top-100-shazam/").GetRange(0, 45);
        }
    }
}
