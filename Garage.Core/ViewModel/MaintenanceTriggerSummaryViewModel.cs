﻿using System;
using System.Collections.Generic;
using System.Text;

namespace Garage.Core.ViewModel
{
    public class MaintenanceTriggerSummaryViewModel
    {
        public int ID { get; set; }
        public int CategoryID { get; set; }
        public string CategoryName { get; set; }
        public int TriggerID { get; set; }
        public string TriggerName { get; set; }
        public int TriggerValue { get; set; }
        public int Threshold { get; set; }
        public bool MaintenanceTrigger { get; set; }
        public bool IsActive { get; set; }
    }
}
