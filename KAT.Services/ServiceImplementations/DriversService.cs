namespace KAT.Services.ServiceImplementations
{
    using System.Collections.Generic;

    using Models.Driver;

    using ServiceInterfaces;


    public class DriversService : IDriversService
    {
        public IEnumerable<Driver> GetAllDrivers()
        {
            throw new System.NotImplementedException();
        }

        public Driver GetDriverById()
        {
            throw new System.NotImplementedException();
        }

        public void UpsertDriver(Driver car)
        {
            throw new System.NotImplementedException();
        }

        public void DeleteDriver(long carId)
        {
            throw new System.NotImplementedException();
        }
    }
}
