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
    public class PlannedModel : PageModel
    {
        private readonly ITransaction transaction;
        private readonly IAssetRepository assetRepository;

        public PlannedModel(ITransaction transaction, IAssetRepository assetRepository)
        {
            this.transaction = transaction;
            this.assetRepository = assetRepository;
            HdrMaintenance = new HdrMaintenance();
        }

        [BindProperty]
        public HdrMaintenance HdrMaintenance { get; set; }

        [BindProperty]
        public AssetViewModel AssetDetail { get; set; }
        public SelectList TypeList { get; set; }
        public IEnumerable<HdrMaintenanceViewModel> HdrMaintenanceList { get; set; }

        public async Task<IActionResult> OnGet(int id)
        {
            HdrMaintenance.BreakdownDate = DateTime.Now;
            HdrMaintenance.DateTimeIn = DateTime.Now;

            TypeList = new SelectList(await transaction.GetMaintenanceType(), nameof(Adm_MaintenanceType.ID), nameof(Adm_MaintenanceType.MaintenanceName));

            if (id > 0)
            {
                AssetDetail = assetRepository.GetAssetById(id);
                HdrMaintenanceList = await transaction.GetMaintenanceByAssetId(AssetDetail.ID);

                HdrMaintenance.CurrentMileage = AssetDetail.CurrentMileage;
            }

            return Page();
        }

        public async Task<IActionResult> OnPost()
        {
            int assetID = AssetDetail.ID;
            HdrMaintenance.AssetID = AssetDetail.ID;
            HdrMaintenance.RegNo = AssetDetail.RegNo;
            HdrMaintenance.LoggedBy = User.Identity.Name;
            HdrMaintenance.CreatedOn = DateTime.Now;
            HdrMaintenance.StatusID = 0;
            HdrMaintenance.CreatedOn = DateTime.Now;

            if (!ModelState.IsValid)
            {
                return Page();
            }

            // Add maintenance header
            var query = await transaction.AddMaintenance(HdrMaintenance);
            assetRepository.UpdateMileage(HdrMaintenance.RegNo, HdrMaintenance.CurrentMileage.Value);

            // Add maintenance parts
            var partsQuery = await transaction.GetScheduleMaintenanceParts(AssetDetail.CategoryID, int.Parse(AssetDetail.Make), int.Parse(AssetDetail.ModelID));

            return RedirectToPage("Unplanned", new { id = assetID });
        }
    }
}
