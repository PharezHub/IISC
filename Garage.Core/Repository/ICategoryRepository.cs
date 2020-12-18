using Garage.Core.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Garage.Core.Repository
{
    public interface ICategoryRepository
    {
        #region // Manage asset category
        void AddCategory(Adm_AssetCategory category);
        void UpdateCategory(Adm_AssetCategory category);
        void DeleteCategory(Adm_AssetCategory category);
        bool ValidateCategory(Adm_AssetCategory category);
        List<Adm_AssetCategory> GetAllCategory();
        Adm_AssetCategory GetCategoryById(int id);
        #endregion

        #region // Manage Statutory Requirements
        void AddStatutory(Adm_Statutory statutory);
        void UpdateStatutory(Adm_Statutory statutory);
        void DeleteStatutory(Adm_Statutory statutory);
        List<Adm_Statutory> GetAllStatutory();
        Adm_Statutory GetStatutoryById(int id);

        #endregion
    }
}
