using System;
using System.Collections.Generic;
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
        public NomenclatureService()
        {
            // Violations
            Mapper.CreateMap<CodeFirstModels.Nomenclatures.Violation, Violation>();
            Mapper.CreateMap<Violation, CodeFirstModels.Nomenclatures.Violation>();

            // Cameras
            Mapper.CreateMap<CodeFirstModels.Nomenclatures.Camera, Camera>();
            Mapper.CreateMap<Camera, CodeFirstModels.Nomenclatures.Camera>();

            // Policemen
            Mapper.CreateMap<CodeFirstModels.Policeman, Policeman>();
            Mapper.CreateMap<Policeman, CodeFirstModels.Policeman>();
            Mapper.CreateMap<Rank, Nomenclature>();
            Mapper.CreateMap<Nomenclature, Rank>();
        }


        #region Violations

        public List<Violation> GetViolations()
        {
            var violations = new List<Violation>();
            using (var context = new KatDataContext())
            {
                var result = context.Violations.ToList();
                result.ForEach(r => violations.Add(Mapper.Map<Violation>(r)));
                return violations;
            }
        }

        public bool AddViolation(Violation violation)
        {
            try
            {
                var insertViolation = Mapper.Map<CodeFirstModels.Nomenclatures.Violation>(violation);
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
                var updateViolation = Mapper.Map<CodeFirstModels.Nomenclatures.Violation>(violation);
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
                result.ForEach(r => cameras.Add(Mapper.Map<Camera>(r)));
                return cameras;
            }
        }

        public bool AddCamera(Camera camera)
        {
            try
            {
                var insertCamera = Mapper.Map<CodeFirstModels.Nomenclatures.Camera>(camera);
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
                var updateCamera = Mapper.Map<CodeFirstModels.Nomenclatures.Camera>(camera);
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
                result.ForEach(r => policemen.Add(Mapper.Map<Policeman>(r)));
                return policemen;
            }
        }

        public bool AddPoliceman(Policeman policeman)
        {
            try
            {
                var insertPoliceman = Mapper.Map<CodeFirstModels.Policeman>(policeman);
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
                var updatePoliceman = Mapper.Map<CodeFirstModels.Policeman>(policeman);
                using (var context = new KatDataContext())
                {
                    var dbRecord = context.Policemеn.FirstOrDefault(v => v.Id == policeman.Id);
                    PropertyCopy.Copy(updatePoliceman, dbRecord);
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
    }
}
