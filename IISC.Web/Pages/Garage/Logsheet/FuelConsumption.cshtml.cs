using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Garage.Core.Models;
using Garage.Core.Repository;
using Garage.Core.ViewModel;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace IISC.Web.Pages.Garage.Logsheet
{
    [Authorize(Roles = "admin,fuel")]
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

        public IEnumerable<TrnFuelConsumption> FuelConsumptionList { get; set; }

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
                //TrnFuelConsumption.OdometerReading = 0;  // double.Parse(AssetDetail.CurrentMileage.ToString("N2"));
                if (await logSheetRepository.GetPreviousReading(AssetDetail.RegNo) == 0)
                {
                    TrnFuelConsumption.PreviousReading = double.Parse(AssetDetail.CurrentMileage.ToString("N2"));
                }
                else
                {
                    TrnFuelConsumption.PreviousReading = await logSheetRepository.GetPreviousReading(AssetDetail.RegNo);
                }
                
                FuelConsumptionList = await logSheetRepository.GetFuelConsumption(AssetDetail.RegNo, AssetDetail.ID);

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
            int assetId = 0;
            double odometerReading = 0;

            TrnFuelConsumption.TransactionDate = DateTime.Now;
            TrnFuelConsumption.LoggedBy = User.Identity.Name;

            if (TrnFuelConsumption.AssetID > 0)
            {
                assetId = TrnFuelConsumption.AssetID;
                odometerReading = TrnFuelConsumption.OdometerReading;

                await InitialBinding(assetId);
                TrnFuelConsumption.OdometerReading = odometerReading;
            }

            if (!ModelState.IsValid)
            {
                Notify("Litres received cannot be empty.", notificationType: Models.NotificationType.error);
                return Page();
            }

            if (TrnFuelConsumption.LitresReceived < 1)
            {
                Notify("Enter valid litres received.", notificationType: Models.NotificationType.warning);
                return Page();
            }
            if (TrnFuelConsumption.OdometerReading < 1)
            {
                Notify("Enter valid odometer reading.", notificationType: Models.NotificationType.warning);
                return Page();
            }
            if (TrnFuelConsumption.OdometerReading < TrnFuelConsumption.PreviousReading)
            {
                Notify("Current 'Odometer Reading' is less than previous reading.","Fuel Consumption Warning", notificationType: Models.NotificationType.warning);
                return Page();
            }

            //save fuel consumption to the database
            await logSheetRepository.AddFuelConsumption(TrnFuelConsumption);
            Notify("Fuel consumption saved successfully");

            return RedirectToPage("FuelConsumption", new { id = assetId });
        }
    }
}
