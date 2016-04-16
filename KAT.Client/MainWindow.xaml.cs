using KAT.IServices;

namespace KAT.Client
{
    using System.Windows;
    using Views;


    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow(IDriversService driversService)
        {
            InitializeComponent();
            LoginPage loginPage = new LoginPage(driversService);
            LayoutFrame.Navigate(loginPage);
        }
    }
}
