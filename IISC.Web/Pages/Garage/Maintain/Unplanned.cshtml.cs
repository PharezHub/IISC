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
        private readonly IDashboardRepository dashboardRepository;

        public UnplannedModel(ITransaction transaction, IAssetRepository assetRepository, IDashboardRepository dashboardRepository)
        {
            this.transaction = transaction;
            this.assetRepository = assetRepository;
            this.dashboardRepository = dashboardRepository;
            HdrMaintenance = new HdrMaintenance();
        }

        [BindProperty]
        public HdrMaintenance HdrMaintenance { get; set; }

        [BindProperty]
        public AssetViewModel AssetDetail { get; set; }
        public SelectList TypeList { get; set; }
        public IEnumerable<HdrMaintenanceViewModel> HdrMaintenanceList { get; set; }
        public int TotalMaintenance { get; set; }
        public int TotalScheduled { get; set; }
        public int TotalBreakdowns { get; set; }
        public int ActiveBreakdowns { get; set; }

        public async Task<IActionResult> OnGet(int id)
        {
            HdrMaintenance.BreakdownDate = DateTime.Now;
            HdrMaintenance.DateTimeIn = DateTime.Now;

            TypeList = new SelectList(await transaction.GetMaintenanceType(), nameof(Adm_MaintenanceType.ID), nameof(Adm_MaintenanceType.MaintenanceName));

            if (id > 0)
            {
                AssetDetail = assetRepository.GetAssetById(id);
                HdrMaintenanceList = await transaction.GetMaintenanceByAssetId(AssetDetail.ID);

                TotalMaintenance = await dashboardRepository.GetMaintenanceCounts(AssetDetail.ID, 0);
                TotalScheduled = await dashboardRepository.GetMaintenanceCounts(AssetDetail.ID, 2);
                TotalBreakdowns = await dashboardRepository.GetMaintenanceCounts(AssetDetail.ID, 1);
                ActiveBreakdowns = await dashboardRepository.GetMaintenanceCounts(AssetDetail.ID, 3);

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

            //TODO: validate mileage captured
            if (HdrMaintenance.CurrentMileage.Value < AssetDetail.CurrentMileage)
            {
                return RedirectToPage("Unplanned", new { id = assetID });
                //ModelState.AddModelError("Error", $"Current value is less than previous value recorded.");
            }

            var query = await transaction.AddMaintenance(HdrMaintenance);
            assetRepository.UpdateMileage(HdrMaintenance.RegNo, HdrMaintenance.CurrentMileage.Value);
            return RedirectToPage("Unplanned", new { id = assetID });
        }
    }
}
