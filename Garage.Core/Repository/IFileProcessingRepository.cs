using Garage.Core.Models;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Garage.Core.Repository
{
    public interface IFileProcessingRepository
    {
        Task<IEnumerable<Adm_AttachmentTypes>> GetAttachmentTypes();
        Task<string> GenerateGuid();
        Task<string> GetGuid(int assetId);
        Task AddAttachments(Trn_Attachments attachments);
        Task ProcessFileUpload(int itemId, IFormFile[] filesList, Trn_Attachments attach, string userName, string webRootPath);
    }
}
