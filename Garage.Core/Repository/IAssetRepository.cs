using Garage.Core.Models;
using Garage.Core.ViewModel;
using System;
using System.Collections.Generic;
using System.Text;

namespace Garage.Core.Repository
{
    public interface IAssetRepository
    {
        IEnumerable<AssetCatalogueViewModel> GetAssetCatelogueList();
        List<Adm_InsuranceType> GetInsuranceType();
    }
}
