namespace KAT.Client
{
    using System.Linq;
    using System.Windows;

    using Services.ServiceInterfaces;


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

        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            var car = carsService.GetAllCars();

            myButton.Content = car.FirstOrDefault().RegNumber;
        }
    }
}
