using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;
using KAT.Client.Utilities;
using KAT.Client.Views;
using KAT.Models.User;

namespace KAT.Client.ViewModels
{
    public class MainWindowViewModel : INotifyPropertyChanged
    {
        private User user;
        private ICommand logOffCommand;

        public MainWindowViewModel(User loggedUser)
        {
            User = loggedUser;
            logOffCommand = new RelayCommand(LogOff);
        }

        #region Properties

        public ICommand LogOffCommand
        {
            get { return logOffCommand; }
            set { logOffCommand = value; }
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

        private void NotifyPropertyChanged([CallerMemberName] string propName = "")
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(propName));

            }
        }
    }
}
