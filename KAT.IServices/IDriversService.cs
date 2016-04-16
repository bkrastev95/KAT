using System.Collections.Generic;
using KAT.Models.Driver;

namespace KAT.IServices
{
    public interface IDriversService
    {
        IEnumerable<Driver> GetAllDrivers();

        Driver GetDriverById(long driverId);

        void UpsertDriver(Driver car);

        void DeleteDriver(long carId);
    }
}
