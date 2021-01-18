using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Garage.Core.Repository;
using Garage.Core.ViewModel;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace IISC.Web.Pages.Garage.Asset
{
    public class IndexModel : PageModel
    {
        private readonly IAssetRepository assetRepository;

        public IndexModel(IAssetRepository assetRepository)
        {
            this.assetRepository = assetRepository;
        }

        public IEnumerable<AssetCatalogueViewModel> AssetCatalogueList { get; set; }

        public IActionResult OnGet()
        {
            AssetCatalogueList = assetRepository.GetAssetCatelogueList();

            return Page();
        }
    }
}
