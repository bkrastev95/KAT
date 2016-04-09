namespace KAT.Services.ServiceImplementations
{
    using System.Collections.Generic;

    using Models.Car;

    using ServiceInterfaces;


    public class CarsService : ICarsService
    {
        public IEnumerable<Car> GetAllCars()
        {
            // Open connection to web service

            // fetch all cars with appropriate command

            var car = new Car { RegNumber = "you made it!" };

            return new List<Car>{ car };
        }

        public Car GetCarById()
        {
            // Open connection to web service

            // serach all cars and get one that matches

            return new Car();
        }

        public void UpsertCar(Car car)
        {
            // Open connection to web service

            // make POST with serialized model
        }

        public void DeleteCar(long carId)
        {
            // Open connection to web service

            // pass the parameter calling the appropriate function and let the web service do the rest of the job
        }
    }
}
