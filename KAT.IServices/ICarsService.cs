using System.Collections.Generic;
using KAT.Models.Car;

namespace KAT.IServices
{
    public interface ICarsService
    {
        IEnumerable<Car> GetAllCars();

        Car GetCarById();

        void UpsertCar(Car car);

        void DeleteCar(long carId);

    }
}
