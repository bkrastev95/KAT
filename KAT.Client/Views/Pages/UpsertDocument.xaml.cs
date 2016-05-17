using System.Linq;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using KAT.Client.ViewModels.Pages;
using KAT.Models.Document;

namespace KAT.Client.Views.Pages
{
    /// <summary>
    /// Interaction logic for UpsertDocument.xaml
    /// </summary>
    public partial class UpsertDocument : Page
    {
        public UpsertDocument(DocumentsViewModel viewModel, string action)
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
