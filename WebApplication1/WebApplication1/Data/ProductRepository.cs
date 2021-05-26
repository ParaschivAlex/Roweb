using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApplication1.Business;
using WebApplication1.Domain;

namespace WebApplication1.Data
{
    public class ProductRepository : IProductRepository
    {
        private readonly ShopContext _context;
        public ProductRepository(ShopContext context)
        {
            _context = context;
        }
        public List<Product> GetProducts()
        {
            return _context.Products.ToList();
        }

        public Product Get(int id)
        {
            return _context.Products.Find(id);
        }

        public Product Insert(Product prod)
        {
            _context.Products.Add(prod);
            _context.SaveChanges();

            return prod;
        }

        public Product Update(Product product)
        {
            var prod = _context.Products.FirstOrDefault(p => p.ProductID == product.ProductID);

            if (prod != null)
            {
                prod.Name = product.Name;
                prod.Description = product.Description;
                prod.Price = product.Price;
                prod.BasePrice = product.BasePrice;
                prod.Image = product.Image;
                prod.CategoryID = product.CategoryID;

                _context.SaveChanges();

                return prod;
            }
            return null;
        }
        public void Delete(int id)
        {
            var productToDelete = _context.Products.Find(id);
            _context.Products.Remove(productToDelete);
            _context.SaveChanges();
        }
    }
}
