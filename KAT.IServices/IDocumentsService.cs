using System.Collections.Generic;
using KAT.Models.Document;

namespace KAT.IServices
{
    public interface IDocumentsService
    {
        List<Document> GetDocuments(Document query);

        bool DeleteDocument(long id);

        bool UpdateDocument(Document document);

        long InsertDocument(Document document);
    }
}
