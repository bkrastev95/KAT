using System.Collections.Generic;
using KAT.Models.Driver;

namespace KAT.IServices
{
    public interface IDriversService
    {
        List<Driver> GetDrivers();

        long InsertDriver(Driver driver);

        bool DeleteDriver(long id);

        bool UpdateDriver(Driver driver);
    }
}
