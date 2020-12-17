using Garage.Core.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Garage.Core.Repository
{
    public interface IGarageSettings
    {
        #region // Manage asset category
        void AddCategory(Adm_AssetCategory category);
        void UpdateCategory(Adm_AssetCategory category);
        void DeleteCategory(Adm_AssetCategory category);
        List<Adm_AssetCategory> GetAllCategory();
        Adm_AssetCategory GetCategoryById(int id);

        #endregion
    }
}
