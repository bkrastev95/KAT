using AutoMapper;
using KAT.IServices;

namespace KAT.Services.Implementations
{
    using System.Collections.Generic;

    using Models.Driver;


    public class DriversService : IDriversService
    {
        public IEnumerable<Driver> GetAllDrivers()
        {
            throw new System.NotImplementedException();
        }

        public Driver GetDriverById(long driverId)
        {
            var driverService = new DriverWebServiceReference.DriverWebServiceClient();
            var result = driverService.GetDriver(driverId);

            var config = new MapperConfiguration(cfg =>
                cfg.CreateMap<DriverWebServiceReference.Driver, Driver>());
            var mapper = config.CreateMapper();
            try
            {
                return mapper.Map<Driver>(result);
            }
            catch (AutoMapperMappingException mapEx)
            {
                return new Driver
                {
                    FirstName = result.FirstName,
                    SecondName = result.SecondName,
                    LastName = result.LastName,
                    Id = result.Id
                };
            }
        }

        public void UpsertDriver(Driver car)
        {
            throw new System.NotImplementedException();
        }

        public void DeleteDriver(long carId)
        {
            throw new System.NotImplementedException();
        }
    }
}
