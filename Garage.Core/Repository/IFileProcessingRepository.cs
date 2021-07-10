using Garage.Core.Models;
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
    }
}
