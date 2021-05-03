﻿using Cosmic.Infastructure.Commands;
using Cosmic.Models;
using Cosmic.Services;
using Cosmic.ViewModels.Base;
using Cosmic.Views.Pages;
using Cosmic.Views.Windows;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
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

        #region Popup

        private static bool _Popup=false;
        public bool Popup
        {
            get => _Popup;
            set => Set(ref _Popup, value);
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
        #region CurrentPlaylist

        private static List<MusicItem> _CurrentPlaylist;
        public List<MusicItem> CurrentPlaylist
        {
            get => _CurrentPlaylist;
            set => Set(ref _CurrentPlaylist, value);
        }
        #endregion

        #region TrackTime

        private string _TrackTime;
        public string TrackTime
        {
            get => _TrackTime;
            set => Set(ref _TrackTime, value);
        }
        #endregion
        #region TrackProgress

        private double _TrackProgress;
        public double TrackProgress
        {
            get => _TrackProgress;
            set 
            {
                if (Math.Abs(Player.wplayer.controls.currentPosition - value) > 1)
                {
                    Set(ref _TrackProgress, value);
                    Player.wplayer.controls.currentPosition = _TrackProgress;
                }
                else
                {
                    Set(ref _TrackProgress, value);
                }
            }
        }
        #endregion
        #region MaxTrackProgress

        private static double _MaxTrackProgress;
        public double MaxTrackProgress
        {
            get => _MaxTrackProgress;
            set => Set(ref _MaxTrackProgress, value);
        }
        #endregion

        #region ImagePlayButton

        private string _ImagePlayButton= "/Resources/Icons/pause.png";
        public string ImagePlayButton
        {
            get => _ImagePlayButton;
            set => Set(ref _ImagePlayButton, value);
        }
        #endregion
        #region Volume

        private int _Volume=20;
        public int Volume
        {
            get => _Volume;
            set { Set(ref _Volume, value); Player.wplayer.settings.volume = _Volume; }
        }
        #endregion

        #region Адаптация
        #region WindowWidth

        private double _WindowWidth = 1440;
        public double WindowWidth
        {
            get => _WindowWidth;
            set
            {
                if (Popup == true)
                {
                    Task.Factory.StartNew(() =>
                    {

                        Popup = false;
                        Thread.Sleep(300);
                        Popup = true;
                    });
                    if (value <= 1300)
                    {
                        VisibilityState = Visibility.Collapsed;
                        ColumnSpan = 2;
                    }
                    else
                    {
                        VisibilityState = Visibility.Visible;
                        ColumnSpan = 1;
                    }
                    Set(ref _WindowWidth, value);
                }
                else
                {
                    if (Application.Current.MainWindow.WindowState!=WindowState.Minimized&&Player.IsPlaying())
                    {
                        Popup = true;
                    }
                    if (value <= 1300)
                    {
                        VisibilityState = Visibility.Collapsed;
                        ColumnSpan = 2;
                    }
                    else
                    {
                        VisibilityState = Visibility.Visible;
                        ColumnSpan = 1;
                    }
                    Set(ref _WindowWidth, value);
                }
                
            }
        }

        #endregion
        #region VisibilityState

        private static Visibility _VisibilityState = Visibility.Visible;
        public Visibility VisibilityState
        {
            get => _VisibilityState;
            set => Set(ref _VisibilityState, value);
        }

        #endregion
        #region ColumnSpan

        private static int _ColumnSpan = 1;
        public int ColumnSpan
        {
            get => _ColumnSpan;
            set => Set(ref _ColumnSpan, value);
        }

        #endregion
        #endregion

        #region Поиск музыки
        #region RequestInfo

        private static string _RequestInfo;
        public string RequestInfo
        {
            get => _RequestInfo;
            set => Set(ref _RequestInfo, value);
        }

        #endregion
       
        #endregion

        #region FrameContent

        private static Page _FrameContent;
        public Page FrameContent
        {
            get => _FrameContent;
            set => Set(ref _FrameContent, value);
        }
        #endregion
        #region FrameOpacity

        private static double _FrameOpacity=1;
        public double FrameOpacity
        {
            get => _FrameOpacity;
            set => Set(ref _FrameOpacity, value);
        }
        #endregion

        #region ProgressBar

        private Visibility _ProgressBar = Visibility.Collapsed;
        public Visibility ProgressBar
        {
            get => _ProgressBar;
            set => Set(ref _ProgressBar, value);
        }

        #endregion

        #region Страницы
        private static MainPage MainPage;
        private static NewMusic NewMusic;
        private static TopMusic TopMusic;
        private static Hit2021 Hit2021;
        private static Hit2020 Hit2020;
        private static Hit2019 Hit2019;
        private static Hit2018 Hit2018;
        private static Hit2017 Hit2017;
        private static ClubMusic ClubMusic;
        private static CarMusic CarMusic;
        private static AnimeMusic AnimeMusic;
        private static TikTokMusic TikTokMusic;
        private static RussianRap RussianRap;
        private static NewYear NewYear;
        private static ForeignRap ForeignRap;
        private static ForeignRock ForeignRock;
        private static RussianPop RussianPop;
        private static ForeignPop ForeignPop;
        private static OldMusic OldMusic;
        private static Shazam Shazam;
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
            OpacityFunc(NewMusic);
        }

        private bool CanOpenNewMusicPageCommandExecute(object p) => true;
        #endregion
        #region OpenTopMusicPageCommand
        public ICommand OpenTopMusicPageCommand { get; }

        private void OnOpenTopMusicPageCommandExecuted(object p)
        {
            OpacityFunc(TopMusic);
        }

        private bool CanOpenTopMusicPageCommandExecute(object p) => true;
        #endregion
        #region OpenHit2021PageCommand
        public ICommand OpenHit2021PageCommand { get; }

        private void OnOpenHit2021PageCommandExecuted(object p)
        {
            OpacityFunc(Hit2021);
        }

        private bool CanOpenHit2021PageCommandExecute(object p) => true;
        #endregion
        #region OpenHit2020PageCommand
        public ICommand OpenHit2020PageCommand { get; }

        private void OnOpenHit2020PageCommandExecuted(object p)
        {
            OpacityFunc(Hit2020);
        }

        private bool CanOpenHit2020PageCommandExecute(object p) => true;
        #endregion
        #region OpenHit2019PageCommand
        public ICommand OpenHit2019PageCommand { get; }

        private void OnOpenHit2019PageCommandExecuted(object p)
        {
            OpacityFunc(Hit2019);
        }

        private bool CanOpenHit2019PageCommandExecute(object p) => true;
        #endregion
        #region OpenHit2018PageCommand
        public ICommand OpenHit2018PageCommand { get; }

        private void OnOpenHit2018PageCommandExecuted(object p)
        {
            OpacityFunc(Hit2018);
        }

        private bool CanOpenHit2018PageCommandExecute(object p) => true;
        #endregion
        #region OpenHit2017PageCommand
        public ICommand OpenHit2017PageCommand { get; }

        private void OnOpenHit2017PageCommandExecuted(object p)
        {
            OpacityFunc(Hit2017);
        }

        private bool CanOpenHit2017PageCommandExecute(object p) => true;
        #endregion
        #region OpenClubMusicPageCommand
        public ICommand OpenClubMusicPageCommand { get; }

        private void OnOpenClubMusicPageCommandExecuted(object p)
        {
            OpacityFunc(ClubMusic);
        }

        private bool CanOpenClubMusicPageCommandExecute(object p) => true;
        #endregion
        #region OpenCarMusicPageCommand
        public ICommand OpenCarMusicPageCommand { get; }

        private void OnOpenCarMusicPageCommandExecuted(object p)
        {
            OpacityFunc(CarMusic);
        }

        private bool CanOpenCarMusicPageCommandExecute(object p) => true;
        #endregion
        #region OpenAnimeMusicPageCommand
        public ICommand OpenAnimeMusicPageCommand { get; }

        private void OnOpenAnimeMusicPageCommandExecuted(object p)
        {
            OpacityFunc(AnimeMusic);
        }

        private bool CanOpenAnimeMusicPageCommandExecute(object p) => true;
        #endregion
        #region OpenTikTokMusicPageCommand
        public ICommand OpenTikTokMusicPageCommand { get; }

        private void OnOpenTikTokMusicPageCommandExecuted(object p)
        {
            OpacityFunc(TikTokMusic);
        }

        private bool CanOpenTikTokMusicPageCommandExecute(object p) => true;
        #endregion
        #region OpenRussianRapPageCommand
        public ICommand OpenRussianRapPageCommand { get; }

        private void OnOpenRussianRapPageCommandExecuted(object p)
        {
            OpacityFunc(RussianRap);
        }

        private bool CanOpenRussianRapPageCommandExecute(object p) => true;
        #endregion
        #region OpenNewYearPageCommand
        public ICommand OpenNewYearPageCommand { get; }

        private void OnOpenNewYearPageCommandExecuted(object p)
        {
            OpacityFunc(NewYear);
        }

        private bool CanOpenNewYearPageCommandExecute(object p) => true;
        #endregion
        #region OpenForeignRockPageCommand
        public ICommand OpenForeignRockPageCommand { get; }

        private void OnOpenForeignRockPageCommandExecuted(object p)
        {
            OpacityFunc(ForeignRock);
        }

        private bool CanOpenForeignRockPageCommandExecute(object p) => true;
        #endregion
        #region OpenRussianPopPageCommand
        public ICommand OpenRussianPopPageCommand { get; }

        private void OnOpenRussianPopPageCommandExecuted(object p)
        {
            OpacityFunc(RussianPop);
        }

        private bool CanOpenRussianPopPageCommandExecute(object p) => true;
        #endregion
        #region OpenForeignRapPageCommand
        public ICommand OpenForeignRapPageCommand { get; }

        private void OnOpenForeignRapPageCommandExecuted(object p)
        {
            OpacityFunc(ForeignRap);
        }

        private bool CanOpenForeignRapPageCommandExecute(object p) => true;
        #endregion
        #region OpenForeignPopPageCommand
        public ICommand OpenForeignPopPageCommand { get; }

        private void OnOpenForeignPopPageCommandExecuted(object p)
        {
            OpacityFunc(ForeignPop);
        }

        private bool CanOpenForeignPopPageCommandExecute(object p) => true;
        #endregion
        #region OpenOldMusicPageCommand
        public ICommand OpenOldMusicPageCommand { get; }

        private void OnOpenOldMusicPageCommandExecuted(object p)
        {
            OpacityFunc(OldMusic);
        }

        private bool CanOpenOldMusicPageCommandExecute(object p) => true;
        #endregion
        #region OpenShazamPageCommand
        public ICommand OpenShazamPageCommand { get; }

        private void OnOpenShazamPageCommandExecuted(object p)
        {
            OpacityFunc(Shazam);
        }

        private bool CanOpenShazamPageCommandExecute(object p) => true;
        #endregion
        #region OpenMainPageCommand
        public ICommand OpenMainPageCommand { get; }

        private void OnOpenMainPageCommandExecuted(object p)
        {
            OpacityFunc(MainPage);
        }

        private bool CanOpenMainPageCommandExecute(object p) => true;
        #endregion
        #region OpenRegistrationCommand
        public ICommand OpenRegistrationCommand { get; }

        private void OnOpenRegistrationCommandExecuted(object p)
        {
            FrameContent = new Registration();
        }

        private bool CanOpenRegistrationCommandExecute(object p) => true;
        #endregion
        #region OpenSearchResponsePageCommand
        public ICommand OpenSearchResponsePageCommand { get; }

        private async void OnOpenSearchResponsePageCommandExecuted(object p)
        {
            var context = (PagesView)MainPage.DataContext;
            await Task.Factory.StartNew(() =>
            {
                ProgressBar = Visibility.Visible;
                context.Response = MusicParser.Search(RequestInfo);
                context.ResponseInfo = $"По Вашему запросу найдено {context.Response.Count} ответов:";
                ProgressBar = Visibility.Collapsed;
            });
            OpacityFunc(new SearchResponse());
        }

        private bool CanOpenSearchResponsePageCommandExecute(object p) => true;
        #endregion
        #region DragMoveCommand
        public ICommand DragMoveCommand { get; }

        private void OnDragMoveCommandExecuted(object p)
        {
            if (Popup == true)
            {
                Popup = false;
                Application.Current.MainWindow.DragMove();
                Popup = true;
            }
            else
            {
                Application.Current.MainWindow.DragMove();
            }
        }

        private bool CanDragMoveCommandExecute(object p) => true;
        #endregion
        #region PauseMusicCommand
        public ICommand PauseMusicCommand { get; }

        private void OnPauseMusicCommandExecuted(object p)
        {
            if (Player.IsPlaying())
            {
                ImagePlayButton = "/Resources/Icons/play.png";
                Player.Pause();

            }
            else
            {
                ImagePlayButton = "/Resources/Icons/pause.png";
                Player.Resume();
            }
        }

        private bool CanPauseMusicCommandExecute(object p) => true;
        #endregion
        #region NextMusicCommand
        public ICommand NextMusicCommand { get; }

        private void OnNextMusicCommandExecuted(object p)
        {
            Player.Next();
        }

        private bool CanNextMusicCommandExecute(object p) => true;
        #endregion
        #region PreviousMusicCommand
        public ICommand PreviousMusicCommand { get; }

        private void OnPreviousMusicCommandExecuted(object p)
        {
            Player.Previous();
            MusicItem = CurrentPlaylist.Where(t => t.MusicData == Player.wplayer.currentMedia.sourceURL).First();
            string[] res = MusicItem.TrackTime.Split(':');
            double max = Convert.ToInt32(res[0]) * 60 + Convert.ToInt32(res[1]);
            MaxTrackProgress = max;
        }

        private bool CanPreviousMusicCommandExecute(object p) => true;
        #endregion

        public static void ChangeMusic(object item)
        {
            _MusicItem = _CurrentPlaylist.Where(t => t.MusicData == Player.wplayer.currentMedia.sourceURL).First();
            string[] res = _MusicItem.TrackTime.Split(':');
            double max = Convert.ToInt32(res[0]) * 60 + Convert.ToInt32(res[1]);
            _MaxTrackProgress = max;
        }

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
            OpenSearchResponsePageCommand = new LamdaCommand(OnOpenSearchResponsePageCommandExecuted, CanOpenSearchResponsePageCommandExecute);
            DragMoveCommand = new LamdaCommand(OnDragMoveCommandExecuted, CanDragMoveCommandExecute);
            PauseMusicCommand = new LamdaCommand(OnPauseMusicCommandExecuted, CanPauseMusicCommandExecute);
            NextMusicCommand = new LamdaCommand(OnNextMusicCommandExecuted, CanNextMusicCommandExecute);
            PreviousMusicCommand = new LamdaCommand(OnPreviousMusicCommandExecuted, CanPreviousMusicCommandExecute);
            OpenRegistrationCommand = new LamdaCommand(OnOpenRegistrationCommandExecuted, CanOpenRegistrationCommandExecute);

            #endregion
            BindWidth();
        }

        static MainWindowViewModel()
        {
            MainPage = new MainPage();
            NewMusic = new NewMusic();
            TopMusic = new TopMusic();
            Hit2021 = new Hit2021();
            Hit2020 = new Hit2020();
            Hit2019 = new Hit2019();
            Hit2018 = new Hit2018();
            Hit2017 = new Hit2017();
            ClubMusic = new ClubMusic();
            CarMusic = new CarMusic();
            AnimeMusic = new AnimeMusic();
            TikTokMusic = new TikTokMusic();
            RussianRap = new RussianRap();
            NewYear = new NewYear();
            ForeignRock = new ForeignRock();
            RussianPop = new RussianPop();
            ForeignRap = new ForeignRap();
            ForeignPop = new ForeignPop();
            OldMusic = new OldMusic();
            Shazam = new Shazam();
            _FrameContent = MainPage;
            Player.wplayer.MediaChange += ChangeMusic;
        }

        public async void OpacityFunc(Page page)
        {
            await Task.Factory.StartNew(() =>
            {
                ProgressBar = Visibility.Visible;
                for(double i = 1; i > 0; i -= 0.05)
                {
                    FrameOpacity = i;
                    Thread.Sleep(50);
                }
                FrameContent = page;
                for (double i = 0; i <= 1; i += 0.05)
                {
                    FrameOpacity = i;
                    Thread.Sleep(50);
                }
                ProgressBar = Visibility.Collapsed;
            });
        }

        public void BindWidth()
        {
            Binding bind = new Binding();
            bind.Source = this;
            bind.Path = new PropertyPath("WindowWidth");
            bind.Mode = BindingMode.TwoWay;
            Application.Current.MainWindow.SetBinding(MainWindow.WidthProperty, bind);
        }
    }
}
