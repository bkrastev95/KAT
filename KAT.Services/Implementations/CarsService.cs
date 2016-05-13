using System.Linq;
using AutoMapper;
using KAT.IServices;
using KAT.Models.Driver;
using KAT.Services.CarWebServiceReference;

namespace KAT.Services.Implementations
{
    using System.Collections.Generic;

    using Models.Car;
    using Models.Nomenclature;


    public class CarsService : ICarsService
    {
        private readonly CarWebServiceClient client;
        private readonly IMapper mapper;

        public CarsService()
        {
            client = new CarWebServiceClient();

            var config = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<Car, CarWebServiceReference.Car>();
                cfg.CreateMap<CarWebServiceReference.Car, Car>();
                cfg.CreateMap<CarWebServiceReference.Nomenclature, Nomenclature>();
                cfg.CreateMap<Nomenclature, CarWebServiceReference.Nomenclature>();
                cfg.CreateMap<Driver, SimpleDriver>();
                cfg.CreateMap<SimpleDriver, Driver>();
                
                cfg.CreateMissingTypeMaps = true;
            });

            mapper = config.CreateMapper();
        }

        public List<Car> GetCars()
        {
            var result = client.GetCars().ToList();
            return result.Select(car => mapper.Map<Car>(car)).ToList();
        }

        public long InsertCar(Car car)
        {
            return client.InsertCar(mapper.Map<CarWebServiceReference.Car>(car));
        }

        public bool DeleteCar(long id)
        {
            return client.DeleteCar(id);
        }

        public bool UpdateCar(Car car)
        {
            return client.UpdateCar(mapper.Map<CarWebServiceReference.Car>(car));
        }
    }
}
