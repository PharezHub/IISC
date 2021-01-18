using System;
using System.Collections.Generic;
using System.Text;

namespace Garage.Core.ViewModel
{
    public class AssetCatalogueViewModel
    {
        public int ID { get; set; }
        public string AssetType { get; set; }
        public string CategoryName { get; set; }
        public string RegNo { get; set; }
        public string MakeName { get; set; }
        public string ModelName { get; set; }
        public int Year { get; set; }
        public string Status { get; set; }
        public int StatusID { get; set; }
        public string FuelName { get; set; }
    }
}
