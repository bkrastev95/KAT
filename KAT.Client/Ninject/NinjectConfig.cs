namespace KAT.Client.Ninject
{
    using System.Windows;

    using global::Ninject;

    using Services.ServiceImplementations;
    using Services.ServiceInterfaces;


    public static class NinjectConfig
    {
        private static IKernel container;

        public static void ConfigureContainer()
        {
            container = new StandardKernel();
            container.Bind<ICarsService>().To<CarsService>().InTransientScope();
            container.Bind<IDriversService>().To<DriversService>().InTransientScope();
        }

        public static void ComposeObjects(Application current)
        {
            current.MainWindow = container.Get<MainWindow>();
        }
    }
}
