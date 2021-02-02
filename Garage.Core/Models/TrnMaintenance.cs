using System;
using System.Collections.Generic;
using System.Text;

namespace Garage.Core.Models
{
    public class TrnMaintenance
    {
        public int ID { get; set; }
        public int MainID { get; set; }
        public string DocketNo { get; set; }
        public string ProblemDescription { get; set; }
        public DateTime DateLogged { get; set; }
        public string LoggedBy { get; set; }
    }
}
