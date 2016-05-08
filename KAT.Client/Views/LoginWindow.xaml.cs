using MahApps.Metro.Controls;

namespace KAT.Client.Views
{
    /// <summary>
    /// Interaction logic for LoginWindow.xaml
    /// </summary>
    public partial class LoginWindow : MetroWindow
    {
        public LoginWindow()
        {
            InitializeComponent();
            var loginPage = new LoginPage();
            LayoutFrame.Navigate(loginPage);
        }
    }
}
