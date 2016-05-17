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
using KAT.Client.ViewModels.Pages;

namespace KAT.Client.Views.Pages
{
    /// <summary>
    /// Interaction logic for UpsertPolicemanPage.xaml
    /// </summary>
    public partial class UpsertPolicemanPage : Page
    {
        public UpsertPolicemanPage(PolicemenViewModel viewModel, string action)
        {
            InitializeComponent();
            DataContext = viewModel;
            if (action == "Insert")
            {
                Edit.Visibility = Visibility.Hidden;
            }
            else
            {
                Register.Visibility = Visibility.Hidden;
            }
        }

        private void CloseWindow(object sender, RoutedEventArgs e)
        {
            var button = sender as Button;
            if (button != null)
            {
                var command = button.Tag as ICommand;
                if (command != null)
                    command.Execute(button.CommandParameter);
            }

            Window.GetWindow(this).Close();
        }
    }
}
