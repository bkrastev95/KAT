using System.Collections.Generic;
using KAT.Web.Models;

namespace KAT.Data.IServices
{
    public interface IDocumentService
    {
        List<Document> GetDocuments(Document query);

        bool DeleteDocument(long id);

        bool UpdateDocument(Document document);

        long InsertDocument(Document document);

    }
}
