using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Garage.Core.Models;
using Garage.Core.Repository;
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
        }

        [BindProperty]
        public Adm_ManageLogSheet ManageLogSheet { get; set; }
        public SelectList CategoryList { get; set; }
        public SelectList TriggerList { get; set; }
        public SelectList FrequencyList { get; set; }

        public IActionResult OnGet()
        {
            CategoryList = new SelectList(categoryRepository.GetAllCategory(), 
                nameof(Adm_AssetCategory.ID), nameof(Adm_AssetCategory.CategoryName));

            TriggerList = new SelectList(routineRepository.GetAllTriggerTypes(), 
                nameof(Adm_TriggerType.ID), nameof(Adm_TriggerType.TriggerName));

            FrequencyList = new SelectList(routineRepository.GetFrequency(), 
                nameof(Adm_Frequency.ID), nameof(Adm_Frequency.FrequencyName));

            return Page();
        }
    }
}
