namespace KAT.Services.ServiceInterfaces
{
    using System.Collections.Generic;

    using Models.Driver;

    public interface IDriversService
    {
        IEnumerable<Driver> GetAllDrivers();

        Driver GetDriverById();

        void UpsertDriver(Driver car);

        void DeleteDriver(long carId);
    }
}
