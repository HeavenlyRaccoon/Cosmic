using Cosmic.Infastructure.Commands;
using Cosmic.Models;
using Cosmic.Services;
using Cosmic.ViewModels.Base;
using Cosmic.Views.Pages;
using Cosmic.Views.Windows;
using System.Collections.Generic;
using System.Diagnostics;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media.Effects;

namespace Cosmic.ViewModels
{
    internal class MainWindowViewModel : ViewModelBase
    {
        #region Заголовок окна

        private string _Title = "Cosmic";
        public string Title 
        { 
            get=>_Title;
            set => Set(ref _Title, value);
        }

        #endregion

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
        #region FrameContent

        private Page _FrameContent;
        public Page FrameContent
        {
            get => _FrameContent;
            set => Set(ref _FrameContent, value);
        }
        #endregion

        #region Команды

        #region OpenAuthWindowCommand
        public ICommand OpenAuthWindowCommand { get; }

        private void OnOpenAuthWindowCommandExecuted(object p)
        {
            AuthWindow authWindow = new AuthWindow();
            BlurEffect blurEffect = new BlurEffect();
            blurEffect.Radius = 10;
            Application.Current.MainWindow.Effect = blurEffect;
            authWindow.ShowDialog();
        }

        private bool CanOpenAuthWindowCommandExecute(object p) => true;
        #endregion
        #region OpenLinkCommand
        public ICommand OpenLinkCommand { get; }

        private void OnOpenLinkCommandExecuted(object p)
        {
            Process.Start("https://vk.com/id210553771");
        }

        private bool CanOpenLinkCommandExecute(object p) => true;
        #endregion
        #region MinimizeWindowCommand
        public ICommand MinimizeWindowCommand { get; }

        private void OnMinimizeWindowCommandExecuted(object p)
        {
            Application.Current.MainWindow.WindowState = WindowState.Minimized;
        }

        private bool CanMinimizeWindowCommandExecute(object p) => true;
        #endregion
        #region MaximizeWindowCommand
        public ICommand MaximizeWindowCommand { get; }

        private void OnMaximizeWindowCommandExecuted(object p)
        {
            if (Application.Current.MainWindow.WindowState != WindowState.Maximized)
            {
                Application.Current.MainWindow.WindowState = WindowState.Maximized;
            }
            else
            {
                Application.Current.MainWindow.WindowState = WindowState.Normal;
            }
            
        }

        private bool CanMaximizeWindowCommandExecute(object p) => true;
        #endregion
        #region ShutDownCommand
        public ICommand ShutDownCommand { get; }

        private void OnShutDownCommandExecuted(object p)
        {
            Application.Current.Shutdown();
        }

        private bool CanShutDownCommandExecute(object p) => true;
        #endregion
        #region OpenNewMusicPageCommand
        public ICommand OpenNewMusicPageCommand { get; }

        private void OnOpenNewMusicPageCommandExecuted(object p)
        {
            FrameContent = new NewMusic();
        }

        private bool CanOpenNewMusicPageCommandExecute(object p) => true;
        #endregion
        #region OpenTopMusicPageCommand
        public ICommand OpenTopMusicPageCommand { get; }

        private void OnOpenTopMusicPageCommandExecuted(object p)
        {
            FrameContent = new TopMusic();
        }

        private bool CanOpenTopMusicPageCommandExecute(object p) => true;
        #endregion
        #region OpenHit2021PageCommand
        public ICommand OpenHit2021PageCommand { get; }

        private void OnOpenHit2021PageCommandExecuted(object p)
        {
            FrameContent = new Hit2021();
        }

        private bool CanOpenHit2021PageCommandExecute(object p) => true;
        #endregion
        #region OpenHit2020PageCommand
        public ICommand OpenHit2020PageCommand { get; }

        private void OnOpenHit2020PageCommandExecuted(object p)
        {
            FrameContent = new Hit2020();
        }

        private bool CanOpenHit2020PageCommandExecute(object p) => true;
        #endregion
        #region OpenHit2019PageCommand
        public ICommand OpenHit2019PageCommand { get; }

        private void OnOpenHit2019PageCommandExecuted(object p)
        {
            FrameContent = new Hit2019();
        }

        private bool CanOpenHit2019PageCommandExecute(object p) => true;
        #endregion
        #region OpenHit2018PageCommand
        public ICommand OpenHit2018PageCommand { get; }

        private void OnOpenHit2018PageCommandExecuted(object p)
        {
            FrameContent = new Hit2018();
        }

        private bool CanOpenHit2018PageCommandExecute(object p) => true;
        #endregion
        #region OpenHit2017PageCommand
        public ICommand OpenHit2017PageCommand { get; }

        private void OnOpenHit2017PageCommandExecuted(object p)
        {
            FrameContent = new Hit2017();
        }

        private bool CanOpenHit2017PageCommandExecute(object p) => true;
        #endregion
        #region OpenClubMusicPageCommand
        public ICommand OpenClubMusicPageCommand { get; }

        private void OnOpenClubMusicPageCommandExecuted(object p)
        {
            FrameContent = new ClubMusic();
        }

        private bool CanOpenClubMusicPageCommandExecute(object p) => true;
        #endregion
        #region OpenCarMusicPageCommand
        public ICommand OpenCarMusicPageCommand { get; }

        private void OnOpenCarMusicPageCommandExecuted(object p)
        {
            FrameContent = new CarMusic();
        }

        private bool CanOpenCarMusicPageCommandExecute(object p) => true;
        #endregion
        #region OpenAnimeMusicPageCommand
        public ICommand OpenAnimeMusicPageCommand { get; }

        private void OnOpenAnimeMusicPageCommandExecuted(object p)
        {
            FrameContent = new AnimeMusic();
        }

        private bool CanOpenAnimeMusicPageCommandExecute(object p) => true;
        #endregion
        #region OpenTikTokMusicPageCommand
        public ICommand OpenTikTokMusicPageCommand { get; }

        private void OnOpenTikTokMusicPageCommandExecuted(object p)
        {
            FrameContent = new TikTokMusic();
        }

        private bool CanOpenTikTokMusicPageCommandExecute(object p) => true;
        #endregion
        #region OpenRussianRapPageCommand
        public ICommand OpenRussianRapPageCommand { get; }

        private void OnOpenRussianRapPageCommandExecuted(object p)
        {
            FrameContent = new RussianRap();
        }

        private bool CanOpenRussianRapPageCommandExecute(object p) => true;
        #endregion
        #region OpenNewYearPageCommand
        public ICommand OpenNewYearPageCommand { get; }

        private void OnOpenNewYearPageCommandExecuted(object p)
        {
            FrameContent = new NewYear();
        }

        private bool CanOpenNewYearPageCommandExecute(object p) => true;
        #endregion
        #region OpenForeignRockPageCommand
        public ICommand OpenForeignRockPageCommand { get; }

        private void OnOpenForeignRockPageCommandExecuted(object p)
        {
            FrameContent = new ForeignRock();
        }

        private bool CanOpenForeignRockPageCommandExecute(object p) => true;
        #endregion
        #region OpenRussianPopPageCommand
        public ICommand OpenRussianPopPageCommand { get; }

        private void OnOpenRussianPopPageCommandExecuted(object p)
        {
            FrameContent = new RussianPop();
        }

        private bool CanOpenRussianPopPageCommandExecute(object p) => true;
        #endregion
        #region OpenForeignRapPageCommand
        public ICommand OpenForeignRapPageCommand { get; }

        private void OnOpenForeignRapPageCommandExecuted(object p)
        {
            FrameContent = new ForeignRap();
        }

        private bool CanOpenForeignRapPageCommandExecute(object p) => true;
        #endregion
        #region OpenForeignPopPageCommand
        public ICommand OpenForeignPopPageCommand { get; }

        private void OnOpenForeignPopPageCommandExecuted(object p)
        {
            FrameContent = new ForeignPop();
        }

        private bool CanOpenForeignPopPageCommandExecute(object p) => true;
        #endregion
        #region OpenOldMusicPageCommand
        public ICommand OpenOldMusicPageCommand { get; }

        private void OnOpenOldMusicPageCommandExecuted(object p)
        {
            FrameContent = new OldMusic();
        }

        private bool CanOpenOldMusicPageCommandExecute(object p) => true;
        #endregion
        #region OpenShazamPageCommand
        public ICommand OpenShazamPageCommand { get; }

        private void OnOpenShazamPageCommandExecuted(object p)
        {
            FrameContent = new Shazam();
        }

        private bool CanOpenShazamPageCommandExecute(object p) => true;
        #endregion
        #region OpenMainPageCommand
        public ICommand OpenMainPageCommand { get; }

        private void OnOpenMainPageCommandExecuted(object p)
        {
            FrameContent = new MainPage();
        }

        private bool CanOpenMainPageCommandExecute(object p) => true;
        #endregion

        #endregion
        public MainWindowViewModel()
        {
            #region Команды
            OpenAuthWindowCommand = new LamdaCommand(OnOpenAuthWindowCommandExecuted, CanOpenAuthWindowCommandExecute);
            OpenLinkCommand = new LamdaCommand(OnOpenLinkCommandExecuted, CanOpenLinkCommandExecute);
            MinimizeWindowCommand = new LamdaCommand(OnMinimizeWindowCommandExecuted, CanMinimizeWindowCommandExecute);
            MaximizeWindowCommand = new LamdaCommand(OnMaximizeWindowCommandExecuted, CanMaximizeWindowCommandExecute);
            ShutDownCommand = new LamdaCommand(OnShutDownCommandExecuted, CanShutDownCommandExecute);
            OpenMainPageCommand = new LamdaCommand(OnOpenMainPageCommandExecuted, CanOpenMainPageCommandExecute);
            OpenNewMusicPageCommand = new LamdaCommand(OnOpenNewMusicPageCommandExecuted, CanOpenNewMusicPageCommandExecute);
            OpenTopMusicPageCommand = new LamdaCommand(OnOpenTopMusicPageCommandExecuted, CanOpenTopMusicPageCommandExecute);
            OpenHit2021PageCommand = new LamdaCommand(OnOpenHit2021PageCommandExecuted, CanOpenHit2021PageCommandExecute);
            OpenHit2020PageCommand = new LamdaCommand(OnOpenHit2020PageCommandExecuted, CanOpenHit2020PageCommandExecute);
            OpenHit2019PageCommand = new LamdaCommand(OnOpenHit2019PageCommandExecuted, CanOpenHit2019PageCommandExecute);
            OpenHit2018PageCommand = new LamdaCommand(OnOpenHit2018PageCommandExecuted, CanOpenHit2018PageCommandExecute);
            OpenHit2017PageCommand = new LamdaCommand(OnOpenHit2017PageCommandExecuted, CanOpenHit2017PageCommandExecute);
            OpenClubMusicPageCommand = new LamdaCommand(OnOpenClubMusicPageCommandExecuted, CanOpenClubMusicPageCommandExecute);
            OpenCarMusicPageCommand = new LamdaCommand(OnOpenCarMusicPageCommandExecuted, CanOpenCarMusicPageCommandExecute);
            OpenAnimeMusicPageCommand = new LamdaCommand(OnOpenAnimeMusicPageCommandExecuted, CanOpenAnimeMusicPageCommandExecute);
            OpenTikTokMusicPageCommand = new LamdaCommand(OnOpenTikTokMusicPageCommandExecuted, CanOpenTikTokMusicPageCommandExecute);
            OpenRussianRapPageCommand = new LamdaCommand(OnOpenRussianRapPageCommandExecuted, CanOpenRussianRapPageCommandExecute);
            OpenNewYearPageCommand = new LamdaCommand(OnOpenNewYearPageCommandExecuted, CanOpenNewYearPageCommandExecute);
            OpenForeignRockPageCommand = new LamdaCommand(OnOpenForeignRockPageCommandExecuted, CanOpenForeignRockPageCommandExecute);
            OpenRussianPopPageCommand = new LamdaCommand(OnOpenRussianPopPageCommandExecuted, CanOpenRussianPopPageCommandExecute);
            OpenForeignRapPageCommand = new LamdaCommand(OnOpenForeignRapPageCommandExecuted, CanOpenForeignRapPageCommandExecute);
            OpenForeignPopPageCommand = new LamdaCommand(OnOpenForeignPopPageCommandExecuted, CanOpenForeignPopPageCommandExecute);
            OpenOldMusicPageCommand = new LamdaCommand(OnOpenOldMusicPageCommandExecuted, CanOpenOldMusicPageCommandExecute);
            OpenShazamPageCommand = new LamdaCommand(OnOpenShazamPageCommandExecuted, CanOpenShazamPageCommandExecute);
            #endregion
        }

        static MainWindowViewModel()
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
