using System;
using System.Collections.Generic;
using System.Text;

namespace Garage.Core.Models
{
    public class zUsers
    {
        public int ID { get; set; }
        public string UserId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string EmailAddress { get; set; }
        public DateTime CreatedOn { get; set; }
        public string CreatedBy { get; set; }

    }
}
