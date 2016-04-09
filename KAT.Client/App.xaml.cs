namespace KAT.Client
{
    using System.Windows;

    using Ninject;


    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        protected override void OnStartup(StartupEventArgs e)
        {
            base.OnStartup(e);
            NinjectConfig.ConfigureContainer();
            NinjectConfig.ComposeObjects(Current);
            Current.MainWindow.Show();
        }
    }
}
