using System.Linq;
using AutoMapper;
using KAT.IServices;
using KAT.Services.DriverWebServiceReference;

namespace KAT.Services.Implementations
{
    using System.Collections.Generic;

    using Models.Driver;
    using Models.Car;


    public class DriversService : IDriversService
    {
        private readonly DriverWebServiceClient client;
        private readonly IMapper mapper;


        public DriversService()
        {
            client = new DriverWebServiceClient();
            var config = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<DriverWebServiceReference.Driver, Driver>()
                    .IncludeBase<SimpleDriver, Driver>();
                cfg.CreateMap<Driver, DriverWebServiceReference.Driver>()
                    .IncludeBase<Driver, SimpleDriver>();
                cfg.CreateMap<Car, DriverWebServiceReference.Car>();
                cfg.CreateMap<DriverWebServiceReference.Car, Car>();
                cfg.CreateMissingTypeMaps = true;
            });

            mapper = config.CreateMapper();
        }

        public List<Driver> GetDrivers()
        {
            var result = client.GetDrivers().ToList();
            return result.Select(driver => mapper.Map<Driver>(driver)).ToList();
        }

        public long InsertDriver(Driver driver)
        {
            return client.InsertDriver(mapper.Map<DriverWebServiceReference.Driver>(driver));
        }

        public bool DeleteDriver(long id)
        {
            return client.DeleteDriver(id);
        }

        public bool UpdateDriver(Driver driver)
        {
            return client.UpdateDriver(mapper.Map<DriverWebServiceReference.Driver>(driver));
        }
    }
}
