using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Garage.Core.Models
{
    public class Trn_Attachments
    {
        [Key]
        public int ID { get; set; }
        public int AssetID { get; set; }
        public string RegNo { get; set; }
        public string FileName { get; set; }
        public int FileType { get; set; }
        public string PathName { get; set; }
        public string FileExtension { get; set; }
        public DateTime LoggedDate { get; set; }
        public string LoggedBy { get; set; }
        public string FileSize { get; set; }
        public string ModuleName { get; set; }
        public string FolderId { get; set; }
    }
}
