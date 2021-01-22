using System;
using System.Collections.Generic;
using System.Text;

namespace Garage.Core.ViewModel
{
    public class LogSheetListViewModel
    {
        public int ID { get; set; }
        public int CategoryID { get; set; }
        public string CategoryName { get; set; }
        public int LogTypeID { get; set; }
        public string LogType { get; set; }
        public int AdmLogSheetID { get; set; }
        public int FrequencyID { get; set; }
        public string FrequencyName { get; set; }
        public int AssetID { get; set; }
        public string RegNo { get; set; }
        public string Make { get; set; }
        public string ModelName { get; set; }
        public double PreviousValue { get; set; }
        public double CurrentValue { get; set; }
        public int LogStatus { get; set; }
        public DateTime CreatedOn { get; set; }
        public DateTime ModifiedOn { get; set; }
        public string ModifiedBy { get; set; }
    }
}
