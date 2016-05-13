using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;
using KAT.Data.IServices;
using KAT.Web.Service.Ninject;
using Ninject;

namespace KAT.Web.Service.Document
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "DocumentWebService" in code, svc and config file together.
    // NOTE: In order to launch WCF Test Client for testing this service, please select DocumentWebService.svc or DocumentWebService.svc.cs at the Solution Explorer and start debugging.
    public class DocumentWebService : IDocumentWebService
    {
        private readonly IDocumentService documentService;

        public DocumentWebService()
        {
            NinjectConfig.ConfigureContainer();
            documentService = NinjectConfig.Kernel.Get<IDocumentService>();
        }
        public List<Models.Document> GetDocuments(Models.Document document)
        {
            return documentService.GetDocuments(document);
        }

        public bool DeleteDocument(long id)
        {
            return documentService.DeleteDocument(id);
        }

        public long InsertDocument(Models.Document document)
        {
            return documentService.InsertDocument(document);
        }

        public bool UpdateDocument(Models.Document document)
        {
            return documentService.UpdateDocument(document);
        }
    }
}
