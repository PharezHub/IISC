using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Garage.Core.Models;
using Garage.Core.Repository;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace IISC.Web.Pages.Garage.Routines
{
    [Authorize(Roles = "admin,asset,maintenance")]
    public class EditTriggerModel : BasePageModel
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

                //Show Message
                Notify("Trigger updated successfully");
            }

            return RedirectToPage("/Garage/Routines/Triggers");
        }
    }
}
