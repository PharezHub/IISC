using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Garage.Core.Models
{
    public class zRole
    {
        [Key]
        public string RoleName { get; set; }
        public string Module { get; set; }
        public string RoleDescription { get; set; }
    }
}
