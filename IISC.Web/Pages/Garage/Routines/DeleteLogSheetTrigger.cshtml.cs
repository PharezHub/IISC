using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Garage.Core.Models;
using Garage.Core.Repository;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace IISC.Web.Pages.Garage.Routines
{
    public class DeleteLogSheetTriggerModel : BasePageModel
    {
        private readonly IRoutineRepository routineRepository;

        public DeleteLogSheetTriggerModel(IRoutineRepository routineRepository)
        {
            this.routineRepository = routineRepository;
        }

        [BindProperty]
        public int LogId { get; set; }


        public IActionResult OnGet(int id)
        {
            LogId = id;
            return Page();
        }

        public IActionResult OnPost()
        {
            if (LogId > 0)
            {
                routineRepository.DeleteLogSheetTrigger(LogId);

                //Show Message
                Notify("Maintenance log sheet deleted successfully", notificationType:Models.NotificationType.warning);
            }
            return RedirectToPage("/Garage/Routines/SetupTrigger");
        }
    }
}
