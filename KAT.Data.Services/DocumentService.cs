using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using AutoMapper;
using KAT.Data.IServices;
using KAT.Data.KAT.Context;
using KAT.Web.Models;

namespace KAT.Data.Services
{
    public class DocumentService : IDocumentService
    {
        public DocumentService()
        {
            // Configure Out mappings:
            Mapper.CreateMap<CodeFirstModels.Driver, Driver>();
            Mapper.CreateMap<CodeFirstModels.Policeman, Policeman>();
            Mapper.CreateMap<CodeFirstModels.Nomenclatures.Violation, Violation>();

            // Configure In mappings:
            Mapper.CreateMap<Driver, CodeFirstModels.Driver>();
            Mapper.CreateMap<Policeman, CodeFirstModels.Policeman>();
            Mapper.CreateMap<Violation, CodeFirstModels.Nomenclatures.Violation>();
        }

        public List<Document> GetDocuments(Document query)
        {
            var documents = new List<Document>();
            using (var context = new KatDataContext())
            {
                List<CodeFirstModels.Document> result;

                if (!string.IsNullOrEmpty(query.RegNumber))
                {
                    result = context.Documents.Where(d => d.RegNumber == query.RegNumber).ToList();
                } 
                else if (query.Driver != null)
                {
                    result = context.Documents.Where(d => 
                        (query.RegNumber == string.Empty || d.RegNumber.Contains(query.RegNumber))
                        && (query.Driver.FirstName == string.Empty || d.Driver.FirstName.Contains(query.Driver.FirstName))
                        && (query.Driver.SecondName == string.Empty || d.Driver.SecondName.Contains(query.Driver.SecondName))
                        && (query.Driver.LastName == string.Empty || d.Driver.SecondName.Contains(query.Driver.LastName))).ToList();
                }
                else
                {
                    result = context.Documents.ToList();
                }
                
                if (result.Any())
                {
                    
                    result.ForEach(d =>
                        documents.Add(new Document
                        {
                            Id = d.Id,
                            RegNumber = d.RegNumber,
                            Date = d.Date,
                            DocumentType = new Nomenclature
                            {
                                Id = d.DocumentType.Id,
                                Name = d.DocumentType.Name
                            },
                            Camera = new Camera
                            {
                                Id = d.Camera.Id,
                                Location = d.Camera.Location
                            },
                            Driver = Mapper.Map<Driver>(d.Driver),
                            Policeman = Mapper.Map<Policeman>(d.Policeman),
                            Violations = d.Violations.Select(Mapper.Map<Violation>).ToList()
                        }));
                }

                return documents;
            }
        }

        public bool DeleteDocument(long id)
        {
            using (var context = new KatDataContext())
            {
                var delete = context.Documents.FirstOrDefault(d => d.Id == id);
                if (delete != null)
                {
                    context.Documents.Remove(delete);
                    return true;
                }

                return false;
            }
        }

        public bool UpdateDocument(Document document)
        {
            using (var context = new KatDataContext())
            {
                var result = context.Documents.Where(d => d.RegNumber == document.RegNumber).ToList();
                if (result.Count != 1)
                {
                    return false;
                }

                var recordToUpdate = result.FirstOrDefault();
                foreach (var propertyInfo in document.GetType().GetProperties().Where(propertyInfo => propertyInfo.GetValue(document, null) != null))
                {
                    recordToUpdate.GetType().GetProperty(propertyInfo.Name).SetValue(recordToUpdate, propertyInfo.GetValue(document,null));
                }

                return true;
            }
        }

        public long InsertDocument(Document document)
        {
            try
            {
                using (var context = new KatDataContext())
                {
                    context.Documents.Add(Mapper.Map<CodeFirstModels.Document>(document));
                    return document.Id;
                }
            }
            catch (Exception)
            {
                return 0;
            }
            
        }
    }
}
