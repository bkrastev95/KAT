using System.Collections.Generic;
using System.Linq;
using AutoMapper;
using KAT.IServices;
using KAT.Services.DocumentWebServiceReference;
using Document = KAT.Models.Document.Document;

namespace KAT.Services.Implementations
{
    public class DocumentsService : IDocumentsService
    {
        private readonly DocumentWebServiceClient client;
        public DocumentsService()
        {
            // Mappings
            Mapper.CreateMap<DocumentWebServiceReference.Document, Document>();
            Mapper.CreateMap<Document, DocumentWebServiceReference.Document>();

            client = new DocumentWebServiceClient();
        }

        public List<Document> GetDocuments(Document query)
        {
            query = ManageQueryDriverNames(query);
            var serviceQuery = Mapper.Map<DocumentWebServiceReference.Document>(query);
            var result = client.GetDocuments(serviceQuery);
            return result.Select(document => Mapper.Map<Document>(document)).ToList();
        }

        public bool DeleteDocument(long id)
        {
            return client.DeleteDocument(id);
        }

        public bool UpdateDocument(Document document)
        {
            var sendDocument = Mapper.Map<DocumentWebServiceReference.Document>(document);
            return client.UpdateDocument(sendDocument);
        }

        public long InsertDocument(Document document)
        {
            var sendDocument = Mapper.Map<DocumentWebServiceReference.Document>(document);
            return client.InsertDocument(sendDocument);
        }

        private Document ManageQueryDriverNames(Document document)
        {
            var fullName = document.Driver.FullName;
            if (fullName != string.Empty)
            {
                var names = fullName.Split(' ');
                if (names.Length == 1)
                {
                    document.Driver.FirstName = names.FirstOrDefault();
                }
                else if (names.Length == 2)
                {
                    document.Driver.FirstName = names.FirstOrDefault();
                    document.Driver.LastName = names.LastOrDefault();
                }
                else
                {
                    document.Driver.FirstName = names.FirstOrDefault();
                    document.Driver.LastName = names.LastOrDefault();
                    document.Driver.SecondName = string.Join(" ", names.Except(new List<string>{names.First(), names.Last()}).ToList());
                }
            }

            return document;
        }
    }
}
