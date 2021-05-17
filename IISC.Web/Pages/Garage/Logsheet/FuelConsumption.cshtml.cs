using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Garage.Core.Models;
using Garage.Core.Repository;
using Garage.Core.ViewModel;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace IISC.Web.Pages.Garage.Logsheet
{
    public class FuelConsumptionModel : BasePageModel
    {
        private readonly IAssetRepository assetRepository;
        private readonly ILogSheetRepository logSheetRepository;

        public FuelConsumptionModel(IAssetRepository assetRepository, ILogSheetRepository logSheetRepository)
        {
            this.assetRepository = assetRepository;
            this.logSheetRepository = logSheetRepository;

            TrnFuelConsumption = new TrnFuelConsumption();
        }

        [BindProperty]
        public AssetViewModel AssetDetail { get; set; }

        [BindProperty]
        public TrnFuelConsumption TrnFuelConsumption { get; set; }

        public async Task<IActionResult> OnGet(int id)
        {
            AssetDetail = assetRepository.GetAssetById(id);
            if (AssetDetail.FuelTypeID > 0)
            {
                double currentPrice = (double)await logSheetRepository.GetCurrentFuelPrice(AssetDetail.FuelTypeID);
                TrnFuelConsumption.CurrentFuelPrice = double.Parse(currentPrice.ToString("N2"));
            }

            return Page();
        }

        public async Task<IActionResult> OnPost()
        {
            TrnFuelConsumption.TransactionDate = DateTime.Now;
            TrnFuelConsumption.LoggedBy = User.Identity.Name;

            if (ModelState.IsValid)
            {

            }
            return Page();
        }
    }
}
