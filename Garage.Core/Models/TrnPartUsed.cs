using System;
using System.Collections.Generic;
using System.Text;

namespace Garage.Core.Models
{
    public class TrnPartUsed
    {
        public int ID { get; set; }
        public int MainID { get; set; }
        public string DocketNo { get; set; }
        public int PartID { get; set; }
        public int Qty { get; set; }
    }
}
