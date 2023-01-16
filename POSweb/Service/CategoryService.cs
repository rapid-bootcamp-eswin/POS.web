using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Diagnostics;
using POS.Repository;

namespace POS.Service
{
    public class CategoryService
    {
        private readonly ApplicationContext _context;
        public CategoryService(ApplicationContext context)
        {
            _context = context;
        }

        public List<CategoryEntity> GetCategory()
        {
            return _context.categoryEntities.ToList();
        }

        public CategoryEntity GetCategoriesById(int? id)
        {
            return _context.categoryEntities.Find(id);
        }

        public List<CategoryEntity> SaveCategory([Bind("CategoryName, Description")] CategoryEntity request)
        {
            _context.categoryEntities.Add(request);
            _context.SaveChanges();
            return GetCategory();
        }

        public List<CategoryEntity> UpdateCategories([Bind("Id, CategoryName, Description")] CategoryEntity request)
        {
            _context.categoryEntities.Update(request);
            _context.SaveChanges();
            return GetCategory();
        }

        public List<CategoryEntity> DeleteById(int? id)
        {
            var entity = _context.categoryEntities.Find(id);

            _context.categoryEntities.Remove(entity);
            _context.SaveChanges();
            return GetCategory();
        }
    }
}