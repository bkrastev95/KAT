namespace KAT.Client
{
    using System.Linq;
    using System.Windows;

    using Services.ServiceInterfaces;
    using KAT.Client.Views;


    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private readonly ICarsService carsService;

        public MainWindow(ICarsService carsService)
        {
            this.carsService = carsService;
            InitializeComponent();
            LoginPage loginPage = new LoginPage();
            LayoutFrame.Navigate(loginPage);
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            var car = carsService.GetAllCars();

            //myButton.Content = car.FirstOrDefault().RegNumber;
        }
    }
}
