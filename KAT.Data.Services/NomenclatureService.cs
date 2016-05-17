using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using KAT.Data.CodeFirstModels.Nomenclatures;
using KAT.Data.IServices;
using KAT.Data.KAT.Context;
using KAT.Data.Services.Utilities;
using KAT.Web.Models;
using Camera = KAT.Web.Models.Camera;
using Violation = KAT.Web.Models.Violation;

namespace KAT.Data.Services
{
    public class NomenclatureService : INomenclatureService
    {
        private readonly IMapper mapper;

        public NomenclatureService()
        {
            var config = new MapperConfiguration(cfg =>
            {
                // Violations
                cfg.CreateMap<CodeFirstModels.Nomenclatures.Violation, Violation>();
                cfg.CreateMap<Violation, CodeFirstModels.Nomenclatures.Violation>();

                // Cameras
                cfg.CreateMap<CodeFirstModels.Nomenclatures.Camera, Camera>();
                cfg.CreateMap<Camera, CodeFirstModels.Nomenclatures.Camera>();

                // Policemen
                cfg.CreateMap<CodeFirstModels.Policeman, Policeman>();
                cfg.CreateMap<Policeman, CodeFirstModels.Policeman>();
                cfg.CreateMap<Rank, Nomenclature>();
                cfg.CreateMap<Nomenclature, Rank>();

                // DocTypes
                cfg.CreateMap<DocumentType, Nomenclature>();
                cfg.CreateMap<Nomenclature, DocumentType>();
            });

            mapper = config.CreateMapper();
        }


        #region Violations

        public List<Violation> GetViolations()
        {
            var violations = new List<Violation>();
            using (var context = new KatDataContext())
            {
                var result = context.Violations.ToList();
                result.ForEach(r => violations.Add(mapper.Map<Violation>(r)));
                return violations;
            }
        }

        public bool AddViolation(Violation violation)
        {
            try
            {
                var insertViolation = mapper.Map<CodeFirstModels.Nomenclatures.Violation>(violation);
                using (var context = new KatDataContext())
                {
                    context.Violations.Add(insertViolation);
                    context.SaveChanges();
                }

                return true;
            }
            catch (Exception e)
            {
                return false;
            }
        }

        public bool DeleteViolation(long id)
        {
            try
            {
                using (var context = new KatDataContext())
                {
                    var removeViolation = context.Violations.FirstOrDefault(v => v.Id == id);
                    context.Violations.Remove(removeViolation);
                    context.SaveChanges();
                }

                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public bool UpdateViolation(Violation violation)
        {
            try
            {
                var updateViolation = mapper.Map<CodeFirstModels.Nomenclatures.Violation>(violation);
                using (var context = new KatDataContext())
                {
                    var dbRecord = context.Violations.FirstOrDefault(v => v.Id == violation.Id);
                    PropertyCopy.Copy(updateViolation, dbRecord);
                    context.SaveChanges();
                }

                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        #endregion

        #region Cameras

        public List<Camera> GetCameras()
        {
            var cameras = new List<Camera>();
            using (var context = new KatDataContext())
            {
                var result = context.Cameras.ToList();
                result.ForEach(r => cameras.Add(mapper.Map<Camera>(r)));
                return cameras;
            }
        }

        public bool AddCamera(Camera camera)
        {
            try
            {
                var insertCamera = mapper.Map<CodeFirstModels.Nomenclatures.Camera>(camera);
                using (var context = new KatDataContext())
                {
                    context.Cameras.Add(insertCamera);
                    context.SaveChanges();
                }

                return true;
            }
            catch (Exception e)
            {
                return false;
            }
        }

        public bool DeleteCamera(long id)
        {
            try
            {
                using (var context = new KatDataContext())
                {
                    var removeCamera = context.Cameras.FirstOrDefault(c => c.Id == id);
                    context.Cameras.Remove(removeCamera);
                    context.SaveChanges();
                }

                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public bool UpdateCamera(Camera camera)
        {
            try
            {
                var updateCamera = mapper.Map<CodeFirstModels.Nomenclatures.Camera>(camera);
                using (var context = new KatDataContext())
                {
                    var dbRecord = context.Cameras.FirstOrDefault(v => v.Id == camera.Id);
                    PropertyCopy.Copy(updateCamera, dbRecord);
                    context.SaveChanges();
                }

                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        #endregion

        #region Policemen

        public List<Policeman> GetPolicemen()
        {
            var policemen = new List<Policeman>();
            using (var context = new KatDataContext())
            {
                var result = context.Policemеn.ToList();
                result.ForEach(r => policemen.Add(mapper.Map<Policeman>(r)));
                return policemen;
            }
        }

        public bool AddPoliceman(Policeman policeman)
        {
            try
            {
                var insertPoliceman = mapper.Map<CodeFirstModels.Policeman>(policeman);
                using (var context = new KatDataContext())
                {
                    context.Policemеn.Add(insertPoliceman);
                    context.SaveChanges();
                }

                return true;
            }
            catch (Exception e)
            {
                return false;
            }
        }

        public bool DeletePoliceman(long id)
        {
            try
            {
                using (var context = new KatDataContext())
                {
                    var removePolicemеn = context.Policemеn.FirstOrDefault(c => c.Id == id);
                    context.Policemеn.Remove(removePolicemеn);
                    context.SaveChanges();
                }

                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public bool UpdatePoliceman(Policeman policeman)
        {
            try
            {
                var updatePoliceman = mapper.Map<CodeFirstModels.Policeman>(policeman);
                using (var context = new KatDataContext())
                {
                    //var dbRecord = context.Policemеn.FirstOrDefault(v => v.Id == policeman.Id);
                    //PropertyCopy.Copy(updatePoliceman, dbRecord);
                    
                    var docInDb = context.Policemеn.Find(updatePoliceman.Id);

                    if (docInDb == null)
                    {
                        context.Policemеn.Add(updatePoliceman);
                        context.SaveChanges();
                        return true;
                    }

                    context.Entry(docInDb).CurrentValues.SetValues(updatePoliceman);
                    context.Entry(docInDb).State = EntityState.Modified;

                    context.SaveChanges();
                }

                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        #endregion

        #region DocTypes

        public List<Nomenclature> GetDocTypes()
        {
            var docTypes = new List<Nomenclature>();
            using (var context = new KatDataContext())
            {
                var result = context.DocumentTypes.ToList();
                result.ForEach(r => docTypes.Add(mapper.Map<Nomenclature>(r)));
                return docTypes;
            }
        }

        #endregion

        #region Ranks

        public List<Nomenclature> GetRanks()
        {
            var ranks = new List<Nomenclature>();
            using (var context = new KatDataContext())
            {
                var result = context.Ranks.ToList();
                result.ForEach(r => ranks.Add(mapper.Map<Nomenclature>(r)));
                return ranks;
            }
        }

        #endregion
    }
}
