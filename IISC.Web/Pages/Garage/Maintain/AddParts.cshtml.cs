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
                await LoadDetails(id);
                //PartsList = new SelectList(assetRepository.GetPartByCategory(AssetDetail.CategoryID, int.Parse(AssetDetail.ModelID),
                //    int.Parse(AssetDetail.Make)), nameof(AdmPartsCatalog.ID), nameof(AdmPartsCatalog.ItemDescription));
            }
            return Page();
        }

        private async Task LoadDetails(int id)
        {
            HdrMaintenanceDetail = await transaction.GetMaintenanceById(id);
            AssetDetail = assetRepository.GetAssetById(HdrMaintenanceDetail.AssetID);
            PartsList = new SelectList(await autoMobileRepository.GetAxAutoMobile(), 
                nameof(AXAutoMobileViewModel.ItemId), nameof(AXAutoMobileViewModel.FullDescription));
            //Get maintenance parts used
            PartUsedView = await transaction.GetPartsUsed(HdrMaintenanceDetail.ID);
        }

        public async Task<IActionResult> OnPost(int id)
        {
            int mainId = HdrMaintenanceDetail.ID;
            int assetId = HdrMaintenanceDetail.AssetID;

            await LoadDetails(id);

            if (!string.IsNullOrEmpty(TrnPartUsed.PartID))
            {
                if (TrnPartUsed.PartID != "0")
                {
                    var query = await autoMobileRepository.GetAxAutoMobileItem(TrnPartUsed.PartID);
                    TrnPartUsed.PartCost = query.ItemPrice;
                    if (TrnPartUsed.Qty < 1 )
                    {
                        Notify($"Quantity {TrnPartUsed.Qty} is invalid. Enter valid Quantity","Missing Field", notificationType: Models.NotificationType.warning);
                        return Page();
                    }
                }
                else
                {
                    Notify($"Spare part price not found, select 'Spare Part' from the list","Invalid Selection", notificationType:Models.NotificationType.warning);
                    return Page();
                }
            }
            else
            {
                Notify($"Select spare part from the list","Invalid Selection", notificationType: Models.NotificationType.warning);
                return Page();
            }

            TrnPartUsed.MainID = mainId;
            TrnPartUsed.LoggedBy = User.Identity.Name;
            TrnPartUsed.DateLogged = DateTime.Now;
            //TrnPartUsed.Qty = 1;
            TrnPartUsed.IsDeleted = false;

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

        public async Task<IActionResult> OnGetDeletePart(int deleteId, int id)
        {
            int mainId = id; //drMaintenanceDetail.ID;
            if (deleteId > 0)
            {
                await transaction.DeletePartUsed(deleteId);
                Notify("Part deleted successfully", "Spare Part Deletion", Models.NotificationType.info);
            }

            return RedirectToPage("AddParts", new { id = mainId });
        }
        public async Task<IActionResult> OnGetIncreasePart(int itemId, int id)
        {
            int mainId = id; //drMaintenanceDetail.ID;
            if (itemId > 0)
            {
                await transaction.IncreasePartUsed(itemId);
                //Notify("Part deleted successfully", "Spare Part Deletion", Models.NotificationType.info);
            }

            return RedirectToPage("AddParts", new { id = mainId });
        }

        public async Task<IActionResult> OnGetDecreasePart(int itemId, int id)
        {
            int mainId = id; //drMaintenanceDetail.ID;
            if (itemId > 0)
            {
                await transaction.DecreasePartUsed(itemId);
                //Notify("Part deleted successfully", "Spare Part Deletion", Models.NotificationType.info);
            }

            return RedirectToPage("AddParts", new { id = mainId });
        }
    }
}
