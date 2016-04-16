using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
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
        }
    }
}
