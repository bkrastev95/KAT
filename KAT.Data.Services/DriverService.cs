using System;
using System.Data;
using System.Linq;
using AutoMapper;
using KAT.Data.IServices;
using KAT.Data.KAT.Context;
using Driver = KAT.Web.Models;

namespace KAT.Data.Services
{
    public class DriverService : IDriverService
    {
        public long InsertDriver(Driver.Driver driver)
        {
            var dbDriver = Mapper.Map<CodeFirstModels.Driver>(driver);
            using (var context = new KatDataContext())
            {
                context.Drivers.Add(dbDriver);
                context.SaveChanges();
            }

            return dbDriver.Id;
        }

        public Driver.Driver GetDriverById(long id)
        {
            CodeFirstModels.Driver driver;
            var dbDriver = new CodeFirstModels.Driver
            {
                Egn = "03985612",
                FirstName = "Juan",
                SecondName = "Lopez",
                LastName = "Martinez"
            };

            using (var db = new KatDataContext())
            {
                try
                {
                    var query = db.Drivers.ToList();

                    driver = query.FirstOrDefault();
                }
                catch (DataException dataEx)
                {
                    return null;
                }
                catch (NullReferenceException nullEx)
                {
                    return null;
                }
            }

            try
            {
                var config = new MapperConfiguration(cfg =>
                cfg.CreateMap<Driver.Driver, CodeFirstModels.Driver>());
                var mapper = config.CreateMapper();
                return mapper.Map<Driver.Driver>(driver);
            }
            catch (AutoMapperMappingException mapEx)
            {
                return new Driver.Driver
                {
                    Id = driver.Id,
                    FirstName = driver.FirstName,
                    SecondName = driver.SecondName,
                    LastName = driver.LastName
                };
                throw;
            }
            
        }
    }
}
