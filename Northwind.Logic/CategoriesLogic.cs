using System.Linq;
using Northwind.Entities;
using System.Collections.Generic;
using Northwind.CommonComponents.Exceptions;

namespace Northwind.Logic
{
    public class CategoriesLogic : BaseLogic, IABMLogic<Categories>
    {
        public List<Categories> GetAll()
        {
            return _context.Categories.ToList();
        }

        public Categories GetOne(int categoryId)
        {
            return _context.Categories.Find(categoryId);
        }

        public void Add(Categories category)
        {
            _context.Categories.Add(category);
            _context.SaveChanges();
        }

        public void Update(Categories category)
        {
            var prevCategory = GetOne(category.CategoryID);

            if (category == null)
                throw new EntityNotFoundException();

            prevCategory.CategoryName = category.CategoryName;
            prevCategory.Description = category.Description;

            _context.SaveChanges();
        }

        public void Delete(int categoryId)
        {
            var category = GetOne(categoryId);

            if (category == null)
                throw new EntityNotFoundException();

            _context.Categories.Remove(category);
            _context.SaveChanges();
        }
    }
}
