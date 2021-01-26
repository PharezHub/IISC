using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Garage.Core.Repository;
using Garage.Core.ViewModel;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace IISC.Web.Pages.Garage.Logsheet
{
    public class UtilizationModel : PageModel
    {
        private readonly IAssetRepository assetRepository;

        public UtilizationModel(IAssetRepository assetRepository)
        {
            this.assetRepository = assetRepository;
        }

        public IEnumerable<AssetCatalogueViewModel> OnSiteList { get; set; }
        public IEnumerable<AssetCatalogueViewModel> OffSiteList { get; set; }

        public IActionResult OnGet()
        {
            OnSiteList = assetRepository.OnSiteUtilization();
            OffSiteList = assetRepository.OffSiteUtilization();
            return Page();
        }
    }
}
