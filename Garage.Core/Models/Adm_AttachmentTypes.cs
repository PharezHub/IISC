using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Garage.Core.Models
{
    public class Adm_AttachmentTypes
    {
        [Key]
        public int ID { get; set; }
        public string FileType { get; set; }
    }
}
