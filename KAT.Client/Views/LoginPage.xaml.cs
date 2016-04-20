using System.Windows;
using System.Windows.Controls;
using KAT.IServices;

namespace KAT.Client.Views
{
    /// <summary>
    /// Interaction logic for LoginPage.xaml
    /// </summary>
    public partial class LoginPage : Page
    {
        private readonly IDriversService driversService;

        public LoginPage(IDriversService driversService)
        {
            this.driversService = driversService;
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            var driver = driversService.GetDriverById(1);
            MessageBox.Show(
                "First name: " + driver.FirstName + "/n" +
                "Second name: " + driver.SecondName + "/n" +
                "Last name: " + driver.LastName + "/n" +
                "Id: " + driver.Id + "/n");

            var secondPage = new MainMenu();
        }
    }
}
