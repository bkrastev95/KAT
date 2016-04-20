﻿using KAT.Data.IServices;
using KAT.Data.Services;

using Ninject;
namespace KAT.WebService.Ninject
{
    public static class NinjectConfig
    {
        public static IKernel Kernel { get; private set; }

        public static void ConfigureContainer()
        {
            Kernel = new StandardKernel();
            Kernel.Bind<ICarService>().To<CarService>().InTransientScope();
            Kernel.Bind<IDriverService>().To<DriverService>().InTransientScope();
        }

    }
}