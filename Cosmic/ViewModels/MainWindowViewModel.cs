using Cosmic.Infastructure.Commands;
using Cosmic.Models;
using Cosmic.Services;
using Cosmic.ViewModels.Base;
using Cosmic.Views.Windows;
using System.Collections.Generic;
using System.Diagnostics;
using System.Threading.Tasks;
using System.Windows;
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

        private List<MusicItem> _Hit2021 = MusicParser.Playlist("https://mp3trip.info/muzykalnye-hity-2021/").GetRange(0,5);
        public List<MusicItem> Hit2021
        {
            get => _Hit2021;
        }


        #endregion
        #region Tik Tok 2021

        private List<MusicItem> _TikTok = MusicParser.Playlist("https://mp3trip.info/muzyka-iz-tik-tok/").GetRange(0,5);
        public List<MusicItem> TikTok
        {
            get => _TikTok;
        }


        #endregion
        #region Новая Музыка

        private List<MusicItem> _NewMusic = MusicParser.Playlist("https://mp3trip.info/novye-postuplenija-mp3/").GetRange(0, 13);
        public List<MusicItem> NewMusic
        {
            get => _NewMusic;
        }
        #endregion
        #region Популярная музыка

        private List<MusicItem> _PopularMusic = MusicParser.Playlist("https://mp3trip.info/populyarnye/").GetRange(0, 13);
        public List<MusicItem> PopularMusic
        {
            get => _PopularMusic;
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

        #endregion
        public MainWindowViewModel()
        {
            #region Команды
            OpenAuthWindowCommand = new LamdaCommand(OnOpenAuthWindowCommandExecuted, CanOpenAuthWindowCommandExecute);
            OpenLinkCommand = new LamdaCommand(OnOpenLinkCommandExecuted, CanOpenLinkCommandExecute);
            MinimizeWindowCommand = new LamdaCommand(OnMinimizeWindowCommandExecuted, CanMinimizeWindowCommandExecute);
            MaximizeWindowCommand = new LamdaCommand(OnMaximizeWindowCommandExecuted, CanMaximizeWindowCommandExecute);
            ShutDownCommand = new LamdaCommand(OnShutDownCommandExecuted, CanShutDownCommandExecute);

            #endregion
        }
    }
}
