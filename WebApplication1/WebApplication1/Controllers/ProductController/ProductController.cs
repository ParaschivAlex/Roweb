using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using WebApplication1.Business;
using WebApplication1.Domain;
using WebApplication1.Models;

namespace WebApplication1.Controllers.ProductController
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : Controller
	{
        private readonly IProductRepository _repo;
        public ProductController(IProductRepository repo)
        {
            _repo = repo;
        }

        [HttpGet]
        public ProductsRepresentation GetAll()
        {
            var dbProducts = _repo.GetProducts();
            return new ProductsRepresentation(dbProducts);
        }

        [HttpGet("{id}")]
        public ActionResult<Product> GetProduct(int id)
        {
            return _repo.Get(id);
        }

        [HttpPost]
        public ActionResult<Product> PostProduct(Product product)
        {
            var newProduct = _repo.Insert(product);
            return CreatedAtAction(nameof(GetAll), new { id = newProduct.ProductID }, newProduct);
        }

        [HttpPut("{id}")]
        public ActionResult<Product> PutProduct(Product product, int id)
        {
            var prod = _repo.Get(id);
            if (prod == null)
            {
                return NotFound();
            }
            _repo.Update(product);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public ActionResult<Product> DeleteProduct(int id)
        {
            var prodToDelete = _repo.Get(id);
            if (prodToDelete == null)
                return NotFound();

            _repo.Delete(prodToDelete.ProductID);
            return NoContent();
        }
    }
}
