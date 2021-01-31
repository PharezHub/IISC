using System;
using System.Collections.Generic;
using System.Text;

namespace Garage.Core.ViewModel
{
    public class PartsCatalogViewModel
    {
        public int ID { get; set; }
        public string ItemDescription { get; set; }
        public string PartNumber { get; set; }
        public int CategoryID { get; set; }
        public string CategoryName { get; set; }
        public int MakeID { get; set; }
        public string Make { get; set; }
        public int ModelID { get; set; }
        public string ModelName { get; set; }
        public string Comment { get; set; }
    }
}
