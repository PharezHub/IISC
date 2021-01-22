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
    public class LogListModel : PageModel
    {
        private readonly ILogSheetRepository logSheetRepository;

        public LogListModel(ILogSheetRepository logSheetRepository)
        {
            this.logSheetRepository = logSheetRepository;
        }

        public IEnumerable<LogSheetListViewModel> LogSheetList { get; set; }

        public IActionResult OnGet()
        {
            LogSheetList = logSheetRepository.GetLogSheetList();
            return Page();
        }
    }
}
