using System;

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

        public Driver GetDriver(long value)
        {
            return new Driver
            {
                FirstName = "Manolo",
                Id = 1,
                LastName = "Rodriguez",
                SecondName = "Lopez"
            };
        }

        public long InsertDriver(Driver driver)
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
