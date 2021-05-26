using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using WebApplication1.Business;
using WebApplication1.Domain;

namespace WebApplication1.Data
{
    public class CategoryRepository : ICategoryRepository
    {
        private readonly ShopContext _context;
        public CategoryRepository(ShopContext context)
        {
            _context = context;
        }
        public List<Category> GetCategories()
        {
            return _context.Categories.ToList();
        }

        public Category Get (int id)
		{
            return _context.Categories.Find(id);
		}

        public Category Insert(Category category)
        {
            _context.Categories.Add(category);
            _context.SaveChanges();

            return category;
        }

        public Category Update(Category category)
         {
            var categ = _context.Categories.FirstOrDefault(c => c.CategoryID == category.CategoryID);

            if (categ != null)
            {
                categ.Name = category.Name;
                categ.Products = category.Products;

                _context.SaveChanges();

                return categ;
            }
            return null;
        }
         public void Delete(int id)
         {
            var categoryToDelete = _context.Categories.Find(id);
            _context.Categories.Remove(categoryToDelete);
            _context.SaveChanges();
         }
	}
}