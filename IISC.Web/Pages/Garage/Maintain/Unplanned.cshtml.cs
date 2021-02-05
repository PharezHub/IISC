using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Garage.Core.Models;
using Garage.Core.Repository;
using Garage.Core.ViewModel;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace IISC.Web.Pages.Garage.Maintain
{
    public class UnplannedModel : PageModel
    {
        private readonly ITransaction transaction;
        private readonly IAssetRepository assetRepository;

        public UnplannedModel(ITransaction transaction, IAssetRepository assetRepository)
        {
            this.transaction = transaction;
            this.assetRepository = assetRepository;
        }

        [BindProperty]
        public HdrMaintenance HdrMaintenance { get; set; }
        [BindProperty]
        public AssetViewModel AssetDetail { get; set; }
        public SelectList TypeList { get; set; }
        public IEnumerable<HdrMaintenanceViewModel> HdrMaintenanceList { get; set; }

        public async Task<IActionResult> OnGet(int id)
        {
            TypeList = new SelectList(await transaction.GetMaintenanceType(), nameof(Adm_MaintenanceType.ID), nameof(Adm_MaintenanceType.MaintenanceName));

            if (id > 0)
            {
                AssetDetail = assetRepository.GetAssetById(id);
                HdrMaintenanceList = await transaction.GetMaintenanceByAssetId(AssetDetail.ID);
            }

            return Page();
        }

        public async Task<IActionResult> OnPost()
        {
            int assetID = AssetDetail.ID;
            HdrMaintenance.AssetID = AssetDetail.ID;
            HdrMaintenance.RegNo = AssetDetail.RegNo;
            HdrMaintenance.LoggedBy = User.Identity.Name;
            HdrMaintenance.StatusID = 0;
            HdrMaintenance.DateIn = DateTime.Now;

            if (!ModelState.IsValid)
            {
                return Page();
            }

            var query = await transaction.AddMaintenance(HdrMaintenance);
            return RedirectToPage("Unplanned", new { id = assetID });
        }
    }
}
