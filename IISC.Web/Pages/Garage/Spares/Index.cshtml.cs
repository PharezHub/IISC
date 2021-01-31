using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Garage.Core.Models;
using Garage.Core.Repository;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace IISC.Web.Pages.Garage.Spares
{
    public class IndexModel : PageModel
    {
        private readonly ICategoryRepository categoryRepository;

        [BindProperty]
        public AdmPartsCatalog PartsCatalog { get; set; }
        public SelectList CategoryList { get; set; }
        public SelectList MakeList { get; set; }
        public SelectList ModelList { get; set; }

        public IndexModel(ICategoryRepository categoryRepository)
        {
            this.categoryRepository = categoryRepository;
        }

        public IActionResult OnGet()
        {
            CategoryList = new SelectList(categoryRepository.GetAllCategory(), nameof(Adm_AssetCategory.ID), nameof(Adm_AssetCategory.CategoryName));
            MakeList = new SelectList(categoryRepository.GetMake(), nameof(Adm_Make.ID), nameof(Adm_Make.Make));
            ModelList = new SelectList(categoryRepository.GetModel(), nameof(Adm_Model.ID), nameof(Adm_Model.ModelName));
            return Page();
        }

        public IActionResult OnPost()
        {
            

            return RedirectToPage("/Garage/Spares/SparesList");
        }
    }
}
