using Cosmic.Infastructure.Commands;
using Cosmic.ViewModels.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;
using System.Windows.Media.Imaging;

namespace Cosmic.ViewModels
{
    class ProfileWindowViewModel : ViewModelBase
    {
        #region Команды

        #region CloseProfileWindowCommand
        public ICommand CloseProfileWindowCommand { get; }

        private void OnCloseProfileWindowCommandExecuted(object p)
        {
            Application.Current.Windows[1].Close();
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
            ExitCommand = new LamdaCommand(OnExitCommandExecuted, CanExitCommandExecute);

        }
    }
}
