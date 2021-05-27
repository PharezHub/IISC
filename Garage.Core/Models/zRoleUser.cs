using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Garage.Core.Models
{
    public class zRoleUser
    {
        [Key]
        public int ID { get; set; }
        public string UserId { get; set; }
        public string RoleName { get; set; }
        public DateTime CreatedOn { get; set; }
        public string LoggedBy { get; set; }

    }
}
