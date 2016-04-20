using System;
using KAT.Data.IServices;
using KAT.WebService.Ninject;
using Ninject;


namespace KAT.WebService.Driver
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "DriverWebService" in code, svc and config file together.
    // NOTE: In order to launch WCF Test Client for testing this service, please select DriverWebService.svc or DriverWebService.svc.cs at the Solution Explorer and start debugging.
    public class DriverWebService : IDriverWebService
    {
        //private readonly IDriverDataService driverDataService;
        //public DriverService(IDriverDataService driverDataService)
        //{
        //    this.driverDataService = driverDataService;
        //}

        public Web.Models.Driver GetDriver(long value)
        {
            NinjectConfig.ConfigureContainer();
            var driverService = NinjectConfig.Kernel.Get<IDriverService>();
            var result = driverService.GetDriverById(1);
            var testResult = new Web.Models.Driver
            {
                FirstName = "Manolo",
                Id = 1,
                LastName = "Rodriguez",
                SecondName = "Lopez"
            };
            
            return result;
        }

        public long InsertDriver(Web.Models.Driver driver)
        {
            if (driver == null)
            {
                throw new ArgumentNullException("driver");
            }

            // mapper.Map(Driver1, Driver2);
            // driverDataService.InsertDriver(Driver2)
            return 0;
        }
    }
}
