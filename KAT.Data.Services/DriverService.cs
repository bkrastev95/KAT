using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using AutoMapper;
using KAT.Data.IServices;
using KAT.Data.KAT.Context;
using KAT.Data.Services.Utilities;
using Driver = KAT.Web.Models.Driver;

namespace KAT.Data.Services
{
    public class DriverService : IDriverService
    {
        public DriverService()
        {
            Mapper.CreateMap<CodeFirstModels.Driver, Driver>();
            Mapper.CreateMap<Driver, CodeFirstModels.Driver>();
        }

        public List<Driver> GetAllDrivers()
        {
            var drivers = new List<Driver>();
            using (var context = new KatDataContext())
            {
                var result = context.Drivers.ToList();
                result.ForEach(r => drivers.Add(Mapper.Map<Driver>(r)));
                return drivers;
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
