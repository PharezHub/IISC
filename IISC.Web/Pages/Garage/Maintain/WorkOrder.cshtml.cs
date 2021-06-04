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
    public class WorkOrderModel : BasePageModel
    {
        private readonly ITransaction transaction;
        private readonly IAssetRepository assetRepository;

        public WorkOrderModel(ITransaction transaction, IAssetRepository assetRepository)
        {
            this.transaction = transaction;
            this.assetRepository = assetRepository;
            WorkOrderHdr = new WorkOrderHdr();
        }

        [BindProperty]
        public WorkOrderHdr WorkOrderHdr { get; set; }

        [BindProperty]
        public IEnumerable<WorkOrderHdrViewModel> WorkOrderHdrView { get; set; }

        [BindProperty]
        public AssetViewModel AssetDetail { get; set; }

        [BindProperty]
        public HdrMaintenanceViewModel HdrMaintenanceDetail { get; set; }

        public SelectList SectionList { get; set; }
        public SelectList PriorityList { get; set; }
        public SelectList PurposeList { get; set; }
        public SelectList ReasonList { get; set; }
        

        public async Task<IActionResult> OnGet(int Id)
        {
            SectionList = new SelectList(await transaction.GetSection(), nameof(AdmSection.ID), nameof(AdmSection.SectionName));
            PriorityList = new SelectList(await transaction.GetPriority(), nameof(AdmPriority.ID), nameof(AdmPriority.PriorityName));
            PurposeList = new SelectList(await transaction.GetPurpose(), nameof(AdmPurpose.ID), nameof(AdmPurpose.PurposeDescription));
            ReasonList = new SelectList(await transaction.GetReason(), nameof(AdmReason.ID), nameof(AdmReason.ReasonOfFailure));

            WorkOrderHdr.MaintenanceID = Id;
            HdrMaintenanceDetail = (HdrMaintenanceViewModel) await transaction.GetMaintenanceById(Id);
            AssetDetail = assetRepository.GetAssetById(HdrMaintenanceDetail.AssetID);
            WorkOrderHdrView = await transaction.GetWorkOrderHdr(Id);

            return Page();
        }

        public async Task<IActionResult> OnPost()
        {
            WorkOrderHdr.LoggedBy = User.Identity.Name;
            WorkOrderHdr.LoggedDate = DateTime.Now;

            if (!ModelState.IsValid)
            {
                return Page();
            }
            WorkOrderHdrView = await transaction.GetWorkOrderHdr(WorkOrderHdr.MaintenanceID);
            if (WorkOrderHdrView != null)
            {
                //submit and rebind
                await transaction.AddWorkOrder(WorkOrderHdr);

                //Show Message
                Notify($"Maintenance work order added successfully");
            }
            return RedirectToPage("WorkOrder", new { id = WorkOrderHdr.MaintenanceID });
        }

        //public void OnPostSubmitWorkOrderParts(TrnWorkOrderParts WOparts)
        //{

        //}
    }
}
