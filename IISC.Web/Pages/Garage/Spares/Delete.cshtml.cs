using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Garage.Core.Models;
using Garage.Core.Repository;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace IISC.Web.Pages.Garage.Spares
{
    [Authorize(Roles = "admin,asset,maintenance")]
    public class DeleteModel : BasePageModel
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

                //Show Message
                Notify("Spare part deleted successfully", notificationType:Models.NotificationType.warning);
            }
            return RedirectToPage("/Garage/Spares/SparesList");
        }
    }
}
