using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media.Animation;
using KAT.Client.Utilities.Messenger;
using KAT.Models.User;
using MahApps.Metro;
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

        private void Menu_OnMouseLeave(object sender, MouseEventArgs e)
        {
            HideMenu(Menu);
        }

        private void OnSelectMenuItem(object sender, RoutedEventArgs e)
        {
            HideMenu(Menu);
            var button = sender as Button;
            if (button != null)
            {
                var command = button.Tag as ICommand;
                if (command != null)
                    command.Execute(button.CommandParameter);
            }
        }

        private void ButtonShowMenu_Click(object sender, RoutedEventArgs e)
        {
            ShowMenu(Menu);
        }

        private void HideMenu(Grid border)
        {
            var sb = Resources["HideMenu"] as Storyboard;
            sb.Begin(border);
        }

        private void ShowMenu(Grid border)
        {
            var sb = Resources["ShowMenu"] as Storyboard;
            sb.Begin(border);
        }
    }
}
