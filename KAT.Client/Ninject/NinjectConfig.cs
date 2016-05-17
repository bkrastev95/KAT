using KAT.Client.Views;
using KAT.IServices;
using KAT.Services.Implementations;

namespace KAT.Client.Ninject
{
    using System.Windows;

    using global::Ninject;


    public static class NinjectConfig
    {
        public static IKernel Kernel { get; private set; }

        public static void ConfigureContainer()
        {
            Kernel = new StandardKernel();
            Kernel.Bind<ICarsService>().To<CarsService>().InTransientScope();
            Kernel.Bind<IDriversService>().To<DriversService>().InTransientScope();
            Kernel.Bind<INomenclatureService>().To<NomenclatureService>().InTransientScope();
#if !DEBUG
            Kernel.Bind<IDocumentsService>().To<MockDocumentService>().InTransientScope();
            Kernel.Bind<IAccountService>().To<MockAccountService>().InTransientScope();
#else
            Kernel.Bind<IDocumentsService>().To<DocumentsService>().InTransientScope();
            Kernel.Bind<IAccountService>().To<AccountService>().InTransientScope();
#endif
        }

        public static void ComposeObjects(Application current)
        {
            current.MainWindow = Kernel.Get<LoginWindow>();
        }
    }
}
