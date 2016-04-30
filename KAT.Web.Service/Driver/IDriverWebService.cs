using System.ServiceModel;

namespace KAT.Web.Service.Driver
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the interface name "IDriverWebService" in both code and config file together.
    [ServiceContract]
    public interface IDriverWebService
    {
        [OperationContract]
        Models.Driver GetDriver(long value);

        [OperationContract]
        long InsertDriver(Models.Driver driver);
    }
}
