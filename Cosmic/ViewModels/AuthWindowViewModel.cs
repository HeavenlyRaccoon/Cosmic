using Cosmic.Infastructure.Commands;
using Cosmic.Models;
using Cosmic.Services;
using Cosmic.ViewModels.Base;
using System.IO;
using System.IO.IsolatedStorage;
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

        private static string _Password = "";
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
        #region checkbox

        private static bool _checkbox = false;
        public bool checkbox
        {
            get => _checkbox;
            set => Set(ref _checkbox, value);
        }

        #endregion

        #region Команды

        #region CloseAuthWindowCommand
        public ICommand CloseAuthWindowCommand { get; }

        private void OnCloseAuthWindowCommandExecuted(object p)
        {
            Application.Current.Windows[Application.Current.Windows.Count-1].Close();
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
                        if (!user.IsBlocked)
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

                            IsolatedStorageFile storFile = IsolatedStorageFile.GetUserStoreForAssembly();
                            IsolatedStorageFileStream storStream = new IsolatedStorageFileStream("UserSetting.set", FileMode.Create, storFile);
                            StreamWriter userWriter = new StreamWriter(storStream);
                            userWriter.Write(Login + " " + Password + " " + checkbox);
                            userWriter.Close();

                            context.OpenMainPageCommand.Execute(p);
                            context.AuthorizationCommand.Execute(p);
                            CloseAuthWindowCommand.Execute(p);
                        }
                        else ExepMassage = "Пользователь заблокирован";
                    }
                    else ExepMassage = "Неверный логин или пароль";
                }
                else ExepMassage = "Пароль должен содержать минимум 6\n символов, и не содержать пробелов";
            }
            else ExepMassage = "Укажите логин. Пробелы не разрешены.";
        }

        private bool CanAuthorizationCommandExecute(object p) => true;
        #endregion

        #region CheckInternet
        public ICommand CheckInternetCommand { get; }

        private void OnCheckInternetCommandExecuted(object p)
        {
            if (MusicParser.ConnectionAvailable())
            {
                Application.Current.MainWindow = new MainWindow();
                Application.Current.Windows[1].Close();
                Application.Current.Windows[0].Close();
                Application.Current.MainWindow.Show();
                
            }
        }

        private bool CanCheckInternetCommandExecute(object p) => true;
        #endregion
        #endregion

        public AuthWindowViewModel()
        {
            #region Команды
            CloseAuthWindowCommand = new LamdaCommand(OnCloseAuthWindowCommandExecuted, CanCloseAuthWindowCommandExecute);
            OpenRegistrationCommand = new LamdaCommand(OnOpenRegistrationCommandExecuted, CanOpenRegistrationCommandExecute);
            AuthorizationCommand = new LamdaCommand(OnAuthorizationCommandExecuted, CanAuthorizationCommandExecute);
            CheckInternetCommand = new LamdaCommand(OnCheckInternetCommandExecuted, CanCheckInternetCommandExecute);
            #endregion
        }
    }
}
