using Garage.Core.AppDbContext;
using Garage.Core.Models;
using Garage.Core.Repository;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Garage.Core.Services
{
    public class FileProcessingService : IFileProcessingRepository
    {
        private readonly GarageDbContext _context;

        public FileProcessingService(GarageDbContext context)
        {
            this._context = context;
        }

        public async Task<string> GenerateGuid()
        {
            Guid newGuid = Guid.NewGuid();
            return await Task.FromResult(newGuid.ToString());
        }

        public async Task<string> GetGuid(int assetId)
        {
            try
            {
                return await _context.Trn_Attachments.Where(x => x.AssetID == assetId).Select(x => x.FolderId).FirstOrDefaultAsync();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<IEnumerable<Adm_AttachmentTypes>> GetAttachmentTypes()
        {
            return await _context.Adm_AttachmentTypes.ToListAsync();
        }

        public async Task AddAttachments(Trn_Attachments attach)
        {
            if (!(attach is null))
            {
                await Task.FromResult(_context.Database.ExecuteSqlRaw("spAddAttachment {0},{1},{2},{3},{4},{5},{6},{7},{8}",
                    attach.AssetID, attach.FileName, attach.FileType, attach.PathName, attach.FileExtension,
                    attach.LoggedBy, attach.FileSize, attach.ModuleName, attach.FolderId));
            }
        }

        public async Task ProcessFileUpload(int itemId, IFormFile[] filesList, Trn_Attachments attach, string userName, string webRootPath)
        {
            string guid = await GetGuid(itemId);

            //TODO: Check if the files exists
            if (filesList != null && filesList.Length > 0)
            {
                //TODO: Get Guid for attachment
                if (guid is null)
                {
                    guid = await GenerateGuid();
                }

                //TODO: Save Guid in the database
                //var path = Path.Combine(Directory.GetCurrentDirectory(), $"Uploads/{GuidNumber}");
                var path = Path.Combine(webRootPath, $"Uploads/{guid}");

                if (!Directory.Exists(path))
                {
                    Directory.CreateDirectory(path);
                }

                //TODO: Loop through all the files
                foreach (IFormFile files in filesList)
                {
                    string filePath = Path.Combine(path, files.FileName);
                    using (var fileStream = new FileStream(filePath, FileMode.Create, FileAccess.Write))
                    {
                        await files.CopyToAsync(fileStream);
                    }
                    attach.AssetID = itemId;
                    attach.FileName = files.FileName;
                    attach.PathName = $"Uploads/{guid}/{files.FileName}";
                    attach.FileExtension = Path.GetExtension(filePath);
                    attach.LoggedBy = userName;
                    attach.FileSize = files.Length.ToString();
                    attach.ModuleName = "Garage";
                    attach.FolderId = guid;
                    attach.LoggedDate = DateTime.Now;

                    //TODO: Save file name to the database and file type
                    await AddAttachments(attach);
                }
            }
        }
    }
}
