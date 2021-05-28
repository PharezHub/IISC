using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Garage.Core.Models
{
    public class zUsers
    {
        [Key]
        public int ID { get; set; }
     
        [Required(ErrorMessage = "Username is a required field")]
        public string UserId { get; set; }

        [Required(ErrorMessage = "Firstname is a required field")]
        public string FirstName { get; set; }

        [Required(ErrorMessage = "Lastname is a required field")]
        public string LastName { get; set; }

        [Required(ErrorMessage = "Email address is a required field")]
        public string EmailAddress { get; set; }
        public DateTime CreatedOn { get; set; }
        public string CreatedBy { get; set; }

    }
}
