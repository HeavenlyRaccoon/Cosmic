using Cosmic.Services;
using Cosmic.ViewModels;
using Cosmic.Views.Pages;
using Cosmic.Views.Windows;
using System;
using System.Windows;

namespace Cosmic
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            if (MusicParser.ConnectionAvailable())
            {
                InitializeComponent();
                var context = (MainWindowViewModel)((Window)Application.Current.MainWindow).DataContext;
                context.AutoAuth();
                if(Application.Current.MainWindow != Application.Current.Windows[Application.Current.Windows.Count - 1])
                {
                    Application.Current.Windows[Application.Current.Windows.Count - 1].Close();
                }
            }
            else
            {
                InternetExeption internetExeption = new InternetExeption();
                internetExeption.ShowDialog();
            }
            

        }

    }
}
