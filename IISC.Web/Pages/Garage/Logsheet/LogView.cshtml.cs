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
    public class LogViewModel : PageModel
    {
        private readonly ILogSheetRepository logSheetRepository;

        public LogViewModel(ILogSheetRepository logSheetRepository)
        {
            this.logSheetRepository = logSheetRepository;
        }

        [BindProperty]
        public LogSheetListViewModel LogsheetData { get; set; }

        public IActionResult OnGet(int id)
        {
            LogsheetData = logSheetRepository.GetLogSheetById(id).FirstOrDefault();
            return Page();
        }
    }
}
