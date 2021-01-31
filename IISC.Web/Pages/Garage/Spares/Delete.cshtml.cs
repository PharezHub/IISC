using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Garage.Core.Models;
using Garage.Core.Repository;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace IISC.Web.Pages.Garage.Spares
{
    public class DeleteModel : PageModel
    {
        private readonly IAssetRepository assetRepository;

        public DeleteModel(IAssetRepository assetRepository)
        {
            this.assetRepository = assetRepository;
        }

        [BindProperty]
        public AdmPartsCatalog PartsCatalog { get; set; }

        public IActionResult OnGet(int id)
        {
            PartsCatalog = assetRepository.GetPartsCatalogById(id);
            return Page();
        }

        public IActionResult OnPost()
        {
            if (PartsCatalog.ID > 1)
            {
                assetRepository.DeletePartCatalog(PartsCatalog.ID);
            }
            return RedirectToPage("/Garage/Spares/SparesList");
        }
    }
}
