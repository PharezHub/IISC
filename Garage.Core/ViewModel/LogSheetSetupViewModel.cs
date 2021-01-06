using System;
using System.Collections.Generic;
using System.Text;

namespace Garage.Core.ViewModel
{
    public class LogSheetSetupViewModel
    {
        public int ID { get; set; }
        public int CategoryID { get; set; }
        public string CategoryName { get; set; }
        public int LogSheetTypeID { get; set; }
        public string TriggerName { get; set; }
        public int TriggerFrequency { get; set; }
        public string FrequencyName { get; set; }
        public TimeSpan TriggerTime { get; set; }
        public bool IsActive { get; set; }
        public DateTime CreatedOn { get; set; }
        public string CreatedBy { get; set; }
        public DateTime ModifiedOn { get; set; }
        public string ModifiedBy { get; set; }
    }
}
