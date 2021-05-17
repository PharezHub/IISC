using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Garage.Core.Models
{
    public class TrnFuelPriceHistory
    {
        public int ID { get; set; }
        [Required(ErrorMessage = "Fuel is required")]
        public int FuelID { get; set; }

        [Required(ErrorMessage = "Fuel current price is required")]
        [DataType(DataType.Currency)]
        public double CurrentPrice { get; set; }
        public DateTime DateLogged { get; set; }
        public string LoggedBy { get; set; }
    }
}
