using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Garage.Core.Models;
using Garage.Core.Repository;
using Garage.Core.ViewModel;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace IISC.Web.Pages.Garage.Routines
{
    public class SetupTriggerModel : PageModel
    {
        private readonly IRoutineRepository routineRepository;
        private readonly ICategoryRepository categoryRepository;

        [BindProperty]
        public Adm_ManageTrigger ManageTrigger { get; set; }
        public SelectList CategoryList { get; set; }
        public SelectList TriggerList { get; set; }
        public IEnumerable<MaintenanceTriggerListViewModel> MaintenanceTriggerList { get; set; }

        public SetupTriggerModel(IRoutineRepository routineRepository, ICategoryRepository categoryRepository)
        {
            this.routineRepository = routineRepository;
            this.categoryRepository = categoryRepository;
        }

        public void OnGet()
        {
            InitialLoad();
        }
        private void InitialLoad()
        {
            CategoryList = new SelectList(categoryRepository.GetAllCategory(), nameof(Adm_AssetCategory.ID), nameof(Adm_AssetCategory.CategoryName));
            TriggerList = new SelectList(routineRepository.GetAllTriggerTypes(), nameof(Adm_TriggerType.ID), nameof(Adm_TriggerType.TriggerName));
            MaintenanceTriggerList = routineRepository.GetMaintenanceTriggerList();
        }

        public IActionResult OnPost()
        {
            if (ModelState.IsValid)
            {
                ManageTrigger.IsActive = true;
                ManageTrigger.CreatedOn = DateTime.Now;
                ManageTrigger.CreatedBy = User.Identity.Name;
                ManageTrigger.ModifiedBy = User.Identity.Name;
                ManageTrigger.ModifiedOn = DateTime.Now;

                routineRepository.AddManageTrigger(ManageTrigger);
            }

            return RedirectToPage("/Garage/Routines/SetupTrigger");
        }
    }
}
