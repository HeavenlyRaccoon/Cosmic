using Cosmic.Infastructure.Commands;
using Cosmic.ViewModels.Base;
using System.Windows;
using System.Windows.Input;

namespace Cosmic.ViewModels
{
    internal class AuthWindowViewModel : ViewModelBase
    {  
    
        #region Команды

        #region CloseAuthWindowCommand
        public ICommand CloseAuthWindowCommand { get; }

        private void OnCloseAuthWindowCommandExecuted(object p)
        {
            Application.Current.Windows[1].Close();
            Application.Current.Windows[0].Effect = null;
        }

        private bool CanCloseAuthWindowCommandExecute(object p) => true;
        #endregion
        #region OpenRegistration
        public ICommand OpenRegistrationCommand { get; }

        private void OnOpenRegistrationCommandExecuted(object p)
        {

            var context = (MainWindowViewModel)((Window)Application.Current.MainWindow).DataContext;
            context.OpenRegistrationCommand.Execute(p);
            Application.Current.Windows[1].Close();
            Application.Current.Windows[0].Effect = null;
        }

        private bool CanOpenRegistrationCommandExecute(object p) => true;
        #endregion

        #endregion

        public AuthWindowViewModel()
        {
            #region Команды
            CloseAuthWindowCommand = new LamdaCommand(OnCloseAuthWindowCommandExecuted, CanCloseAuthWindowCommandExecute);
            OpenRegistrationCommand = new LamdaCommand(OnOpenRegistrationCommandExecuted, CanOpenRegistrationCommandExecute);

            #endregion
        }
    }
}
