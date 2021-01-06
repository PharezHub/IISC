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

namespace Garage.Web.Pages.Routines
{
    public class SetupLogSheetTriggerModel : PageModel
    {
        private readonly IRoutineRepository routineRepository;
        private readonly ICategoryRepository categoryRepository;

        public SetupLogSheetTriggerModel(IRoutineRepository routineRepository, ICategoryRepository categoryRepository)
        {
            this.routineRepository = routineRepository;
            this.categoryRepository = categoryRepository;
            ManageLogSheet = new Adm_ManageLogSheet();
        }

        [BindProperty]
        public Adm_ManageLogSheet ManageLogSheet { get; set; }
        public Adm_ManageTrigger ManageTrigger { get; set; }
        public SelectList CategoryList { get; set; }
        public SelectList TriggerList { get; set; }
        public SelectList FrequencyList { get; set; }
        public IEnumerable<LogSheetSetupViewModel> LogSheetSetupList { get; set; }

        public IActionResult OnGet(int id)
        {
            CategoryList = new SelectList(categoryRepository.GetAllCategory(), 
                nameof(Adm_AssetCategory.ID), nameof(Adm_AssetCategory.CategoryName));

            TriggerList = new SelectList(routineRepository.GetAllTriggerTypes(), 
                nameof(Adm_TriggerType.ID), nameof(Adm_TriggerType.TriggerName));

            FrequencyList = new SelectList(routineRepository.GetFrequency(), 
                nameof(Adm_Frequency.ID), nameof(Adm_Frequency.FrequencyName));

            ManageTrigger = routineRepository.GetManageTriggerById(id);
            LogSheetSetupList = routineRepository.GetLogSheetSetup();

            if (ManageTrigger != null)
            {
                ManageLogSheet.CategoryID = ManageTrigger.CategoryID.Value;
                ManageLogSheet.LogSheetTypeID = ManageTrigger.TriggerID.Value;
            }
            return Page();
        }

        public IActionResult OnPost()
        {
            if (ModelState.IsValid)
            {
                //ManageLogSheet.ID = 1;
                ManageLogSheet.TriggerTime = TimeSpan.Parse("06:00:00");
                ManageLogSheet.IsActive = true;
                ManageLogSheet.CreatedOn = DateTime.Now;
                ManageLogSheet.CreatedBy = User.Identity.Name;
                ManageLogSheet.ModifiedBy = User.Identity.Name;
                ManageLogSheet.ModifiedOn = DateTime.Now;

                routineRepository.AddLogSheetTrigger(ManageLogSheet);
            }
            return Page();
        }
    }
}
