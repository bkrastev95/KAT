using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Security;
using System.Windows;
using System.Windows.Input;
using KAT.Client.Ninject;
using KAT.Client.Utilities;
using KAT.IServices;
using Ninject;

namespace KAT.Client.ViewModels
{
    public class LoginViewModel : INotifyPropertyChanged
    {
        private SecureString password;
        private string username;
        private ICommand logInCommand;
        private IAccountService accountService;

        public LoginViewModel()
        {
            accountService = NinjectConfig.Kernel.Get<IAccountService>();
            logInCommand = new RelayCommand(Login);
        }

        public event PropertyChangedEventHandler PropertyChanged;

        public ICommand LogInCommand
        {
            get { return logInCommand; }
            set { logInCommand = value; }
        }

        public SecureString Password
        {
            get { return password; }
            set
            {
                if (password != value)
                {
                    password = value;
                    NotifyPropertyChanged();
                }
            }
        }

        public string Username
        {
            get
            {
                return username;
            }
            set
            {
                username = value;
                NotifyPropertyChanged();
            }
        }

        private void Login(object obj)
        {
            var user = accountService.Login(username, password);
            if (user != null)
            {
                var loginWindow = Application.Current.Windows.OfType<Window>().SingleOrDefault(w => w.Name == "LoginWindow");
                if (loginWindow != null)
                {
                    loginWindow.Close();
                }

                var mainWindow = new Views.MainWindow();
                mainWindow.Show();
            }
            else
            {
                MessageBox.Show("Невалидни данни!");
            }
        }

        private void NotifyPropertyChanged([CallerMemberName] string propName="")
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(propName));
                
            }
        }
    }
}
