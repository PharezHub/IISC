using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Garage.Core.ViewModel
{
    public class FuelPriceHistoryViewModel
    {
        public int ID { get; set; }
        [Required(ErrorMessage = "Fuel is required")]
        public int FuelID { get; set; }
        public string FuelName { get; set; }

        [Required(ErrorMessage = "Fuel current price is required")]
        public double CurrentPrice { get; set; }
        public DateTime DateLogged { get; set; }
        public string LoggedBy { get; set; }
    }
}
