﻿// <auto-generated> This file has been auto generated by EF Core Power Tools. </auto-generated>
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

#nullable disable

namespace Garage.Core.Models
{
    public partial class Adm_TriggerType
    {
        [Key]
        public int ID { get; set; }
        [StringLength(25)]
        public string TriggerName { get; set; }
    }
}