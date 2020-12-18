using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

#nullable disable

namespace Garage.Core.Models
{
    public partial class Adm_AssetCategory
    {
        [Key]
        public int ID { get; set; }
        [StringLength(50)]
        [Required(ErrorMessage = "Category name is required")]
        public string CategoryName { get; set; }
        public bool? IsActive { get; set; }
    }
}