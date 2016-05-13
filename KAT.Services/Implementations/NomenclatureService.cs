using System;
using System.Collections.Generic;
using System.Linq;
using AutoMapper;
using KAT.IServices;
using KAT.Services.NomenclatureWebServiceReference;
using Violation = KAT.Models.Violation.Violation;
using Camera = KAT.Models.Camera.Camera;
using Policeman = KAT.Models.Policeman.Policeman;
using Nomenclature = KAT.Models.Nomenclature.Nomenclature;

namespace KAT.Services.Implementations
{
    public class NomenclatureService : INomenclatureService
    {
        private NomenclatureWebServiceClient client;

        public NomenclatureService()
        {
            Mapper.CreateMap<NomenclatureWebServiceReference.Violation, Violation>();
            Mapper.CreateMap<NomenclatureWebServiceReference.Policeman, Policeman>();
            Mapper.CreateMap<NomenclatureWebServiceReference.Nomenclature, Nomenclature>();
            Mapper.CreateMap<NomenclatureWebServiceReference.Camera, Camera>();
            Mapper.CreateMap<Violation, NomenclatureWebServiceReference.Violation>();
            Mapper.CreateMap<Policeman, NomenclatureWebServiceReference.Policeman>();
            Mapper.CreateMap<Nomenclature, NomenclatureWebServiceReference.Nomenclature>();
            Mapper.CreateMap<Camera, NomenclatureWebServiceReference.Camera>();

            client = new NomenclatureWebServiceClient();
        }

        #region Violations

        public List<Violation> GetViolations()
        {
            var violations = new List<Violation>();
            var result = client.GetViolations().ToList();
            result.ForEach(v => violations.Add(Mapper.Map<Violation>(v)));
            return violations;
        }

        public bool AddViolation(Violation violation)
        {
            var insertViolation = Mapper.Map<NomenclatureWebServiceReference.Violation>(violation);
            return client.AddViolation(insertViolation);
        }

        public bool DeleteViolation(long id)
        {
            return client.DeleteViolation(id);
        }

        public bool UpdateViolation(Violation violation)
        {
            var updateViolation = Mapper.Map<NomenclatureWebServiceReference.Violation>(violation);
            return client.UpdateViolation(updateViolation);
        }

        #endregion

        #region Cameras

        public List<Camera> GetCameras()
        {
            var cameras = new List<Camera>();
            var result = client.GetCameras().ToList();
            result.ForEach(v => cameras.Add(Mapper.Map<Camera>(v)));
            return cameras;
        }

        public bool AddCamera(Camera camera)
        {
            var insertCamera = Mapper.Map<NomenclatureWebServiceReference.Camera>(camera);
            return client.AddCamera(insertCamera);
        }

        public bool DeleteCamera(long id)
        {
            return client.DeleteCamera(id);
        }

        public bool UpdateCamera(Camera camera)
        {
            var updateCamera = Mapper.Map<NomenclatureWebServiceReference.Camera>(camera);
            return client.UpdateCamera(updateCamera);
        }

        #endregion

        #region Policemen

        public List<Policeman> GetPolicemen()
        {
            var policemen = new List<Policeman>();
            var result = client.GetPolicemen().ToList();
            result.ForEach(v => policemen.Add(Mapper.Map<Policeman>(v)));
            return policemen;
        }

        public bool AddPoliceman(Policeman policeman)
        {
            var insertPoliceman = Mapper.Map<NomenclatureWebServiceReference.Policeman>(policeman);
            return client.AddPoliceman(insertPoliceman);
        }

        public bool DeletePoliceman(long id)
        {
            return client.DeletePoliceman(id);
        }

        public bool UpdatePoliceman(Policeman policeman)
        {
            var updatePoliceman = Mapper.Map<NomenclatureWebServiceReference.Policeman>(policeman);
            return client.UpdatePoliceman(updatePoliceman);
        }

        #endregion
    }
}
