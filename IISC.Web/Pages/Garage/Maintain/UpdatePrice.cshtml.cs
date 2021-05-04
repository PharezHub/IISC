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
    public class UpdatePriceModel : BasePageModel
    {
        private readonly ITransaction transaction;
        private readonly IAssetRepository assetRepository;
        private readonly IRoutineRepository routineRepository;

        public UpdatePriceModel(ITransaction transaction, IAssetRepository assetRepository, IRoutineRepository routineRepository)
        {
            this.transaction = transaction;
            this.assetRepository = assetRepository;
            this.routineRepository = routineRepository;
        }

        public MaintenanceTriggerSummaryViewModel MaintenanceTriggerSummary { get; set; }

        [BindProperty]
        public TrnPartUsed TrnPartUsed { get; set; }

        [BindProperty]
        public AssetViewModel AssetDetail { get; set; }

        [BindProperty]
        public HdrMaintenanceViewModel HdrMaintenanceDetail { get; set; }
        public SelectList PartsList { get; set; }
        public string DifferencePercent { get; set; }
        public double DifferencePercentValue { get; set; }

        public async Task<IActionResult> OnGet(int id)
        {
            if (id > 0)
            {
                TrnPartUsed = await transaction.GetPartsUsedById(id);
                if (TrnPartUsed != null)
                {
                    HdrMaintenanceDetail = transaction.GetMaintenanceById(TrnPartUsed.MainID).FirstOrDefault();
                    AssetDetail = assetRepository.GetAssetById(HdrMaintenanceDetail.AssetID);

                    PartsList = new SelectList(assetRepository.GetPartByCategory(AssetDetail.CategoryID, int.Parse(AssetDetail.ModelID),
                        int.Parse(AssetDetail.Make)), nameof(AdmPartsCatalog.ID), nameof(AdmPartsCatalog.ItemDescription));

                    MaintenanceTriggerSummary = routineRepository.GetMaintenanceTriggerSummary(AssetDetail.CategoryID);

                    DifferencePercentValue = ((AssetDetail.Difference / MaintenanceTriggerSummary.TriggerValue) * 100);
                    DifferencePercent = string.Format("{0:N0}", ((AssetDetail.Difference / MaintenanceTriggerSummary.TriggerValue) * 100)) + "%";
                    if (DifferencePercentValue >= 100)
                    {
                        DifferencePercent = "100%";
                    }
                }
            }
            return Page();
        }

        public async Task<IActionResult> OnPost()
        {
            if (string.IsNullOrEmpty(TrnPartUsed.PurchaseOrder.Trim()))
            {
                TrnPartUsed.PurchaseOrder = "NA";
            }
            await transaction.UpdatePartUsed(TrnPartUsed);

            //Show Message
            Notify($"Part price updated successfully", notificationType:Models.NotificationType.info);


            //redirect to maintenance page for adding spare parts
            return RedirectToPage("AddParts", new { id = TrnPartUsed.MainID });
        }
    }
}
