using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Garage.Core.Repository;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace IISC.Web.Pages.Garage.Maintain
{
    [Authorize(Roles = "admin,asset,maintenance")]
    public class OverrideModel : PageModel
    {
        private readonly IAssetRepository assetRepository;

        [BindProperty]
        public int AssetId { get; set; }
        
        [BindProperty]
        public string RegNo { get; set; }

        public OverrideModel(IAssetRepository assetRepository)
        {
            this.assetRepository = assetRepository;
        }

        public async Task<IActionResult> OnGet(int Id)
        {
            if (Id > 0)
            {
                var query = await assetRepository.GetAssetDetailById(Id);
                if (query != null)
                {
                    AssetId = query.ID;
                    RegNo = query.RegNo;
                }
            }

            return Page();
        }

        public async Task<IActionResult> OnPost()
        {
            if (AssetId > 0)
            {
                await assetRepository.OverrideMaintenanceStatus(AssetId, 1);
            }
            return RedirectToPage("/Garage/Asset/Index");
        }
    }
}
