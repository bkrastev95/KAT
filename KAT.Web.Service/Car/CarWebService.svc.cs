using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;
using KAT.Data.IServices;
using KAT.Web.Service.Ninject;
using Ninject;

namespace KAT.Web.Service.Car
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "CarWebService" in code, svc and config file together.
    // NOTE: In order to launch WCF Test Client for testing this service, please select CarWebService.svc or CarWebService.svc.cs at the Solution Explorer and start debugging.
    public class CarWebService : ICarWebService
    {
        private readonly ICarService carService;
        
        public CarWebService()
        {
            NinjectConfig.ConfigureContainer();
            carService = NinjectConfig.Kernel.Get<ICarService>();
        }

        public List<Models.Car> GetCars()
        {
            return carService.GetCars();
        }

        public bool DeleteCar(long id)
        {
            return carService.DeleteCar(id);
        }

        public long InsertCar(Models.Car car)
        {
            return carService.AddCar(car);
        }

        public bool UpdateCar(Models.Car car)
        {
            return carService.UpdateCar(car);
        }
    }
}
