using KAT.Web.Models;

namespace KAT.Data.IServices
{
    public interface IDriverService
    {
        long InsertDriver(Driver driver);

        Driver GetDriverById(long id);
    }
}