using Cosmic.Infastructure.Commands;
using Cosmic.Models;
using Cosmic.Services;
using Cosmic.ViewModels.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;

namespace Cosmic.ViewModels
{
    class RegistrationViewModel : ViewModelBase
    {
        #region Login

        private string _Login="";
        public string Login
        {
            get => _Login;
            set => Set(ref _Login, value);
        }

        #endregion
        #region Password

        private string _Password="";
        public string Password
        {
            get => _Password;
            set => Set(ref _Password, value);
        }

        #endregion
        #region ConfirmPassword

        private string _ConfirmPassword="";
        public string ConfirmPassword
        {
            get => _ConfirmPassword;
            set => Set(ref _ConfirmPassword, value);
        }

        #endregion
        #region ExepMassage

        private string _ExepMassage="";
        public string ExepMassage
        {
            get => _ExepMassage;
            set => Set(ref _ExepMassage, value);
        }

        #endregion

        #region Registration
        public ICommand RegistrationCommand { get; }

        private void OnRegistrationCommandExecuted(object p)
        {
            if (Login.Length > 0 && !Login.Contains(" "))
            {
                if (Password.Length >= 6 && !Password.Contains(" "))
	            {
                    bool en = true;
                    for (int i = 0; i < Password.Length; i++)
                    {
                        if (Password[i] >= 'А' && Password[i] <= 'Я') en = false;
                    }
                    if (!en)
                    {
                        ExepMassage = "Доступна только английская раскладка";
                    }
                    else if (ConfirmPassword.Length > 0)
                    {
                        if (ConfirmPassword != Password)
                        {
                            ExepMassage = "Пароли не совпадают";
                        }
                        else
                        {
                            ExepMassage = EntityFunction.AddUser(Login, Password);
                            if (ExepMassage == "")
                            {
                                User user = EntityFunction.Authorization(Login, Password);
                                if (user != null)
                                {
                                    var context = (MainWindowViewModel)((Window)Application.Current.MainWindow).DataContext;
                                    context.Id = user.Id;
                                    context.Login = user.Login;
                                    context.OpenMainPageCommand.Execute(p);
                                    context.AuthorizationCommand.Execute(p);
                                }
                            }
                        }
                    }else ExepMassage = "Повторите пароль";
                }
                else ExepMassage = "Пароль должен содержать минимум 6\n символов, и не содержать пробелов";
            }else ExepMassage = "Укажите логин. Пробелы не разрешены.";
        }

        private bool CanRegistrationCommandExecute(object p) => true;
        #endregion
        public RegistrationViewModel()
        {
            RegistrationCommand = new LamdaCommand(OnRegistrationCommandExecuted, CanRegistrationCommandExecute);
        }
    }
}
