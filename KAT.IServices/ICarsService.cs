using System.Collections.Generic;
using KAT.Models.Car;

namespace KAT.IServices
{
    public interface ICarsService
    {
        List<Car> GetCars();

        long InsertCar(Car driver);

        bool DeleteCar(long id);

        bool UpdateCar(Car driver);
    }
}
