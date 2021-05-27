using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Garage.Core.Repository;
using Garage.Core.ViewModel;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace IISC.Web.Pages.Garage.Logsheet
{
    [Authorize(Roles = "admin,user,asset,fuel,maintenance,utilization")]
    public class FuelConsumptionListModel : PageModel
    {
        private readonly IAssetRepository assetRepository;
        private readonly ILogSheetRepository logSheetRepository;

        public FuelConsumptionListModel(IAssetRepository assetRepository, ILogSheetRepository logSheetRepository)
        {
            this.assetRepository = assetRepository;
            this.logSheetRepository = logSheetRepository;
        }

        public IEnumerable<AssetCatalogueViewModel> AssetCatalogueList { get; set; }
        public IEnumerable<FuelConsumptionViewModel> FuelConsumptionList { get; set; }

        public async Task<IActionResult> OnGet()
        {
            AssetCatalogueList = await assetRepository.GetAssetCatelogueList();
            FuelConsumptionList = await logSheetRepository.GetFuelConsumption();
            return Page();
        }
    }
}
