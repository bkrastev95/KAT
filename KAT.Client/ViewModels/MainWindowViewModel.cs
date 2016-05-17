using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Windows;
using System.Windows.Input;
using KAT.Client.Utilities;
using KAT.Client.Views;
using KAT.Models.User;

namespace KAT.Client.ViewModels
{
    public class MainWindowViewModel : INotifyPropertyChanged
    {
        private string pageName;
        private User user;
        private ICommand logOffCommand;
        private ICommand changePageCommand;

        private const string PageNamePrefix = "Pages/";
        private const string PageNamePostfix = ".xaml";

        public MainWindowViewModel(User loggedUser)
        {
            User = loggedUser;
            PageName = "TestPage";
            logOffCommand = new RelayCommand(LogOff);
            changePageCommand = new RelayCommand(ChangePage);
        }

        #region Properties

        public ICommand LogOffCommand
        {
            get { return logOffCommand; }
            set { logOffCommand = value; }
        }

        public ICommand ChangePageCommand
        {
            get { return changePageCommand; }
            set { changePageCommand = value; }
        }

        public User User
        {
            get
            {
                return user;
            }
            set
            {
                user = value;
                NotifyPropertyChanged();
            }
        }

        public string PageName
        {
            get { return string.Format("{0}{1}{2}", PageNamePrefix, pageName, PageNamePostfix); }
            set
            {
                pageName = value;
                NotifyPropertyChanged();
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;

        #endregion

        private void LogOff(object obj)
        {
            User = null;
            var mainWindow = Application.Current.Windows.OfType<Window>().SingleOrDefault();
            if (mainWindow != null)
            {
                var logInWindow = new LoginWindow();
                logInWindow.Show();
                mainWindow.Close();
            }
        }

        private void ChangePage(object obj)
        {
            var name = (string) obj;
            PageName = name;
        }

        private void NotifyPropertyChanged([CallerMemberName] string propName = "")
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(propName));

            }
        }
    }
}
