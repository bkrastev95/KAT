using System;
using System.Collections.Generic;
using KAT.Data.IServices;
using KAT.Web.Service.Ninject;
using Ninject;

namespace KAT.Web.Service.Driver
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "DriverWebService" in code, svc and config file together.
    // NOTE: In order to launch WCF Test Client for testing this service, please select DriverWebService.svc or DriverWebService.svc.cs at the Solution Explorer and start debugging.
    public class DriverWebService : IDriverWebService
    {
        private readonly IDriverService driverService;

        public DriverWebService()
        {
            NinjectConfig.ConfigureContainer();
            driverService = NinjectConfig.Kernel.Get<IDriverService>();
        }
        
        public List<Models.Driver> GetDrivers()
        {
            return driverService.GetAllDrivers();
        }

        public bool DeleteDriver(long id)
        {
            return driverService.DeleteDriver(id);
        }

        public long InsertDriver(Models.Driver driver)
        {
            return driverService.AddDriver(driver);
        }

        public bool UpdateDriver(Models.Driver driver)
        {
            return driverService.UpdateDriver(driver);
        }
    }
}
