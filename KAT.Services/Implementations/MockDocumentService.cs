using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using KAT.IServices;
using KAT.Models.Document;

namespace KAT.Services.Implementations
{
    public class MockDocumentService : IDocumentsService
    {
        private readonly List<Document> documents = new List<Document>
            {
                new Document { RegNumber = "111111" },
                new Document { RegNumber = "121212" },
                new Document { RegNumber = "123123" },
                new Document { RegNumber = "123412" },
                new Document { RegNumber = "123451" },
                new Document { RegNumber = "123456" }
            };

        public List<Document> GetDocuments(Document query)
        {
            return query.RegNumber != null ? documents.Where(d => d.RegNumber.Contains(query.RegNumber)).ToList() :
                documents;
        }

        public bool DeleteDocument(long id)
        {
            throw new NotImplementedException();
        }

        public bool UpdateDocument(Document document)
        {
            throw new NotImplementedException();
        }

        public long InsertDocument(Document document)
        {
            throw new NotImplementedException();
        }
    }
}
