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
    public class EditTriggerModel : PageModel
    {
        private readonly IRoutineRepository routineRepository;

        [BindProperty]
        public Adm_TriggerType TriggerType { get; set; }
        public EditTriggerModel(IRoutineRepository routineRepository)
        {
            this.routineRepository = routineRepository;
        }

        public IActionResult OnGet(int id)
        {
            TriggerType = routineRepository.GetTriggerById(id);

            if (TriggerType == null)
            {
                return RedirectToPage("NotFound");
            }
            return Page();
        }

        public IActionResult OnPost()
        {
            if (ModelState.IsValid)
            {
                routineRepository.UpdateTrigger(TriggerType);
            }
            return RedirectToPage("/Garage/Routines/Triggers");
        }
    }
}
