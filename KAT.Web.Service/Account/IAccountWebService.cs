using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Security;
using System.ServiceModel;
using System.Text;
using KAT.Web.Models;

namespace KAT.Web.Service.Account
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the interface name "IAccountWebService" in both code and config file together.
    [ServiceContract]
    public interface IAccountWebService
    {
        [OperationContract]
        User Login(string username, string password);
    }
}
