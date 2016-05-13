using System.Collections.Generic;
using KAT.Web.Models;

namespace KAT.Data.IServices
{
    public interface ICarService
    {
        List<Car> GetCars();

        long AddCar(Car car);

        bool DeleteCar(long id);

        bool UpdateCar(Car car);
    }
}