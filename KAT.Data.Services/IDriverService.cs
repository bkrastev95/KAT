using System.Collections.Generic;
using KAT.Web.Models;

namespace KAT.Data.IServices
{
    public interface IDriverService
    {
        List<Driver> GetAllDrivers();

        long AddDriver(Driver driver);

        bool DeleteDriver(long id);

        bool UpdateDriver(Driver driver);
    }
}