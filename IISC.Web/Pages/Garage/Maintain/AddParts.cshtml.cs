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
        public HdrMaintenance HdrMaintenance { get; set; }

        [BindProperty]
        public TrnMaintenance TrnMaintenance { get; set; }

        [BindProperty]
        public AssetViewModel AssetDetail { get; set; }
        public SelectList PartsList { get; set; }
        public HdrMaintenanceViewModel HdrMaintenanceDetail { get; set; }

        public IActionResult OnGet(int id)
        {
            if (id > 0)
            {
                
                HdrMaintenanceDetail = transaction.GetMaintenanceById(id).FirstOrDefault();
                AssetDetail = assetRepository.GetAssetById(HdrMaintenanceDetail.AssetID);

                PartsList = new SelectList(assetRepository.GetPartByCategory(AssetDetail.CategoryID, int.Parse(AssetDetail.ModelID), 
                    int.Parse(AssetDetail.Make)), nameof(AdmPartsCatalog.ID), nameof(AdmPartsCatalog.ItemDescription));
            }
            return Page();
        }

        public IActionResult OnPost()
        {

            return Page();
        }
    }
}
