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
            using (var context = new KatContext())
            {
                context.Drivers.Add(dbDriver);
                context.SaveChanges();
            }

            return dbDriver.Id;
        }

        public Driver.Driver GetDriverById(long id)
        {
            CodeFirstModels.Driver driver;
            //var dbDriver = new CodeFirstModels.Driver
            //{
            //    FirstName = "Juan",
            //    SecondName = "Lopez",
            //    LastName = "Martinez"
            //};

            using (var db = new KatContext())
            {
                var query = from b in db.Drivers
                            orderby b.FirstName
                            select b;

                driver = query.FirstOrDefault();
            }

            return Mapper.Map<Driver.Driver>(driver);
        }
    }
}
