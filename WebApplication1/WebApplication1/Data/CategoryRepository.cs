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

        public Category Insert(Category category)
        {
            _context.Categories.Add(category);
            _context.SaveChanges();

            return category;
        }

        public Category Edit(Category category, int id)
		{
            Category categ = _context.Categories.Find(id);
            categ.Name = category.Name;
            _context.SaveChanges();
            return categ;
        }

        public Category Delete(int id)
        {
            Category categ = _context.Categories.Find(id);
            _context.Categories.Remove(categ);
            _context.SaveChanges();
            return categ;
        }
    }
}