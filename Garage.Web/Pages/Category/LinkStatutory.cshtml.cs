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

namespace Garage.Web.Pages.Category
{
    public class LinkStatutoryModel : PageModel
    {
        private readonly ICategoryRepository categoryRepository;

        [BindProperty]
        public Adm_AssetCategory Category { get; set; }

        [BindProperty]
        public List<int> SelectedTypes { get; set; }
        
        [BindProperty]
        public Adm_Statutory Statutory { get; set; }

        [BindProperty]
        public List<Adm_Statutory> StatutoryTypes { get; set; }

        [BindProperty]
        public Adm_CategoryStatutoryLink CategoryStatutoryLink { get; set; }

        public IEnumerable<StatutoryCategoryViewModel> CategoryStatutoryList { get; set; }

        public LinkStatutoryModel(ICategoryRepository categoryRepository)
        {
            this.categoryRepository = categoryRepository;
        }

        public IActionResult OnGet(int? id)
        {
            if (!string.IsNullOrEmpty(id.ToString()))
            {
                StatutoryTypes = categoryRepository.GetAllStatutory();
                Category = categoryRepository.GetCategoryById(id.Value);
                CategoryStatutoryList = categoryRepository.GetStatutoryByCategoryId(id.Value);
            }
            return Page();
        }

        #region
        public IActionResult OnPost()
        {
            foreach (var itemId in SelectedTypes)
            {
                CategoryStatutoryLink.ID = 0;
                CategoryStatutoryLink.CategoryID = Category.ID;
                CategoryStatutoryLink.StatutoryID = itemId;
                CategoryStatutoryLink.CreatedOn = DateTime.Now;
                CategoryStatutoryLink.CreatedBy = User.Identity.Name;
                CategoryStatutoryLink.ModifiedOn = DateTime.Now;
                CategoryStatutoryLink.ModifiedBy = User.Identity.Name;

                // Persist to the database
                categoryRepository.AddLink(CategoryStatutoryLink);
            }

            return RedirectToPage("/Category/Index");
        }
        #endregion
    }
}
