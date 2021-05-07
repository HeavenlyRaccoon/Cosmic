﻿using Cosmic.Infastructure.Commands;
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
            if (Login.Length > 0)
            {
                if (Password.Length >= 6)
                {
                    ExepMassage = EntityFunction.Authorization(Login, Password);
                    if (ExepMassage == "")
                    {
                        var context = (MainWindowViewModel)((Window)Application.Current.MainWindow).DataContext;
                        context.OpenMainPageCommand.Execute(p);
                        context.AuthorizationCommand.Execute(p);
                        CloseAuthWindowCommand.Execute(p);
                    }
                }
                else ExepMassage = "Пароль слишком короткий, минимум 6 символов";
            }
            else ExepMassage = "Укажите логин";
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
