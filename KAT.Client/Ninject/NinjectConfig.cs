using KAT.IServices;
using KAT.Services.Implementations;

namespace KAT.Client.Ninject
{
    using System.Windows;

    using global::Ninject;


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
