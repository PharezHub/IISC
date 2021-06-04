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
using System.Collections;
using Microsoft.AspNetCore.Authorization;

namespace IISC.Web.Pages.Garage.Maintain
{
    [Authorize(Roles = "admin,asset,maintenance")]
    public class AddPartsModel : BasePageModel
    {
        private readonly ITransaction transaction;
        private readonly IAssetRepository assetRepository;
        private readonly IAxAutoMobileRepository autoMobileRepository;

        public AddPartsModel(ITransaction transaction, IAssetRepository assetRepository, IAxAutoMobileRepository autoMobileRepository)
        {
            this.transaction = transaction;
            this.assetRepository = assetRepository;
            this.autoMobileRepository = autoMobileRepository;
        }

        [BindProperty]
        public TrnPartUsed TrnPartUsed { get; set; }

        [BindProperty]
        public IEnumerable<PartUsedViewModel> PartUsedView { get; set; }

        [BindProperty]
        public AssetViewModel AssetDetail { get; set; }
        public SelectList PartsList { get; set; }

        [BindProperty]
        public HdrMaintenanceViewModel HdrMaintenanceDetail { get; set; }

        public async Task<IActionResult> OnGet(int id)
        {
            if (id > 0)
            {

                HdrMaintenanceDetail = (HdrMaintenanceViewModel) await transaction.GetMaintenanceById(id);
                AssetDetail = assetRepository.GetAssetById(HdrMaintenanceDetail.AssetID);

                //PartsList = new SelectList(assetRepository.GetPartByCategory(AssetDetail.CategoryID, int.Parse(AssetDetail.ModelID),
                //    int.Parse(AssetDetail.Make)), nameof(AdmPartsCatalog.ID), nameof(AdmPartsCatalog.ItemDescription));

                PartsList = new SelectList(await autoMobileRepository.GetAxAutoMobile(), nameof(AXAutoMobileViewModel.ItemId), nameof(AXAutoMobileViewModel.FullDescription));

                //Get maintenance parts used
                PartUsedView = await transaction.GetPartsUsed(HdrMaintenanceDetail.ID);
            }
            return Page();
        }

        //public async Task<IActionResult> OnPost()
        public async Task<IActionResult> OnPost()
        {
            int mainId = HdrMaintenanceDetail.ID;
            int assetId = HdrMaintenanceDetail.AssetID;

            if (!string.IsNullOrEmpty(TrnPartUsed.PartID))
            {
                if (TrnPartUsed.PartID != "0")
                {
                    var query = await autoMobileRepository.GetAxAutoMobileItem(TrnPartUsed.PartID);
                    TrnPartUsed.PartCost = query.ItemPrice;
                }
                else
                {
                    Notify($"Spare part price not found", notificationType:Models.NotificationType.warning);
                    return Page();
                }
            }
            else
            {
                Notify($"Select spare part from the list", notificationType: Models.NotificationType.warning);
                return Page();
            }

            TrnPartUsed.MainID = mainId;
            TrnPartUsed.LoggedBy = User.Identity.Name;
            TrnPartUsed.DateLogged = DateTime.Now;
            TrnPartUsed.Qty = 1;
            
            TrnPartUsed.PurchaseOrder = "";

            if (!ModelState.IsValid)
            {
                return Page();
            }

            transaction.AddPartsUsed(TrnPartUsed);

            //Show Message
            Notify($"Maintenance Part added successfully");

            return RedirectToPage("AddParts", new { id = mainId });
        }
    }
}
