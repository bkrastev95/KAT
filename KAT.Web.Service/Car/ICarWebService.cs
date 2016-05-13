using System.Collections.Generic;
using System.ServiceModel;


namespace KAT.Web.Service.Car
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the interface name "ICarWebService" in both code and config file together.
    [ServiceContract]
    public interface ICarWebService
    {
        [OperationContract]
        List<Models.Car> GetCars();

        [OperationContract]
        bool DeleteCar(long id);

        [OperationContract]
        long InsertCar(Models.Car car);

        [OperationContract]
        bool UpdateCar(Models.Car car);
    }
}
