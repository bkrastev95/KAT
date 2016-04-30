using KAT.Data.IServices;
using KAT.Data.Services;

using Ninject;
namespace KAT.Web.Service.Ninject
{
    public static class NinjectConfig
    {
        public static IKernel Kernel { get; private set; }

        public static void ConfigureContainer()
        {
            Kernel = new StandardKernel();
            Kernel.Bind<ICarService>().To<CarService>().InTransientScope();
            Kernel.Bind<IDriverService>().To<DriverService>().InTransientScope();
            Kernel.Bind<IAccountService>().To<AccountService>().InTransientScope();
        }

    }
}