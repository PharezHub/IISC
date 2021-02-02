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
    public class ViewModel : PageModel
    {
        private readonly IAssetRepository assetRepository;

        public AssetViewModel AssetDetail { get; set; }

        public ViewModel(IAssetRepository assetRepository)
        {
            this.assetRepository = assetRepository;
        }

        public IActionResult OnGet(int id)
        {
            if (id > 0)
            {
                AssetDetail = assetRepository.GetAssetById(id);
            }
            return Page();
        }
    }
}
