using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Garage.Core.Models;
using Garage.Core.Repository;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace IISC.Web.Pages.Garage.Category
{
    public class IndexModel : PageModel
    {
        private readonly ICategoryRepository categoryRepository;
        public IEnumerable<Adm_AssetCategory> CategoryList { get; set; }

        [BindProperty]
        public Adm_AssetCategory Category { get; set; }
        public string ErrorMessage { get; set; }

        public IndexModel(ICategoryRepository categoryRepository)
        {
            this.categoryRepository = categoryRepository;
        }

        public void OnGet()
        {
            CategoryList = categoryRepository.GetAllCategory();
        }

        public IActionResult OnPost()
        {
            if (ModelState.IsValid)
            {
                if (categoryRepository.ValidateCategory(Category))
                {
                    ErrorMessage = $"Asset category name *{Category.CategoryName.Trim()}* already exist!!!";
                }
                else
                {
                    Category.IsActive = true;
                    categoryRepository.AddCategory(Category);

                    return RedirectToPage("/Garage/Category/Index");
                }
            }

            // Rebind data category list
            CategoryList = categoryRepository.GetAllCategory();
            return Page();
        }
    }
}
