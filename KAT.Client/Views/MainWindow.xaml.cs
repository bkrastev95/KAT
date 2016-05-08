using System.Windows;
using KAT.Models.User;
using MahApps.Metro.Controls;


namespace KAT.Client.Views
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : MetroWindow
    {
        // Keeps the loged in user
        public User User { get; set; }

        public MainWindow(User user)
        {
            InitializeComponent();
            User = user;
        }
    }
}
