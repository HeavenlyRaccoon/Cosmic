using Cosmic.Infastructure.Commands;
using Cosmic.Models;
using Cosmic.Services;
using Cosmic.ViewModels.Base;
using Cosmic.Views.Pages;
using Cosmic.Views.Windows;
using System.Collections.Generic;
using System.Diagnostics;
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

        #region Адаптация
        #region WindowWidth

        private double _WindowWidth = 1440;
        public double WindowWidth
        {
            get => _WindowWidth;
            set
            {
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

        #endregion
        #region VisibilityState

        private Visibility _VisibilityState = Visibility.Visible;
        public Visibility VisibilityState
        {
            get => _VisibilityState;
            set => Set(ref _VisibilityState, value);
        }

        #endregion
        #region ColumnSpan

        private int _ColumnSpan = 1;
        public int ColumnSpan
        {
            get => _ColumnSpan;
            set => Set(ref _ColumnSpan, value);
        }

        #endregion
        #endregion

        #region Поиск музыки
        #region RequestInfo

        private string _RequestInfo;
        public string RequestInfo
        {
            get => _RequestInfo;
            set => Set(ref _RequestInfo, value);
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
        #region Response

        private static List<MusicItem> _Response=new List<MusicItem>();
        public List<MusicItem> Response
        {
            get => _Response;
            set => Set(ref _Response, value);
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
        #region OpenSearchResponsePageCommand
        public ICommand OpenSearchResponsePageCommand { get; }

        private async void OnOpenSearchResponsePageCommandExecuted(object p)
        {
            await Task.Factory.StartNew(() =>
            {
                ProgressBar = Visibility.Visible;
                Response = MusicParser.Search(RequestInfo);
                ResponseInfo = $"По Вашему запросу найдено {_Response.Count} ответов:";
                ProgressBar = Visibility.Collapsed;
            });
            OpacityFunc(new SearchResponse());
        }

        private bool CanOpenSearchResponsePageCommandExecute(object p) => true;
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
            OpenSearchResponsePageCommand = new LamdaCommand(OnOpenSearchResponsePageCommandExecuted, CanOpenSearchResponsePageCommandExecute);
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
