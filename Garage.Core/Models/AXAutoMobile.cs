using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Garage.Core.Models
{
    public class AXAutoMobile
    {
        [Key]
        public string ItemId { get; set; }
        public string UnitId { get; set; }
        public string ItemGroup { get; set; }
        public string ItemName { get; set; }
        public double ItemPrice { get; set; }
        public DateTime PriceDate { get; set; }
    }
}
