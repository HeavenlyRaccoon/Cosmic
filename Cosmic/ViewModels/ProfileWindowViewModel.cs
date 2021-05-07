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
        #region Login

        private static string _Login = "";
        public string Login
        {
            get => _Login;
            set => Set(ref _Login, value);
        }

        #endregion
        #region Id

        private static int _Id;
        public int Id
        {
            get => _Id;
            set => Set(ref _Id, value);
        }

        #endregion
        #region Avatar

        private static BitmapImage _Avatar = new BitmapImage(new Uri("../../Resources/Icons/noavatar.png", UriKind.Relative));
        public BitmapImage Avatar
        {
            get
            {
                return _Avatar;
            }
            set => Set(ref _Avatar, value);
        }

        #endregion

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
        
        #endregion

        public ProfileWindowViewModel()
        {
            CloseProfileWindowCommand = new LamdaCommand(OnCloseProfileWindowCommandExecuted, CanCloseProfileWindowCommandExecute);

        }
    }
}
