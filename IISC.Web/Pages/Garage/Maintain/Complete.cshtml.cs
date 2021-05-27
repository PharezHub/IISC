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

namespace IISC.Web.Pages.Garage.Maintain
{
    [Authorize(Roles = "admin,asset,maintenance")]
    public class CompleteModel : BasePageModel
    {
        private readonly ITransaction transaction;
        private readonly IAssetRepository assetRepository;

        public CompleteModel(ITransaction transaction, IAssetRepository assetRepository)
        {
            this.transaction = transaction;
            this.assetRepository = assetRepository;
            HdrMaintenance = new HdrMaintenance();
        }

        [BindProperty]
        public AssetViewModel AssetDetail { get; set; }

        [BindProperty]
        public HdrMaintenanceViewModel HdrMaintenanceDetail { get; set; }

        [BindProperty]
        public HdrMaintenance HdrMaintenance { get; set; }

        public IActionResult OnGet(int id)
        {
            HdrMaintenance.DateClosed = DateTime.Now;

            if (id > 0)
            {
                HdrMaintenanceDetail = transaction.GetMaintenanceById(id).FirstOrDefault();
                AssetDetail = assetRepository.GetAssetById(HdrMaintenanceDetail.AssetID);
            }
            return Page();
        }

        public IActionResult OnPost()
        {
            //complete works
            HdrMaintenance.ID = HdrMaintenanceDetail.ID;
            HdrMaintenance.AssetID = AssetDetail.ID;
            HdrMaintenance.RegNo = AssetDetail.RegNo;
            HdrMaintenance.ModifiedBy = User.Identity.Name;

            transaction.UpdateMaintenance(HdrMaintenance.ID, 1, HdrMaintenance.ClosureComment, HdrMaintenance.DateClosed.Value, HdrMaintenance.ModifiedBy);

            //Show Message
            Notify("Maintenance completed successfully!!!");

            return RedirectToPage("/Garage/Asset/Index");
        }
    }
}
