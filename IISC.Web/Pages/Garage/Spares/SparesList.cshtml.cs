using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Garage.Core.Repository;
using Garage.Core.ViewModel;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace IISC.Web.Pages.Garage.Spares
{
    public class SparesListModel : PageModel
    {
        private readonly IAssetRepository assetRepository;

        public SparesListModel(IAssetRepository assetRepository)
        {
            this.assetRepository = assetRepository;
        }

        public IEnumerable<PartsCatalogViewModel> PartsCatalogList { get; set; }

        public IActionResult OnGet()
        {
            PartsCatalogList = assetRepository.GetPartsCatalog();
            return Page();
        }
    }
}
