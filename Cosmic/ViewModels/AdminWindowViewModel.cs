using Cosmic.Infastructure.Commands;
using Cosmic.Models;
using Cosmic.Services;
using Cosmic.ViewModels.Base;
using Cosmic.Views.Windows;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;

namespace Cosmic.ViewModels
{
    class AdminWindowViewModel : ViewModelBase
    {
        MyDbContext db;
         
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
        #region UserData

        private static BindingList<User> _UserData;
        public BindingList<User> UserData
        {
            get => _UserData;
            set => Set(ref _UserData, value);
        }

        #endregion
        #region PlaylistData

        private static BindingList<Playlist> _PlaylistData;
        public BindingList<Playlist> PlaylistData
        {
            get => _PlaylistData;
            set => Set(ref _PlaylistData, value);
        }

        #endregion
        #region MusicData

        private static BindingList<Music> _MusicData;
        public BindingList<Music> MusicData
        {
            get => _MusicData;
            set => Set(ref _MusicData, value);
        }

        #endregion
        #region UserDataVisibility

        private static Visibility _UserDataVisibility = Visibility.Visible;
        public Visibility UserDataVisibility
        {
            get => _UserDataVisibility;
            set => Set(ref _UserDataVisibility, value);
        }

        #endregion
        #region PlaylistDataVisibility

        private static Visibility _PlaylistDataVisibility = Visibility.Collapsed;
        public Visibility PlaylistDataVisibility
        {
            get => _PlaylistDataVisibility;
            set => Set(ref _PlaylistDataVisibility, value);
        }

        #endregion
        #region MusicDataVisibility

        private static Visibility _MusicDataVisibility = Visibility.Collapsed;
        public Visibility MusicDataVisibility
        {
            get => _MusicDataVisibility;
            set => Set(ref _MusicDataVisibility, value);
        }

        #endregion
        #region RemoveVisibility

        private static Visibility _RemoveVisibility = Visibility.Collapsed;
        public Visibility RemoveVisibility
        {
            get => _RemoveVisibility;
            set => Set(ref _RemoveVisibility, value);
        }

        #endregion
        #region SelectedUser

        private static User _SelectedUser;
        public User SelectedUser
        {
            get => _SelectedUser;
            set => Set(ref _SelectedUser, value);
        }

        #endregion
        #region SelectedPlaylist

        private static Playlist _SelectedPlaylist;
        public Playlist SelectedPlaylist
        {
            get => _SelectedPlaylist;
            set => Set(ref _SelectedPlaylist, value);
        }

        #endregion
        #region SelectedMusic

        private static Music _SelectedMusic;
        public Music SelectedMusic
        {
            get => _SelectedMusic;
            set => Set(ref _SelectedMusic, value);
        }

        #endregion

        #region Команды

        #region CloseProfileWindowCommand
        public ICommand CloseProfileWindowCommand { get; }

        private void OnCloseProfileWindowCommandExecuted(object p)
        {
            db.Dispose();
            Application.Current.Windows[2].Close();
        }

        private bool CanCloseProfileWindowCommandExecute(object p) => true;
        #endregion
        #region SaveChangeCommand
        public ICommand SaveChangeCommand { get; }

        private void OnSaveChangeCommandExecuted(object p)
        {
            try
            {
                db.SaveChanges();
            }
            catch(Exception ex)
            {
                MessageBox.Show($"{ex.Message}\nОшибка, изменения не сохранены");
            }
        }

        private bool CanSaveChangeCommandExecute(object p) => true;
        #endregion
        #region OpenUsersCommand
        public ICommand OpenUsersCommand { get; }

        private void OnOpenUsersCommandExecuted(object p)
        {
            UserDataVisibility = Visibility.Visible;
            PlaylistDataVisibility = Visibility.Collapsed;
            MusicDataVisibility = Visibility.Collapsed;
            RemoveVisibility = Visibility.Collapsed;
        }

        private bool CanOpenUsersCommandExecute(object p) => true;
        #endregion
        #region OpenPlaylistCommand
        public ICommand OpenPlaylistCommand { get; }

        private void OnOpenPlaylistCommandExecuted(object p)
        {
            UserDataVisibility = Visibility.Collapsed;
            PlaylistDataVisibility = Visibility.Visible;
            MusicDataVisibility = Visibility.Collapsed;
            RemoveVisibility = Visibility.Visible;
        }

        private bool CanOpenPlaylistCommandExecute(object p) => true;
        #endregion
        #region OpenMusicCommand
        public ICommand OpenMusicCommand { get; }

        private void OnOpenMusicCommandExecuted(object p)
        {
            UserDataVisibility = Visibility.Collapsed;
            PlaylistDataVisibility = Visibility.Collapsed;
            MusicDataVisibility = Visibility.Visible;
            RemoveVisibility = Visibility.Visible;
        }

        private bool CanOpenMusicCommandExecute(object p) => true;
        #endregion
        #region BlockUserCommand
        public ICommand BlockUserCommand { get; }

        private void OnBlockUserCommandExecuted(object p)
        {
            try
            {
                if (SelectedUser != null)
                {
                    db.Users.Remove(SelectedUser);
                    db.SaveChanges();
                    SelectedUser = null;
                }
            }
            catch(Exception ex)
            {
                MessageBox.Show($"{ex.Message}\nОшибка, пользователь не удален");
            }
            
        }

        private bool CanBlockUserCommandExecute(object p) => true;
        #endregion
        #region RemoveCommand
        public ICommand RemoveCommand { get; }

        private void OnRemoveCommandExecuted(object p)
        {
            try
            {
                if (PlaylistDataVisibility == Visibility.Visible)
                {
                    if (SelectedPlaylist != null)
                    {
                        db.Playlists.Remove(SelectedPlaylist);
                        db.SaveChanges();
                        SelectedPlaylist = null;
                    }
                }
                else
                {
                    if (SelectedMusic != null)
                    {
                        db.Musics.Remove(SelectedMusic);
                        db.SaveChanges();
                        SelectedMusic = null;
                    }
                }
            }
            catch(Exception ex)
            {
                MessageBox.Show($"{ex.Message}\nОшибка, элемент не удален");
            }
        }

        private bool CanRemoveCommandExecute(object p) => true;
        #endregion

        #endregion

        public AdminWindowViewModel()
        {
            CloseProfileWindowCommand = new LamdaCommand(OnCloseProfileWindowCommandExecuted, CanCloseProfileWindowCommandExecute);
            SaveChangeCommand = new LamdaCommand(OnSaveChangeCommandExecuted, CanSaveChangeCommandExecute);
            OpenUsersCommand = new LamdaCommand(OnOpenUsersCommandExecuted, CanOpenUsersCommandExecute);
            OpenPlaylistCommand = new LamdaCommand(OnOpenPlaylistCommandExecuted, CanOpenPlaylistCommandExecute);
            OpenMusicCommand = new LamdaCommand(OnOpenMusicCommandExecuted, CanOpenMusicCommandExecute);
            BlockUserCommand = new LamdaCommand(OnBlockUserCommandExecuted, CanBlockUserCommandExecute);
            RemoveCommand = new LamdaCommand(OnRemoveCommandExecuted, CanRemoveCommandExecute);
            db = new MyDbContext();
            db.Users.Load();
            _UserData = db.Users.Local.ToBindingList();
            db.Playlists.Load();
            _PlaylistData = db.Playlists.Local.ToBindingList();
            db.Musics.Load();
            _MusicData = db.Musics.Local.ToBindingList();
        }
    }
}
