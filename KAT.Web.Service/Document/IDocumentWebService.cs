using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace KAT.Web.Service.Document
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the interface name "IDocumentWebService" in both code and config file together.
    [ServiceContract]
    public interface IDocumentWebService
    {
        [OperationContract]
        List<Models.Document> GetDocuments(Models.Document document);

        [OperationContract]
        bool DeleteDocument(long id);

        [OperationContract]
        long InsertDocument(Models.Document document);

        [OperationContract]
        bool UpdateDocument(Models.Document document);
    }
}
