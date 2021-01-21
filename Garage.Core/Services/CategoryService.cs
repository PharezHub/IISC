using Garage.Core.AppDbContext;
using Garage.Core.Models;
using Garage.Core.Repository;
using Garage.Core.ViewModel;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Garage.Core.Services
{
    public class CategoryService : ICategoryRepository
    {
        private readonly GarageDbContext _context;

        public CategoryService(GarageDbContext context)
        {
            _context = context;
        }

        public void AddCategory(Adm_AssetCategory category)
        {
            _context.Adm_AssetCategory.Add(category);
            _context.SaveChanges();
        }

        public void AddLink(Adm_CategoryStatutoryLink statutoryLink)
        {
            _context.Adm_CategoryStatutoryLink.Add(statutoryLink);
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

        public void DeleteLink(int Id)
        {
            var LinkToDelete = _context.Adm_CategoryStatutoryLink.Find(Id);
            if (LinkToDelete != null)
            {
                _context.Remove(LinkToDelete);
                _context.SaveChanges();
            }
            throw new InvalidOperationException("Statutory link to delete not found!!!");
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

        public IEnumerable<StatutoryCategoryViewModel> GetStatutoryByCategoryId(int id)
        {
            return _context.StatutoryCategoryViewModel
                .FromSqlRaw("spGetStatutoryByCategoryId {0}", id)
                .ToList();
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

        public bool ValidateCategory(Adm_AssetCategory category)
        {
            bool result = false;
            Adm_AssetCategory assetCategory = _context.Adm_AssetCategory.
                FirstOrDefault(x => x.CategoryName.ToUpper() == category.CategoryName.ToUpper());
            if (assetCategory != null)
            {
                result = true;
            }
            return result;
        }
    }
}
