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
            await InitialBinding(id);
            return Page();
        }

        private async Task InitialBinding(int assetId)
        {
            try
            {
                AssetDetail = assetRepository.GetAssetById(assetId);
                TrnFuelConsumption.AssetID = AssetDetail.ID;
                TrnFuelConsumption.RegNo = AssetDetail.RegNo;
                TrnFuelConsumption.OdometerReading = double.Parse(AssetDetail.CurrentMileage.ToString("N2"));
                TrnFuelConsumption.PreviousReading = await logSheetRepository.GetPreviousReading(AssetDetail.RegNo);
                if (AssetDetail.FuelTypeID > 0)
                {
                    double currentPrice = await logSheetRepository.GetCurrentFuelPrice(AssetDetail.FuelTypeID);
                    TrnFuelConsumption.CurrentFuelPrice = double.Parse(currentPrice.ToString("N2"));
                }
            }
            catch (Exception)
            {
                throw;
            }
        }

        public async Task<IActionResult> OnPost()
        {
            if (TrnFuelConsumption.AssetID > 0)
            {
                await InitialBinding(TrnFuelConsumption.AssetID);
            }
            
            TrnFuelConsumption.TransactionDate = DateTime.Now;
            TrnFuelConsumption.LoggedBy = User.Identity.Name;

            if (ModelState.IsValid)
            {
                if (TrnFuelConsumption.LitresReceived < 1)
                {
                    Notify("Enter valid litres received.", notificationType: Models.NotificationType.warning);
                    return Page();
                }
                else
                {
                    //save fuel consumption to the database

                    Notify("Fuel consumption saved successfully");
                }
            }
            else
            {
                Notify("Litres received cannot be empty.", notificationType: Models.NotificationType.error);
                return Page();
            }
            return Page();
        }
    }
}
