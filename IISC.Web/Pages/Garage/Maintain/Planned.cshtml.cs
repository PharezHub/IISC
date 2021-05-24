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
    public class PlannedModel : BasePageModel
    {
        private readonly ITransaction transaction;
        private readonly IAssetRepository assetRepository;
        private readonly IDashboardRepository dashboardRepository;
        private readonly IRoutineRepository routineRepository;

        public PlannedModel(ITransaction transaction, IAssetRepository assetRepository, IDashboardRepository dashboardRepository, 
            IRoutineRepository routineRepository)
        {
            this.transaction = transaction;
            this.assetRepository = assetRepository;
            this.dashboardRepository = dashboardRepository;
            this.routineRepository = routineRepository;
            HdrMaintenance = new HdrMaintenance();
            TrnPartUsed = new TrnPartUsed();
        }

        [BindProperty]
        public HdrMaintenance HdrMaintenance { get; set; }

        [BindProperty]
        public AssetViewModel AssetDetail { get; set; }

        public MaintenanceTriggerSummaryViewModel MaintenanceTriggerSummary { get; set; }

        public TrnPartUsed TrnPartUsed { get; set; }
        public SelectList TypeList { get; set; }
        public IEnumerable<HdrMaintenanceViewModel> HdrMaintenanceList { get; set; }
        public int TotalMaintenance { get; set; }
        public int TotalScheduled { get; set; }
        public int TotalBreakdowns { get; set; }
        public int ActiveBreakdowns { get; set; }
        public int ActiveServices { get; set; }
        public string DifferencePercent { get; set; }
        public double DifferencePercentValue { get; set; }

        public async Task<IActionResult> OnGet(int id)
        {
            HdrMaintenance.BreakdownDate = DateTime.Now;
            HdrMaintenance.DateTimeIn = DateTime.Now;

            TypeList = new SelectList(await transaction.GetMaintenanceType(), nameof(Adm_MaintenanceType.ID), nameof(Adm_MaintenanceType.MaintenanceName));

            if (id > 0)
            {
                AssetDetail = assetRepository.GetAssetById(id);
                HdrMaintenanceList = await transaction.GetMaintenanceByAssetId(AssetDetail.ID);

                TotalMaintenance = await dashboardRepository.GetMaintenanceCounts(AssetDetail.ID,0);
                TotalScheduled = await dashboardRepository.GetMaintenanceCounts(AssetDetail.ID, 2);
                TotalBreakdowns = await dashboardRepository.GetMaintenanceCounts(AssetDetail.ID, 1);
                ActiveBreakdowns = await dashboardRepository.GetMaintenanceCounts(AssetDetail.ID, 3);

                //ActiveServices = await dashboardRepository.GetMaintenanceCounts(AssetDetail.ID, 2);

                HdrMaintenance.CurrentMileage = AssetDetail.CurrentMileage;
                MaintenanceTriggerSummary = routineRepository.GetMaintenanceTriggerSummary(AssetDetail.CategoryID);

                DifferencePercentValue = ((AssetDetail.Difference / MaintenanceTriggerSummary.TriggerValue) * 100);
                DifferencePercent = string.Format("{0:N0}",((AssetDetail.Difference / MaintenanceTriggerSummary.TriggerValue) * 100)) + "%";
                if(DifferencePercentValue >= 100) 
                {
                    DifferencePercent = "100%"; 
                } //else { @Model.DifferencePercent.ToString() }
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

            // Get maintenance parts
            var partsQuery = await transaction.GetScheduleMaintenanceParts(AssetDetail.CategoryID, int.Parse(AssetDetail.Make), int.Parse(AssetDetail.ModelID));

            // Add maintenance parts
            int mainId = query.ID;
            foreach (var item in partsQuery)
            {
                TrnPartUsed.MainID = mainId;
                TrnPartUsed.LoggedBy = User.Identity.Name;
                TrnPartUsed.DateLogged = DateTime.Now;
                TrnPartUsed.Qty = 1;
                TrnPartUsed.ProblemDescription = $"Scheduled - {item.ItemDescription.Trim()}";
                TrnPartUsed.DocketNo = "AUTO";
                TrnPartUsed.PartID = item.ID.ToString();
                TrnPartUsed.PartCost = 0;
                TrnPartUsed.PurchaseOrder = "";

                transaction.AddPartsUsed(TrnPartUsed);
            }

            //Show Message
            Notify($"Planned maintenance submitted successfully");

            return RedirectToPage("Planned", new { id = assetID });
        }

    }
}
