using System;
using System.Collections.Generic;
using System.Linq;
using AutoMapper;
using KAT.Data.IServices;
using KAT.Data.KAT.Context;
using KAT.Data.Services.Utilities;
using KAT.Web.Models;

namespace KAT.Data.Services
{
    public class CarService : ICarService
    {
        public CarService()
        {
            Mapper.CreateMap<CodeFirstModels.Car, Car>();
            Mapper.CreateMap<Car, CodeFirstModels.Car>();
        }

        public List<Car> GetCars()
        {
            var cars = new List<Car>();
            using (var context = new KatDataContext())
            {
                var result = context.Cars.ToList();
                result.ForEach(r => cars.Add(Mapper.Map<Car>(r)));
                return cars;
            }
        }

        public long AddCar(Car car)
        {
            try
            {
                var insertCar= Mapper.Map<CodeFirstModels.Car>(car);
                using (var context = new KatDataContext())
                {
                    context.Cars.Add(insertCar);
                    context.SaveChanges();
                }

                return insertCar.Id;
            }
            catch (Exception)
            {
                return 0;
            }
        }

        public bool DeleteCar(long id)
        {
            try
            {
                using (var context = new KatDataContext())
                {
                    var removeCar = context.Cars.FirstOrDefault(c => c.Id == id);
                    context.Cars.Remove(removeCar);
                    context.SaveChanges();
                }

                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public bool UpdateCar(Car car)
        {
            try
            {
                var updateCar = Mapper.Map<CodeFirstModels.Car>(car);
                using (var context = new KatDataContext())
                {
                    var dbRecord = context.Cars.FirstOrDefault(d => d.Id == car.Id);
                    PropertyCopy.Copy(updateCar, dbRecord);
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
