using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Garage.Core.Models;
using Garage.Core.Repository;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace IISC.Web.Pages.Garage.Spares
{
    [Authorize(Roles = "admin,asset,fuel,maintenance,utilization")]
    public class EditModel : BasePageModel
    {
        private readonly ICategoryRepository categoryRepository;
        private readonly IAssetRepository assetRepository;

        public EditModel(ICategoryRepository categoryRepository, IAssetRepository assetRepository)
        {
            this.categoryRepository = categoryRepository;
            this.assetRepository = assetRepository;
        }

        [BindProperty]
        public AdmPartsCatalog PartsCatalog { get; set; }
        public SelectList CategoryList { get; set; }
        public SelectList MakeList { get; set; }
        public SelectList ModelList { get; set; }

        public IActionResult OnGet(int id)
        {
            CategoryList = new SelectList(categoryRepository.GetAllCategory(), nameof(Adm_AssetCategory.ID), nameof(Adm_AssetCategory.CategoryName));
            MakeList = new SelectList(categoryRepository.GetMake(), nameof(Adm_Make.ID), nameof(Adm_Make.Make));
            ModelList = new SelectList(categoryRepository.GetModel(), nameof(Adm_Model.ID), nameof(Adm_Model.ModelName));

            PartsCatalog = assetRepository.GetPartsCatalogById(id);
            return Page();
        }

        public IActionResult OnPost()
        {
            if (string.IsNullOrEmpty(PartsCatalog.ItemDescription.Trim()))
            {
                ModelState.AddModelError("Error", "Item description cannot be empty");
            }

            if (!ModelState.IsValid)
            {
                return Page();
            }

            if (string.IsNullOrEmpty(PartsCatalog.PartNumber))
            {
                PartsCatalog.PartNumber = "";
            }
            if (string.IsNullOrEmpty(PartsCatalog.Comment))
            {
                PartsCatalog.Comment = "";
            }
            PartsCatalog.ItemDescription = PartsCatalog.ItemDescription.Trim();

            assetRepository.UpdatePartsCatalog(PartsCatalog);

            //Show Message
            Notify("Spare updated successfully");

            return RedirectToPage("/Garage/Spares/SparesList");
        }
    }
}
