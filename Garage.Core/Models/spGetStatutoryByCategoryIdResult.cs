﻿// <auto-generated> This file has been auto generated by EF Core Power Tools. </auto-generated>
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace Garage.Core.Models
{
    public partial class spGetStatutoryByCategoryIdResult
    {
        public int ID { get; set; }
        public int? CategoryID { get; set; }
        public string CategoryName { get; set; }
        public int? StatutoryID { get; set; }
        public string StatutoryName { get; set; }
        public DateTime? CreatedOn { get; set; }
        public string CreatedBy { get; set; }
        public DateTime? ModifiedOn { get; set; }
        public string ModifiedBy { get; set; }
    }
}
