using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.IO;
using System.Threading.Tasks;
using WebApplication1.Business;
using WebApplication1.Domain;
using WebApplication1.Models;

namespace WebApplication1.Controllers.ProductController
{
    //[Route("api/[controller]")]
    [ApiController]
    public class ProductController : Controller
	{
        private readonly IProductRepository _repo;
        public ProductController(IProductRepository repo)
        {
            _repo = repo;
        }

        [HttpGet]
        [Route("api/product")]
        public ProductsRepresentation GetAll()
        {
            var dbProducts = _repo.GetProducts();
            return new ProductsRepresentation(dbProducts);
        }

        [HttpGet]//("{id}")]
        [Route("api/product/{id}")]
        public ActionResult<Product> GetProduct(int id)
        {
            return _repo.Get(id);
        }

        [HttpPost]
        [Route("api/product")]
        public ActionResult<Product> PostProduct(Product product)
        {
            var newProduct = _repo.Insert(product);
            return CreatedAtAction(nameof(GetAll), new { id = newProduct.ProductID }, newProduct);
        }

        [HttpPut]//("{id}")]
        [Route("api/product/{id}")]
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

        [HttpDelete]//("{id}")]
        [Route("api/product/{id}")]
        public ActionResult<Product> DeleteProduct(int id)
        {
            var prodToDelete = _repo.Get(id);
            if (prodToDelete == null)
                return NotFound();

            _repo.Delete(prodToDelete.ProductID);
            return NoContent();
        }


        [HttpGet]
        [Route("api/product/{id}")]
        public ActionResult GetImage(int id)
        {
            var prod = _repo.Get(id);
            string ImageName = prod.Image;
            string path = Path.Combine(Environment.CurrentDirectory, @"Uploads\Images", ImageName);
            var image = System.IO.File.OpenRead(path);
            return File(image, "image/jpeg");
        }

        [HttpPost]
        [Route("api/product/image/{id}")]
        public ActionResult PostImage([FromRoute] int id, [FromForm] IFormFile file)
        {
            string path = Path.Combine(Environment.CurrentDirectory, @"Uploads\Images", file.FileName);
            var streamImage = new FileStream(path, FileMode.Create);
            file.CopyTo(streamImage);
            var product = _repo.Get(id);
            product.Image = file.FileName;
            _repo.Update(product);
            return Ok();
        }
        

    }
}
