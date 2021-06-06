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
    public class EditMaintenanceModel : BasePageModel
    {
        private readonly ITransaction transaction;
        private readonly IAssetRepository assetRepository;
        private readonly IDashboardRepository dashboardRepository;

        [BindProperty]
        public HdrMaintenance HdrMaintenance { get; set; }

        public SelectList TypeList { get; set; }
        public IEnumerable<HdrMaintenanceViewModel> HdrMaintenanceList { get; set; }

        [BindProperty]
        public HdrMaintenanceViewModel HdrMaintenanceDetail { get; set; }

        public EditMaintenanceModel(ITransaction transaction, IAssetRepository assetRepository, IDashboardRepository dashboardRepository)
        {
            this.transaction = transaction;
            this.assetRepository = assetRepository;
            this.dashboardRepository = dashboardRepository;
            //HdrMaintenance = new HdrMaintenance();
        }

        public async Task<IActionResult> OnGet(int id)
        {
            TypeList = new SelectList(await transaction.GetMaintenanceType(), nameof(Adm_MaintenanceType.ID), nameof(Adm_MaintenanceType.MaintenanceName));

            HdrMaintenanceDetail = await transaction.GetMaintenanceById(id);
            HdrMaintenance = new HdrMaintenance();
            HdrMaintenance.BreakdownDate = HdrMaintenanceDetail.BreakdownDate;
            HdrMaintenance.DateTimeIn = HdrMaintenanceDetail.DateTimeIn;
            HdrMaintenance.CurrentMileage = HdrMaintenanceDetail.CurrentMileage;
            HdrMaintenance.MaintenanceType = HdrMaintenanceDetail.MaintenanceType;
            HdrMaintenance.MaintenanceSummary = HdrMaintenanceDetail.MaintenanceSummary;

            if (id > 0 && HdrMaintenanceDetail.AssetID > 0)
            {
                HdrMaintenanceList = await transaction.GetMaintenanceByAssetId(HdrMaintenanceDetail.AssetID, 0);
            }

            return Page();
        }

        public async Task<IActionResult> OnPost(int id)
        {
            int assetId = HdrMaintenanceDetail.AssetID;
            HdrMaintenance.AssetID = assetId;
            HdrMaintenance.ID = HdrMaintenanceDetail.ID;
            HdrMaintenance.ModifiedOn = DateTime.Now;
            HdrMaintenance.ModifiedBy = User.Identity.Name;

            try
            {
                if (string.IsNullOrEmpty(HdrMaintenance.MaintenanceSummary.Trim()))
                {
                    Notify("Breakdown summary is required");
                    return Page();
                }
                await transaction.UpdateMaintenance(HdrMaintenance);
                Notify("Maintenance updated successfully");
                return RedirectToPage("Unplanned", new { id  = assetId });
            }
            catch (Exception ex)
            {
                Notify($"An error occurred while updating maintenance, ERROR: {ex} ");
                return Page();
            }
        }
    }
}
