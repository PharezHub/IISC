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
    public class UpdatePriceModel : PageModel
    {
        private readonly ITransaction transaction;
        private readonly IAssetRepository assetRepository;

        public UpdatePriceModel(ITransaction transaction, IAssetRepository assetRepository)
        {
            this.transaction = transaction;
            this.assetRepository = assetRepository;
        }

        [BindProperty]
        public TrnPartUsed TrnPartUsed { get; set; }

        [BindProperty]
        public AssetViewModel AssetDetail { get; set; }

        [BindProperty]
        public HdrMaintenanceViewModel HdrMaintenanceDetail { get; set; }
        public SelectList PartsList { get; set; }

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
                }
            }
            return Page();
        }

        public async Task<IActionResult> OnPost()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            return Page();
        }
    }
}
