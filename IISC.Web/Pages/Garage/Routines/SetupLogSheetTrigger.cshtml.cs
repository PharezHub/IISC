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
    public class SetupLogSheetTriggerModel : PageModel
    {
        private readonly IRoutineRepository routineRepository;
        private readonly ICategoryRepository categoryRepository;

        [BindProperty]
        public Adm_ManageLogSheet ManageLogSheet { get; set; }
        
        [BindProperty]
        public int Id { get; set; }
        public Adm_ManageTrigger ManageTrigger { get; set; }
        public SelectList CategoryList { get; set; }
        public SelectList TriggerList { get; set; }
        public SelectList FrequencyList { get; set; }
        public IEnumerable<LogSheetSetupViewModel> LogSheetSetupList { get; set; }

        public SetupLogSheetTriggerModel(IRoutineRepository routineRepository, ICategoryRepository categoryRepository)
        {
            this.routineRepository = routineRepository;
            this.categoryRepository = categoryRepository;
            ManageLogSheet = new Adm_ManageLogSheet();
        }

        public IActionResult OnGet(int id)
        {
            Id = id;
            CategoryList = new SelectList(categoryRepository.GetAllCategory(),
                nameof(Adm_AssetCategory.ID), nameof(Adm_AssetCategory.CategoryName));

            TriggerList = new SelectList(routineRepository.GetAllTriggerTypes(),
                nameof(Adm_TriggerType.ID), nameof(Adm_TriggerType.TriggerName));

            FrequencyList = new SelectList(routineRepository.GetFrequency(),
                nameof(Adm_Frequency.ID), nameof(Adm_Frequency.FrequencyName));
            
            ManageTrigger = routineRepository.GetManageTriggerById(id);
            

            if (ManageTrigger != null)
            {
                ManageLogSheet.CategoryID = ManageTrigger.CategoryID;
                ManageLogSheet.LogSheetTypeID = ManageTrigger.TriggerID;

                LogSheetSetupList = routineRepository.GetLogSheetSetup().Result.Where(x => x.CategoryID == ManageLogSheet.CategoryID);
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
            return RedirectToPage("/Garage/Routines/SetupLogSheetTrigger", new { id = Id });
        }
    }
}
