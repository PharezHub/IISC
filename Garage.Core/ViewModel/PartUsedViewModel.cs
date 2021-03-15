using System;
using System.Collections.Generic;
using System.Text;

namespace Garage.Core.ViewModel
{
    public class PartUsedViewModel
    {
        public int ID { get; set; }
        public int MainID { get; set; }
        public string ProblemDescription { get; set; }
        public string DocketNo { get; set; }
        public int PartID { get; set; }
        public string PartDescription { get; set; }
        public double PartCost { get; set; }
        public int Qty { get; set; }
        public DateTime DateLogged { get; set; }
        public string LoggedBy { get; set; }
    }
}
