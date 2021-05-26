using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using WebApplication1.Business;
using WebApplication1.Domain;
using WebApplication1.Models;

namespace WebApplication1.Controllers.CategoryControllers
{
	[Route("api/[controller]")]
    [ApiController]
    public class CategoryController : ControllerBase
    {
        private readonly ICategoryRepository _repo;
        public CategoryController(ICategoryRepository repo)
        {
            _repo = repo;
        }

        [HttpGet]
        public CategoriesRepresentation GetAll()
        {
            var dbCategories = _repo.GetCategories();
            return new CategoriesRepresentation(dbCategories);
        }

        [HttpGet("{id}")]
        public ActionResult<Category> GetCategory(int id)
		{
            return _repo.Get(id);
        }

        [HttpPost]
        public ActionResult<Category> PostCategory(Category category)
		{
            var newCategory = _repo.Insert(category);
            return CreatedAtAction(nameof(GetAll), new { id = newCategory.CategoryID }, newCategory);
        }

        [HttpPut("{id}")]
        public ActionResult<Category> PutCategory(Category category, int id)
		{
            var categ = _repo.Get(id);
            if (categ == null)
            {
                return NotFound();
            }
            _repo.Update(category);
            return NoContent();
        }
        
        [HttpDelete("{id}")]
        public ActionResult<Category> DeleteCategory(int id)
		{
            var categToDelete = _repo.Get(id);
            if (categToDelete == null)
                return NotFound();

            _repo.Delete(categToDelete.CategoryID);
            return NoContent();
        }
    }
}