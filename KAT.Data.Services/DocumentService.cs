using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using AutoMapper;
using KAT.Data.IServices;
using KAT.Data.KAT.Context;
using KAT.Web.Models;

namespace KAT.Data.Services
{
    public class DocumentService : IDocumentService
    {
        private readonly IMapper mapper; 

        public DocumentService()
        {
            var config = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<CodeFirstModels.Document, Document>();
                cfg.CreateMap<Document, CodeFirstModels.Document>();
                cfg.CreateMap<CodeFirstModels.Driver, Driver>();
                cfg.CreateMap<Driver, CodeFirstModels.Driver>();
                cfg.CreateMap<CodeFirstModels.Policeman, Policeman>();
                cfg.CreateMap<Policeman, CodeFirstModels.Policeman>();
                cfg.CreateMap<Nomenclature, CodeFirstModels.Nomenclatures.Rank>();
                cfg.CreateMap<CodeFirstModels.Nomenclatures.Rank, Nomenclature>();
                cfg.CreateMap<CodeFirstModels.Nomenclatures.Violation, Violation>();
                cfg.CreateMap<Violation, CodeFirstModels.Nomenclatures.Violation>();
                cfg.CreateMap<CodeFirstModels.Nomenclatures.Camera, Camera>();
                cfg.CreateMap<Camera, CodeFirstModels.Nomenclatures.Camera>();
                cfg.CreateMap<CodeFirstModels.Nomenclatures.DocumentType, Nomenclature>();
                cfg.CreateMap<Nomenclature, CodeFirstModels.Nomenclatures.DocumentType>();

                cfg.CreateMissingTypeMaps = true;
            });

            mapper = config.CreateMapper();
        }

        public List<Document> GetDocuments(Document query)
        {
            var documents = new List<Document>();
            using (var context = new KatDataContext())
            {
                List<CodeFirstModels.Document> result;

                if (!string.IsNullOrEmpty(query.RegNumber))
                {
                    result = context.Documents.Where(d => d.RegNumber.Contains(query.RegNumber)).ToList();
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
                    result.ForEach(d => documents.Add(mapper.Map<Document>(d)));
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
                    context.SaveChanges();
                    return true;
                }

                return false;
            }
        }

        public bool UpdateDocument(Document document)
        {
            try
            {
                var updateDocument = mapper.Map<CodeFirstModels.Document>(document);

                using (var context = new KatDataContext())
                {
                    var result = context.Documents.Where(d => d.RegNumber == updateDocument.RegNumber).ToList();
                    if (result.Count != 1)
                    {
                        return false;
                    }

                    var recordToUpdate = result.FirstOrDefault();

                    // Attach props:
                    if (updateDocument.Driver != null)
                    {
                        // context.Cars.ToList().FindAll(c => c.Driver.Id == updateDocument.Driver.Id).ToList()
                        updateDocument.Driver.Cars = null;
                        context.Drivers.Attach(updateDocument.Driver);
                        recordToUpdate.Driver = updateDocument.Driver;
                    }

                    if (updateDocument.Violations != null && updateDocument.Violations.Any())
                    {
                        updateDocument.Violations.ToList().ForEach(v => context.Violations.Attach(v));
                        recordToUpdate.Violations = new List<CodeFirstModels.Nomenclatures.Violation>();
                        updateDocument.Violations.ToList().ForEach(v => recordToUpdate.Violations.Add(v));
                    }

                    if (updateDocument.Camera != null)
                    {
                        context.Cameras.Attach(updateDocument.Camera);
                        recordToUpdate.Camera = updateDocument.Camera;
                    }

                    if (updateDocument.Policeman != null)
                    {
                        context.Policemеn.Attach(updateDocument.Policeman);
                        recordToUpdate.Policeman = updateDocument.Policeman;
                    }

                    if (updateDocument.DocumentType != null)
                    {
                        context.DocumentTypes.Attach(updateDocument.DocumentType);
                        recordToUpdate.DocumentType = updateDocument.DocumentType;
                    }

                    if (updateDocument.Picture != null)
                    {
                        recordToUpdate.Picture = updateDocument.Picture;
                    }

                    recordToUpdate.Id = updateDocument.Id;
                    recordToUpdate.RegNumber = updateDocument.RegNumber;

                    //var docInDb = context.Documents.Find(updateDocument.Id);

                    //// Activity does not exist in database and it's new one
                    //if (docInDb == null)
                    //{
                    //    context.Documents.Add(updateDocument);
                    //    context.SaveChanges();
                    //    return true;
                    //}

                    //// Activity already exist in database and modify it
                    //context.Entry(docInDb).CurrentValues.SetValues(updateDocument);
                    //context.Entry(docInDb).State = EntityState.Modified;


                    context.SaveChanges();

                    return true;
                }
            }
            catch (Exception e)
            {
                return false;
            }
        }

        public long InsertDocument(Document document)
        {
            try
            {
                var insertDocument = mapper.Map<CodeFirstModels.Document>(document);
                using (var context = new KatDataContext())
                {
                    var newDoc = new CodeFirstModels.Document
                    {
                        Date = insertDocument.Date,
                        Picture = insertDocument.Picture,
                        RegNumber = insertDocument.RegNumber
                    };

                    context.Documents.Add(newDoc);

                    // Attach props:
                    if (insertDocument.Driver != null)
                    {
                        insertDocument.Driver.Cars = null;
                        context.Drivers.Attach(insertDocument.Driver);
                        newDoc.Driver = insertDocument.Driver;
                    }

                    if (insertDocument.Violations != null && insertDocument.Violations.Any())
                    {
                        insertDocument.Violations.ToList().ForEach(v => context.Violations.Attach(v));
                        newDoc.Violations = insertDocument.Violations;
                    }

                    if (insertDocument.Camera != null)
                    {
                        context.Cameras.Attach(insertDocument.Camera);
                        newDoc.Camera = insertDocument.Camera;
                    }

                    if (insertDocument.Policeman != null)
                    {
                        context.Policemеn.Attach(insertDocument.Policeman);
                        newDoc.Policeman = insertDocument.Policeman;
                    }

                    if (insertDocument.DocumentType != null)
                    {
                        context.DocumentTypes.Attach(insertDocument.DocumentType);
                        newDoc.DocumentType = insertDocument.DocumentType;
                    }

                    //var docInDb = context.Documents.Find(insertDocument.Id);

                    //if (docInDb == null)
                    //{
                    //    insertDocument.Driver.Cars.ToList().ForEach(c => c.Driver = null);
                    //    context.Documents.Add(insertDocument);
                    //    context.SaveChanges();
                    //    return insertDocument.Id;
                    //}

                    //context.Entry(docInDb).CurrentValues.SetValues(insertDocument);
                    //context.Entry(docInDb).State = EntityState.Modified;

                    context.SaveChanges();
                    return newDoc.Id;
                }
            }
            catch (Exception e)
            {
                return 0;
            }
            
        }
    }
}
