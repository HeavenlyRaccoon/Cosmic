using Cosmic.Infastructure.Commands;
using Cosmic.Models;
using Cosmic.Services;
using Cosmic.ViewModels.Base;
using System.Windows;
using System.Windows.Input;

namespace Cosmic.ViewModels
{
    internal class AuthWindowViewModel : ViewModelBase
    {
        #region Login

        private string _Login = "";
        public string Login
        {
            get => _Login;
            set => Set(ref _Login, value);
        }

        #endregion
        #region Password

        private string _Password = "";
        public string Password
        {
            get => _Password;
            set => Set(ref _Password, value);
        }

        #endregion
        #region ExepMassage

        private string _ExepMassage = "";
        public string ExepMassage
        {
            get => _ExepMassage;
            set => Set(ref _ExepMassage, value);
        }

        #endregion

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
        #region Authorization
        public ICommand AuthorizationCommand { get; }

        private void OnAuthorizationCommandExecuted(object p)
        {
            if (Login.Length > 0&&!Login.Contains(" "))
            {
                if (Password.Length >= 6&&!Password.Contains(" "))
                {
                    User user = EntityFunction.Authorization(Login, Password);
                    if (user != null)
                    {
                        var context = (MainWindowViewModel)((Window)Application.Current.MainWindow).DataContext;
                        context.Id = user.Id;
                        context.Login = user.Login;
                        context.Name = user.Name;
                        context.AboutUser = user.AboutUser;
                        if (user.Avatar != null)
                        {
                           context.Avatar = EntityFunction.ToImage(user.Avatar);
                        }
                        context.OpenMainPageCommand.Execute(p);
                        context.AuthorizationCommand.Execute(p);
                        CloseAuthWindowCommand.Execute(p);
                    }
                    else ExepMassage = "Неверный логин или пароль";
                }
                else ExepMassage = "Пароль должен содержать минимум 6\n символов, и не содержать пробелов";
            }
            else ExepMassage = "Укажите логин. Пробелы не разрешены.";
        }

        private bool CanAuthorizationCommandExecute(object p) => true;
        #endregion

        #endregion

        public AuthWindowViewModel()
        {
            #region Команды
            CloseAuthWindowCommand = new LamdaCommand(OnCloseAuthWindowCommandExecuted, CanCloseAuthWindowCommandExecute);
            OpenRegistrationCommand = new LamdaCommand(OnOpenRegistrationCommandExecuted, CanOpenRegistrationCommandExecute);
            AuthorizationCommand = new LamdaCommand(OnAuthorizationCommandExecuted, CanAuthorizationCommandExecute);

            #endregion
        }
    }
}
