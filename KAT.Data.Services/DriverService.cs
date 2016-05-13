using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using AutoMapper;
using KAT.Data.IServices;
using KAT.Data.KAT.Context;
using KAT.Data.Services.Utilities;
using KAT.Web.Models;
using Driver = KAT.Web.Models.Driver;

namespace KAT.Data.Services
{
    public class DriverService : IDriverService
    {
        private readonly IMapper mapper;

        public DriverService()
        {
            /*
             var config = new MapperConfiguration(cfg => {
            cfg.CreateMap<Order, OrderDto>()
                  .Include<OnlineOrder, OnlineOrderDto>()
            cfg.CreateMap<OnlineOrder, OnlineOrderDto>();
            });
             */

            var config = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<CodeFirstModels.Driver, Driver>()
                    .IncludeBase<CodeFirstModels.Driver, SimpleDriver>();

                cfg.CreateMap<Driver, CodeFirstModels.Driver>()
                    .IncludeBase<SimpleDriver, CodeFirstModels.Driver>();

                cfg.CreateMap<Car, CodeFirstModels.Car>();
                cfg.CreateMap<CodeFirstModels.Car, Car>();

                cfg.CreateMissingTypeMaps = true;
            });

            mapper = config.CreateMapper();
        }

        public List<Driver> GetAllDrivers()
        {
            try
            {
                var drivers = new List<Driver>();
                using (var context = new KatDataContext())
                {
                    var result = context.Drivers.ToList();
                    result.ForEach(r => drivers.Add(mapper.Map<Driver>(r)));
                    return drivers;
                }
            }
            catch (Exception e)
            {
                return new List<Driver>();
            }
        }

        public long AddDriver(Driver driver)
        {
            try
            {
                var dbDriver = Mapper.Map<CodeFirstModels.Driver>(driver);
                using (var context = new KatDataContext())
                {
                    context.Drivers.Add(dbDriver);
                    context.SaveChanges();
                }

                return dbDriver.Id;
            }
            catch (Exception)
            {
                return 0;
            }
        }

        public bool DeleteDriver(long id)
        {
            try
            {
                using (var context = new KatDataContext())
                {
                    var removeDriver = context.Drivers.FirstOrDefault(d => d.Id == id);
                    context.Drivers.Remove(removeDriver);
                    context.SaveChanges();
                }

                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public bool UpdateDriver(Driver driver)
        {
            try
            {
                var updateDriver = Mapper.Map<CodeFirstModels.Driver>(driver);
                using (var context = new KatDataContext())
                {
                    var dbRecord = context.Drivers.FirstOrDefault(d => d.Id == driver.Id);
                    PropertyCopy.Copy(updateDriver, dbRecord);
                    context.SaveChanges();
                }

                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }
    }
}
