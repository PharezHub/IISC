using Garage.Core.Models;
using Garage.Core.ViewModel;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Garage.Core.Repository
{
    public interface IAssetRepository
    {
        IEnumerable<AssetCatalogueViewModel> GetAssetCatelogueList();
        List<Adm_InsuranceType> GetInsuranceType();

        void AddStatutory(Hdr_StatutoryRequirement statutoryRequirement);
        bool ValidateRegNumber(string regNo);
        bool ValidateEngineNumber(string engineNo);

        IEnumerable<AssetCatalogueViewModel> OnSiteUtilization();
        IEnumerable<AssetCatalogueViewModel> OffSiteUtilization();
        AssetViewModel GetAssetById(int Id);

        // Parts Catalog
        void AddPartsCatalog(AdmPartsCatalog catalog);
        IEnumerable<PartsCatalogViewModel> GetPartsCatalog();
        bool ValidatePartCatalog(string itemDescription, int categoryId, int modelId, int makeId);
        AdmPartsCatalog GetPartsCatalogById(int Id);
        void UpdatePartsCatalog(AdmPartsCatalog catalog);
        void DeletePartCatalog(int id);
        IEnumerable<AdmPartsCatalog> GetPartByCategory(int categoryId, int modelId, int makeId);
        void UpdateMileage(string regNo, double newMileage);
    }
}
