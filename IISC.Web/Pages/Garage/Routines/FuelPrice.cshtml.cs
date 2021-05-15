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

namespace IISC.Web.Pages.Garage.Routines
{
    public class FuelPriceModel : BasePageModel
    {
        private readonly IRoutineRepository routineRepository;

        [BindProperty]
        public TrnFuelPriceHistory FuelPriceHistory { get; set; }
        public SelectList FuelTypeList { get; set; }
        public IEnumerable<FuelPriceHistoryViewModel> FuelPriceHistoryList { get; set; }

        public FuelPriceModel(IRoutineRepository routineRepository)
        {
            this.routineRepository = routineRepository;
        }

        public async Task<IActionResult> OnGet()
        {
            try
            {
                FuelTypeList = new SelectList(await routineRepository.GetFuelTypes(), nameof(Adm_FuelType.ID), nameof(Adm_FuelType.FuelName));

                // Get all price history
                FuelPriceHistoryList = await routineRepository.GetFuelPriceHistory();
            }
            catch (Exception)
            {
                throw;
            }
            return Page();
        }

        public async Task<IActionResult> OnPost()
        {
            try
            {
                FuelPriceHistory.ID = 0;
                FuelPriceHistory.LoggedBy = User.Identity.Name;
                FuelPriceHistory.DateLogged = DateTime.Now;

                if (!ModelState.IsValid)
                {
                    FuelTypeList = new SelectList(await routineRepository.GetFuelTypes(), nameof(Adm_FuelType.ID), nameof(Adm_FuelType.FuelName));
                    return Page();
                }
                else
                {
                    // Post fuel data to the database
                    await routineRepository.AddFuelPriceHistory(FuelPriceHistory);
                    

                    Notify($"Fuel price K{FuelPriceHistory.CurrentPrice} added successfully.");
                    FuelPriceHistory.CurrentPrice = 0;
                    return RedirectToPage("/Garage/Routines/FuelPrice");
                }
            }
            catch (Exception)
            {
                throw;
            } 
        }
    }
}
