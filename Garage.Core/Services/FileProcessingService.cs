﻿using Garage.Core.AppDbContext;
using Garage.Core.Models;
using Garage.Core.Repository;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
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
                await Task.FromResult(_context.Database.ExecuteSqlRaw("spAddAttachment {0},{1},{2},{3},{4},{5},{6},{7},{8},{9}",
                    attach.AssetID, attach.RegNo, attach.FileName, attach.FileType, attach.PathName, attach.FileExtension,
                    attach.LoggedBy, attach.FileSize, attach.ModuleName, attach.FolderId));
            }
        }
    }
}
