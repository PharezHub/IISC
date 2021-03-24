using System;
using System.Collections.Generic;
using System.Text;

namespace Garage.Core.Models
{
    public class Gen_SystemArea
    {
        public int ID { get; set; }
        public string ModuleName { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public string PageUrl { get; set; }
        public string ImagePath { get; set; }
        public bool Status { get; set; }
        public string RoleAccessID { get; set; }
        public string UrlType { get; set; }
    }
}
