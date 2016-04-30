using System.Windows;

namespace KAT.Client.Views
{
    /// <summary>
    /// Interaction logic for LoginWindow.xaml
    /// </summary>
    public partial class LoginWindow : Window
    {
        public LoginWindow()
        {
            InitializeComponent();
            var loginPage = new LoginPage();
            LayoutFrame.Navigate(loginPage);
        }
    }
}
