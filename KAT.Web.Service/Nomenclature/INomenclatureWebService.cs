using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;
using KAT.Web.Models;

namespace KAT.Web.Service.Nomenclature
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the interface name "INomenclatureWebService" in both code and config file together.
    [ServiceContract]
    public interface INomenclatureWebService
    {

        #region Violations
        [OperationContract]
        List<Violation> GetViolations();
        [OperationContract]
        bool AddViolation(Violation violation);
        [OperationContract]
        bool DeleteViolation(long id);
        [OperationContract]
        bool UpdateViolation(Violation violation);

        #endregion

        #region Cameras
        [OperationContract]
        List<Camera> GetCameras();
        [OperationContract]
        bool AddCamera(Camera camera);
        [OperationContract]
        bool DeleteCamera(long id);
        [OperationContract]
        bool UpdateCamera(Camera camera);

        #endregion

        #region Policemen
        [OperationContract]
        List<Policeman> GetPolicemen();
        [OperationContract]
        bool AddPoliceman(Policeman policeman);
        [OperationContract]
        bool DeletePoliceman(long id);
        [OperationContract]
        bool UpdatePoliceman(Policeman policeman);

        #endregion

    }
}
