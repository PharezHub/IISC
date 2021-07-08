using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Garage.Core.Models
{
    public class TrnFuelConsumption
    {
        public int ID { get; set; }
        public string RegNo { get; set; }
        public int AssetID { get; set; }
        public double LitresReceived { get; set; }
        public double CurrentFuelPrice { get; set; }

        [Required(ErrorMessage = "Odometer reading is required")]
        public double OdometerReading { get; set; }
        public double PreviousReading { get; set; }
        public DateTime TransactionDate { get; set; }
        public string LoggedBy { get; set; }

        [Required(ErrorMessage = "Refuel date is required")]
        [DataType(DataType.Date)]
        public DateTime RefuelDate { get; set; }
    }
}
