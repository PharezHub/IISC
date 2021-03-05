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
    public class AddPartsModel : PageModel
    {
        private readonly ITransaction transaction;
        private readonly IAssetRepository assetRepository;

        public AddPartsModel(ITransaction transaction, IAssetRepository assetRepository)
        {
            this.transaction = transaction;
            this.assetRepository = assetRepository;
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
                
                HdrMaintenanceDetail = transaction.GetMaintenanceById(id).FirstOrDefault();
                AssetDetail = assetRepository.GetAssetById(HdrMaintenanceDetail.AssetID);

                PartsList = new SelectList(assetRepository.GetPartByCategory(AssetDetail.CategoryID, int.Parse(AssetDetail.ModelID), 
                    int.Parse(AssetDetail.Make)), nameof(AdmPartsCatalog.ID), nameof(AdmPartsCatalog.ItemDescription));

                //Get maintenance parts used
                PartUsedView = await transaction.GetPartsUsed(HdrMaintenanceDetail.ID);
            }
            return Page();
        }

        //public async Task<IActionResult> OnPost()
        public IActionResult OnPost()
        {
            int mainId = HdrMaintenanceDetail.ID;
            int assetId = HdrMaintenanceDetail.AssetID;

            TrnPartUsed.MainID = mainId;
            TrnPartUsed.LoggedBy = User.Identity.Name;
            TrnPartUsed.DateLogged = DateTime.Now;
            TrnPartUsed.Qty = 1;
            TrnPartUsed.PartCost = 0;
            TrnPartUsed.PurchaseOrder = "";

            if (!ModelState.IsValid)
            {
                return Page();
            }

            transaction.AddPartsUsed(TrnPartUsed);

            return RedirectToPage("AddParts", new { id = mainId });
        }
    }
}
