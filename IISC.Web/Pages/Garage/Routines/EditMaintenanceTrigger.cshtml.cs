using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Garage.Core.Models;
using Garage.Core.Repository;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace IISC.Web.Pages.Garage.Routines
{
    public class EditMaintenanceTriggerModel : PageModel
    {
        private readonly IRoutineRepository routineRepository;
        private readonly ICategoryRepository categoryRepository;

        [BindProperty]
        public Adm_ManageTrigger ManageTrigger { get; set; }
        public SelectList CategoryList { get; set; }
        public SelectList TriggerList { get; set; }

        public EditMaintenanceTriggerModel(IRoutineRepository routineRepository, ICategoryRepository categoryRepository)
        {
            this.routineRepository = routineRepository;
            this.categoryRepository = categoryRepository;
        }

        public IActionResult OnGet(int id)
        {
            CategoryList = new SelectList(categoryRepository.GetAllCategory(),
                nameof(Adm_AssetCategory.ID), nameof(Adm_AssetCategory.CategoryName));

            TriggerList = new SelectList(routineRepository.GetAllTriggerTypes(),
                nameof(Adm_TriggerType.ID), nameof(Adm_TriggerType.TriggerName));

            ManageTrigger = routineRepository.GetManageTriggerById(id);

            if (ManageTrigger == null)
            {
                return RedirectToPage("NotFound");
            }
            return Page();
        }

        public IActionResult OnPost()
        {
            if (ModelState.IsValid)
            {
                ManageTrigger.ModifiedBy = User.Identity.Name;
                routineRepository.UpdateManageTrigger(ManageTrigger);
            }
            return RedirectToPage("/Garage/Routines/SetupTrigger");
        }
    }
}
