using Garage.Core.AppDbContext;
using Garage.Core.Repository;
using Garage.Core.ViewModel;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Garage.Core.Services
{
    public class AssetService : IAssetRepository
    {
        private readonly GarageDbContext _context;

        public AssetService(GarageDbContext context)
        {
            this._context = context;
        }

        public IEnumerable<AssetCatalogueViewModel> GetAssetCatelogueList()
        {
            return _context.AssetCatalogueViewModel
                .FromSqlRaw("spGetAssetCatelogue")
                .ToList();
        }
    }
}
