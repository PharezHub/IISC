using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Garage.Core.Models;
using Garage.Core.Repository;
using Microsoft.AspNetCore.Authorization;

namespace IISC.Web.Pages.Garage.Category
{
    [Authorize(Roles = "admin,asset,")]
    public class EditModel : BasePageModel
    {
        private readonly ICategoryRepository categoryRepository;

        [BindProperty]
        public Adm_AssetCategory AssetCategory { get; set; }

        public EditModel(ICategoryRepository categoryRepository)
        {
            this.categoryRepository = categoryRepository;
        }

        public IActionResult OnGet(int id)
        {
            AssetCategory = categoryRepository.GetCategoryById(id);

            if (AssetCategory == null)
            {
                return RedirectToPage("NotFound");
            }
            return Page();
        }

        public IActionResult OnPost()
        {
            if (ModelState.IsValid)
            {
                AssetCategory.IsActive = true;
                categoryRepository.UpdateCategory(AssetCategory);
            }

            //Show Message
            Notify("Category updated successfully");

            return RedirectToPage("/Garage/Category/Index");
        }
    }
}
