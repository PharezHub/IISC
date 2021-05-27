using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Garage.Core.Models;
using Garage.Core.Repository;
using Garage.Core.ViewModel;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace IISC.Web.Pages.Garage.Maintain
{
    [Authorize(Roles = "admin,asset,maintenance")]
    public class WorkOrderPartsModel : BasePageModel
    {
        private readonly ITransaction transaction;
        private readonly IAssetRepository assetRepository;

        public WorkOrderPartsModel(ITransaction transaction, IAssetRepository assetRepository)
        {
            this.transaction = transaction;
            this.assetRepository = assetRepository;
            TrnWorkOrderParts = new TrnWorkOrderParts();
        }

        [BindProperty]
        public TrnWorkOrderParts TrnWorkOrderParts { get; set; }

        [BindProperty]
        public AssetViewModel AssetDetail { get; set; }

        [BindProperty]
        public HdrMaintenanceViewModel HdrMaintenanceDetail { get; set; }

        [BindProperty]
        public IEnumerable<TrnWorkOrderParts> ListWorkOrderParts { get; set; }
        public SelectList PartsList { get; set; }

        public async Task<IActionResult> OnGet(int Id)
        {
            TrnWorkOrderParts.MaintenanceID = Id;

            HdrMaintenanceDetail = transaction.GetMaintenanceById(Id).FirstOrDefault();
            AssetDetail = assetRepository.GetAssetById(HdrMaintenanceDetail.AssetID);

            PartsList = new SelectList(assetRepository.GetPartByCategory(AssetDetail.CategoryID, int.Parse(AssetDetail.ModelID),
                    int.Parse(AssetDetail.Make)), nameof(AdmPartsCatalog.ID), nameof(AdmPartsCatalog.ItemDescription));

            ListWorkOrderParts = await transaction.GetWorkOrderParts(Id);

            return Page();
        }

        public IActionResult OnPost()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            //submit and rebind
            transaction.AddWOPartsUsed(TrnWorkOrderParts);

            //Show Message
            Notify($"Work order part added successfully");

            return RedirectToPage("WorkOrderParts", new { id = TrnWorkOrderParts.MaintenanceID });
        }
    }
}
