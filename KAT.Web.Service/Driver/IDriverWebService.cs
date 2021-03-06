﻿using System.Collections.Generic;
using System.ServiceModel;

namespace KAT.Web.Service.Driver
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the interface name "IDriverWebService" in both code and config file together.
    [ServiceContract]
    public interface IDriverWebService
    {
        [OperationContract]
        List<Models.Driver> GetDrivers();

        [OperationContract]
        bool DeleteDriver(long id);

        [OperationContract]
        long InsertDriver(Models.Driver driver);

        [OperationContract]
        bool UpdateDriver(Models.Driver driver);
    }
}
