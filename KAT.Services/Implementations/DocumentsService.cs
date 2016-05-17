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
        private readonly IMapper mapper;

        public DocumentsService()
        {
            // Mappings
            var config = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<DocumentWebServiceReference.Document, Document>();
                cfg.CreateMap<Document, DocumentWebServiceReference.Document>();
                cfg.CreateMap<Driver, Models.Driver.Driver>()
                    .IncludeBase<SimpleDriver, Models.Driver.Driver>();
                cfg.CreateMap<Models.Driver.Driver, Driver>()
                    .IncludeBase<Models.Driver.Driver, SimpleDriver>();
                cfg.CreateMap<Models.Violation.Violation, Violation>();
                cfg.CreateMap<Violation, Models.Violation.Violation>();
                cfg.CreateMap<Models.Policeman.Policeman, Policeman>();
                cfg.CreateMap<Policeman, Models.Policeman.Policeman>();
                cfg.CreateMap<Models.Camera.Camera, Camera>();
                cfg.CreateMap<Camera, Models.Camera.Camera>();
                cfg.CreateMap<Models.Nomenclature.Nomenclature, Nomenclature>();
                cfg.CreateMap<Nomenclature, Models.Nomenclature.Nomenclature>();
                
                cfg.CreateMissingTypeMaps = true;
            });

            mapper = config.CreateMapper();

            client = new DocumentWebServiceClient();
        }

        public List<Document> GetDocuments(Document query)
        {
            query = ManageQueryDriverNames(query);
            var serviceQuery = mapper.Map<DocumentWebServiceReference.Document>(query);
            var result = client.GetDocuments(serviceQuery);
            return result.Select(document => mapper.Map<Document>(document)).ToList();
        }

        public bool DeleteDocument(long id)
        {
            return client.DeleteDocument(id);
        }

        public bool UpdateDocument(Document document)
        {
            var sendDocument = mapper.Map<DocumentWebServiceReference.Document>(document);
            return client.UpdateDocument(sendDocument);
        }

        public long InsertDocument(Document document)
        {
            var sendDocument = mapper.Map<DocumentWebServiceReference.Document>(document);
            return client.InsertDocument(sendDocument);
        }

        private Document ManageQueryDriverNames(Document document)
        {
            if (document.Driver != null && document.Driver.FullName != string.Empty)
            {
                var fullName = document.Driver.FullName;

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
