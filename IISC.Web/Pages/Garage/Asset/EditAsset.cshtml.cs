using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Garage.Core.Models;
using Garage.Core.ViewModel;
using IISC.Web.Pages.Garage.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace IISC.Web.Pages.Garage.Asset
{
    public class EditAssetModel : PageModel
    {
        [BindProperty]
        public Hdr_Asset AssetHeader { get; set; }

        [BindProperty]
        public Hdr_StatutoryRequirement StatutoryRequirement { get; set; }

        [BindProperty]
        public InsuranceViewModel InsuranceVM { get; set; }

        [BindProperty]
        public FitnessViewModel FitnessVM { get; set; }

        [BindProperty]
        public RoadTaxViewModel RoadTaxVM { get; set; }

        public List<AssetTypeViewModel> AssetDisplayList { get; set; }
        public List<FuelTypeViewModel> FueltypeList { get; set; }
        public List<CategoryViewModel> CategoryDisplayList { get; set; }
        public List<MakeViewModel> MakeTypeList { get; set; }
        public List<CarModelViewModel> ModelTypeList { get; set; }
        public List<Adm_InsuranceType> InsuranceTypeList { get; set; }
        public List<ColorViewModel> ColorTypeList { get; set; }

        public void OnGet()
        {

            Page();
        }
    }
}
