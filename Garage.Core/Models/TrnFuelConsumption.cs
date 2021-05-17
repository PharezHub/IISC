using System;
using System.Collections.Generic;
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
        public DateTime TransactionDate { get; set; }
        public string LoggedBy { get; set; }
    }
}
