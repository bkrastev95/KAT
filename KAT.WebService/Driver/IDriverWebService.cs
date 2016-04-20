using System.ServiceModel;

namespace KAT.WebService.Driver
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the interface name "IDriverWebService" in both code and config file together.
    [ServiceContract]
    public interface IDriverWebService
    {
        [OperationContract]
        Web.Models.Driver GetDriver(long value);

        [OperationContract]
        long InsertDriver(Web.Models.Driver driver);
    }
}
