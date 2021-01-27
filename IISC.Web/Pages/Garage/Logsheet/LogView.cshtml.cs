using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Garage.Core.Models;
using Garage.Core.Repository;
using Garage.Core.ViewModel;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace IISC.Web.Pages.Garage.Logsheet
{
    public class LogViewModel : PageModel
    {
        private readonly ILogSheetRepository logSheetRepository;

        public LogViewModel(ILogSheetRepository logSheetRepository)
        {
            this.logSheetRepository = logSheetRepository;
        }

        [BindProperty]
        public LogSheetListViewModel LogsheetData { get; set; }

        [BindProperty]
        public IEnumerable<Trn_LogSheet> LogHistory { get; set; }

        public IActionResult OnGet(int Id)
        {
            BindData(Id);
            return Page();
        }

        private void BindData(int Id)
        {
            LogsheetData = logSheetRepository.GetLogSheetById(Id).FirstOrDefault();
            if (LogsheetData != null)
            {
                LogHistory = logSheetRepository.GetLogHistory(LogsheetData.RegNo);
            }
        }

        public IActionResult OnPost()
        {
            double currentValue = 0;
            currentValue = LogsheetData.CurrentValue;

            BindData(LogsheetData.ID);
            if (string.IsNullOrEmpty(LogsheetData.CurrentValue.ToString().Trim()))
            {
                ModelState.AddModelError("Error", $"Current value cannot empty.");
            }
            if (!double.TryParse(LogsheetData.CurrentValue.ToString(), out double result))
            {
                ModelState.AddModelError("Error", $"Current value must be a number.");
            }
            if (currentValue < LogsheetData.PreviousValue)
            {
                // Validate for TRIGGER TYPE
                ModelState.AddModelError("Error", $"Current value is less than previous value recorded.");
            }
            if (!ModelState.IsValid)
            {
                return Page();
            }

            // Update Logsheet data
            LogsheetData.ModifiedBy = User.Identity.Name;
            LogsheetData.CurrentValue = currentValue;
            logSheetRepository.UpdateLogSheet(LogsheetData);

            return RedirectToPage("/Garage/Logsheet/LogList");
        }
    }
}
