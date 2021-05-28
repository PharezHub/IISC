using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Garage.Core.ViewModel
{
    public class RoleUserViewModel
    {
        [Key]
        public int ID { get; set; }
        public string UserId { get; set; }
        public string RoleName { get; set; }
        public string Module { get; set; }
        public string RoleDescription { get; set; }
        public DateTime CreatedOn { get; set; }
        public string LoggedBy { get; set; }
    }
}
