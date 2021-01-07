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
    public class TriggersModel : PageModel
    {
        private readonly IRoutineRepository routineRepository;

        [BindProperty]
        public Adm_TriggerType TriggerType { get; set; }

        [BindProperty]
        public IEnumerable<Adm_TriggerType> TriggerTypeList { get; set; }

        public TriggersModel(IRoutineRepository routineRepository)
        {
            this.routineRepository = routineRepository;
        }

        public void OnGet()
        {
            TriggerTypeList = routineRepository.GetAllTriggerTypes();
        }

        public IActionResult OnPost()
        {
            if (ModelState.IsValid)
            {
                routineRepository.AddTrigger(TriggerType);
            }
            return RedirectToPage("/Garage/Routines/Triggers");
        }
    }
}
