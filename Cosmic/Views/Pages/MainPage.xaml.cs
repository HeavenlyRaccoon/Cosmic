using Cosmic.Services;
using System.Windows.Controls;

namespace Cosmic.Views.Pages
{
    /// <summary>
    /// Логика взаимодействия для MainPage.xaml
    /// </summary>
    public partial class MainPage : Page
    {
        public MainPage()
        {
            try
            {
                InitializeComponent();
            }
            catch
            {
                throw new NetworkException();
            }
        }
    }
}
