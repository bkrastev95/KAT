namespace KAT.Services.ServiceInterfaces
{
    using System.Collections.Generic;

    using Models.Car;

    public interface ICarsService
    {
        IEnumerable<Car> GetAllCars();

        Car GetCarById();

        void UpsertCar(Car car);

        void DeleteCar(long carId);

    }
}
