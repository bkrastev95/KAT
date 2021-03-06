﻿using System.Collections.Generic;
using KAT.Web.Models;

namespace KAT.Data.IServices
{
    public interface INomenclatureService
    {
        #region Violations

        List<Violation> GetViolations();

        bool AddViolation(Violation violation);

        bool DeleteViolation(long id);

        bool UpdateViolation(Violation violation);

        #endregion

        #region Cameras

        List<Camera> GetCameras();

        bool AddCamera(Camera camera);

        bool DeleteCamera(long id);

        bool UpdateCamera(Camera camera);

        #endregion

        #region Policemen

        List<Policeman> GetPolicemen();

        bool AddPoliceman(Policeman policeman);

        bool DeletePoliceman(long id);

        bool UpdatePoliceman(Policeman policeman);

        #endregion

        #region DocTypes

        List<Nomenclature> GetDocTypes();

        #endregion

        #region Ranks

        List<Nomenclature> GetRanks();

        #endregion
    }
}
