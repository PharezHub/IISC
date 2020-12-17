using Garage.Core.AppDbContext;
using Garage.Core.Models;
using Garage.Core.Repository;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Garage.Core.Services
{
    public class GarageSettingsService : IGarageSettings
    {
        private readonly GarageDbContext _context;

        public GarageSettingsService(GarageDbContext context)
        {
            _context = context;
        }

        public void AddCategory(Adm_AssetCategory category)
        {
            _context.Adm_AssetCategory.Add(category);
            _context.SaveChanges();
        }

        public void AddStatutory(Adm_Statutory statutory)
        {
            _context.Adm_Statutory.Add(statutory);
            _context.SaveChanges();
        }

        public void DeleteCategory(Adm_AssetCategory category)
        {
            var assetCategory = _context.Adm_AssetCategory.Attach(category);
            assetCategory.State = EntityState.Modified;
            _context.SaveChanges();
        }

        public void DeleteStatutory(Adm_Statutory statutory)
        {
            var statutoryData = _context.Adm_Statutory.Attach(statutory);
            statutoryData.State = EntityState.Modified;
            _context.SaveChanges();
        }

        public List<Adm_AssetCategory> GetAllCategory()
        {
            return _context.Adm_AssetCategory
                .Where(x => x.IsActive == true)
                .ToList();
        }

        public List<Adm_Statutory> GetAllStatutory()
        {
            return _context.Adm_Statutory
                .Where(x => x.IsActive == true)
                .ToList();
        }

        public Adm_AssetCategory GetCategoryById(int id)
        {
            return _context.Adm_AssetCategory.Find(id);
        }

        public Adm_Statutory GetStatutoryById(int id)
        {
            return _context.Adm_Statutory.Find(id);
        }

        public void UpdateCategory(Adm_AssetCategory category)
        {
            var assetCategory = _context.Adm_AssetCategory.Attach(category);
            assetCategory.State = EntityState.Modified;
            _context.SaveChanges();
        }

        public void UpdateStatutory(Adm_Statutory statutory)
        {
            var statutoryData = _context.Adm_Statutory.Attach(statutory);
            statutoryData.State = EntityState.Modified;
            _context.SaveChanges();
        }
    }
}
