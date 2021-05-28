using Cosmic.Infastructure.Commands;
using Cosmic.ViewModels.Base;
using Cosmic.Views.Windows;
using System.Windows;
using System.Windows.Input;
using System.Windows.Media.Effects;

namespace Cosmic.ViewModels
{
    class ProfileWindowViewModel : ViewModelBase
    {


        #region AdminButton
        public Visibility AdminButton
        {
            get
            {
                var context = (MainWindowViewModel)((Window)Application.Current.MainWindow).DataContext;
                if (context.Id <= 5)
                {
                    return Visibility.Visible;
                }
                else return Visibility.Collapsed;
            }
        }

        #endregion


        #region Команды

        #region CloseProfileWindowCommand
        public ICommand CloseProfileWindowCommand { get; }

        private void OnCloseProfileWindowCommandExecuted(object p)
        {
            Application.Current.Windows[Application.Current.Windows.Count-1].Close();
            Application.Current.Windows[0].Effect = null;
        }

        private bool CanCloseProfileWindowCommandExecute(object p) => true;
        #endregion
        #region OpenProfilePageCommand
        public ICommand OpenProfilePageCommand { get; }

        private void OnOpenProfilePageCommandExecuted(object p)
        {
            var context = (MainWindowViewModel)((Window)Application.Current.MainWindow).DataContext;
            context.OpenProfilePageCommand.Execute(p);
            context.CloseProfileWindowCommand.Execute(p);
        }

        private bool CanOpenProfilePageCommandExecute(object p) => true;
        #endregion
        #region OpenAdminPanelCommand
        public ICommand OpenAdminPanelCommand { get; }

        private void OnOpenAdminPanelCommandExecuted(object p)
        {
            //var context = (MainWindowViewModel)((Window)Application.Current.MainWindow).DataContext;
            AdminWindow adminWindow = new AdminWindow();
            BlurEffect blurEffect = new BlurEffect();
            blurEffect.Radius = 10;
            Application.Current.MainWindow.Effect = blurEffect;
            adminWindow.ShowDialog();
        }

        private bool CanOpenAdminPanelCommandExecute(object p) => true;
        #endregion
        #region OpenPlaylistsCommand
        public ICommand OpenPlaylistsCommand { get; }

        private void OnOpenPlaylistsCommandExecuted(object p)
        {
            var context = (MainWindowViewModel)((Window)Application.Current.MainWindow).DataContext;
            context.CloseProfileWindowCommand.Execute(p);
            context.OpenPlaylistsCommand.Execute(p);
        }

        private bool CanOpenPlaylistsCommandExecute(object p) => true;
        #endregion
        #region ExitCommand
        public ICommand ExitCommand { get; }

        private void OnExitCommandExecuted(object p)
        {
            var context = (MainWindowViewModel)((Window)Application.Current.MainWindow).DataContext;
            context.OpenMainPageCommand.Execute(p);
            context.ExitCommand.Execute(p);
            CloseProfileWindowCommand.Execute(p);
        }

        private bool CanExitCommandExecute(object p) => true;
        #endregion

        #endregion

        public ProfileWindowViewModel()
        {
            CloseProfileWindowCommand = new LamdaCommand(OnCloseProfileWindowCommandExecuted, CanCloseProfileWindowCommandExecute);
            OpenProfilePageCommand = new LamdaCommand(OnOpenProfilePageCommandExecuted, CanOpenProfilePageCommandExecute);
            OpenPlaylistsCommand = new LamdaCommand(OnOpenPlaylistsCommandExecuted, CanOpenPlaylistsCommandExecute);
            ExitCommand = new LamdaCommand(OnExitCommandExecuted, CanExitCommandExecute);
            OpenAdminPanelCommand = new LamdaCommand(OnOpenAdminPanelCommandExecuted, CanOpenAdminPanelCommandExecute);

        }
    }
}
