using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Garage.Core.Repository;
using Garage.Core.ViewModel;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace IISC.Web.Pages.Garage.Logsheet
{
    public class LoadUtilizationModel : PageModel
    {
        private readonly IAssetRepository assetRepository;
        private readonly ILogSheetRepository logSheetRepository;

        [BindProperty]
        public LogSheetListViewModel LogsheetData { get; set; }
        public AssetViewModel AssetData { get; set; }

        public LoadUtilizationModel(IAssetRepository assetRepository, ILogSheetRepository logSheetRepository)
        {
            this.assetRepository = assetRepository;
            this.logSheetRepository = logSheetRepository;
            LogsheetData = new LogSheetListViewModel();
            AssetData = new AssetViewModel();
        }

        public IActionResult OnGet(int Id)
        {
            AssetData = assetRepository.GetAssetById(Id);
            if (AssetData != null)
            {
                LogsheetData.ID = Id;
                LogsheetData.CategoryName = AssetData.CategoryName;
                LogsheetData.RegNo = AssetData.RegNo;
                LogsheetData.ModelName = AssetData.ModelName;
                LogsheetData.CategoryID = AssetData.CategoryID;
                LogsheetData.PreviousValue = AssetData.CurrentMileage;
                LogsheetData.CurrentValue = 0;
                LogsheetData.Comment = "";
                LogsheetData.AdmLogSheetID = 0;
                LogsheetData.AssetID = 0;
                LogsheetData.CreatedOn = DateTime.Now;
                LogsheetData.FrequencyID = 0;
                LogsheetData.FrequencyName = "";
                LogsheetData.ID = 0;
                LogsheetData.LogType = "";
                LogsheetData.LogTypeID = 0;
                LogsheetData.Make = AssetData.MakeName;
                LogsheetData.ModifiedBy = "";
                LogsheetData.ModifiedOn = DateTime.Now;
                LogsheetData.TransStatus = "";
            }

            return Page();
        }

        public IActionResult OnPost()
        {
            if (string.IsNullOrEmpty(LogsheetData.CurrentValue.ToString().Trim()))
            {
                ModelState.AddModelError("Error", $"Current value cannot empty.");
            }
            if (LogsheetData.CurrentValue < 1 )
            {
                ModelState.AddModelError("Error", $"Invalid input on Current value.");
            }
            if (LogsheetData.CurrentValue < LogsheetData.PreviousValue)
            {
                // Validate for TRIGGER TYPE
                ModelState.AddModelError("Error", $"Current value is less than previous value recorded.");
            }
            if (LogsheetData.Comment == null)
            {
                ModelState.AddModelError("Error", $"Enter driver name on comment.");
            }
            if (LogsheetData.Comment != null)
            {
                if (string.IsNullOrEmpty(LogsheetData.Comment.Trim()))
                {
                    ModelState.AddModelError("Error", $"Enter driver name in comment area.");
                }
            }

            if (!ModelState.IsValid)
            {
                return Page();
            }

            logSheetRepository.AddLogSheet(LogsheetData.CategoryID, LogsheetData.CurrentValue, LogsheetData.RegNo, LogsheetData.Comment.Trim());
            return RedirectToPage("/Garage/Logsheet/LogList");
        }
    }
}
