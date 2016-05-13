using System.Windows.Threading;
using KAT.Client.Utilities.Messenger;
using KAT.Client.Views;

namespace KAT.Client
{
    using System.Windows;

    using Ninject;


    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        public App()
        {
            DispatcherUnhandledException += Application_DispatcherUnhandledException;
        }

        protected override void OnStartup(StartupEventArgs e)
        {
            base.OnStartup(e);
            NinjectConfig.ConfigureContainer();
            NinjectConfig.ComposeObjects(Current);
            
            Current.MainWindow.Show();
        }

        private void Application_DispatcherUnhandledException(object sender, DispatcherUnhandledExceptionEventArgs e)
        {
            e.Handled = true;
            Messenger.ShowMessage("Възникна грешка при работа с приложението: " + e.Exception.Message, MessageType.Error);
        }

    }
}
