using System.Collections.Generic;
using KAT.Data.IServices;
using KAT.Web.Models;
using KAT.Web.Service.Ninject;
using Ninject;

namespace KAT.Web.Service.Nomenclature
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "NomenclatureWebService" in code, svc and config file together.
    // NOTE: In order to launch WCF Test Client for testing this service, please select NomenclatureWebService.svc or NomenclatureWebService.svc.cs at the Solution Explorer and start debugging.
    public class NomenclatureWebService : INomenclatureWebService
    {
        private readonly INomenclatureService nomenclatureService;

        public NomenclatureWebService()
        {
            NinjectConfig.ConfigureContainer();
            nomenclatureService = NinjectConfig.Kernel.Get<INomenclatureService>();
        }

        public List<Violation> GetViolations()
        {
            return nomenclatureService.GetViolations();
        }


        public bool AddViolation(Violation violation)
        {
            return nomenclatureService.AddViolation(violation);
        }

        public bool DeleteViolation(long id)
        {
            return nomenclatureService.DeleteViolation(id);
        }

        public bool UpdateViolation(Violation violation)
        {
            return nomenclatureService.UpdateViolation(violation);
        }

        public List<Camera> GetCameras()
        {
            return nomenclatureService.GetCameras();
        }

        public bool AddCamera(Camera camera)
        {
            return nomenclatureService.AddCamera(camera);
        }

        public bool DeleteCamera(long id)
        {
            return nomenclatureService.DeleteCamera(id);
        }

        public bool UpdateCamera(Camera camera)
        {
            return nomenclatureService.UpdateCamera(camera);
        }

        public List<Policeman> GetPolicemen()
        {
            return nomenclatureService.GetPolicemen();
        }

        public bool AddPoliceman(Policeman policeman)
        {
            return nomenclatureService.AddPoliceman(policeman);
        }

        public bool DeletePoliceman(long id)
        {
            return nomenclatureService.DeletePoliceman(id);
        }

        public bool UpdatePoliceman(Policeman policeman)
        {
            return nomenclatureService.UpdatePoliceman(policeman);
        }
    }
}
