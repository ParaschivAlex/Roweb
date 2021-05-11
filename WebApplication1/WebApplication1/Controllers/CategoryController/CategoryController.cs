using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApplication1.Business;
using WebApplication1.Data;
using WebApplication1.Domain;
using WebApplication1.Models;

namespace WebApplication1.Controllers.CategoryControllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoryController : ControllerBase
    {
        private readonly ICategoryRepository _repo;
        private ShopContext db;
        public CategoryController(ICategoryRepository repo)
        {
            _repo = repo;
        }

        [HttpGet] //get pe toate (merge + testata)
        public CategoriesRepresentation GetAll()
        {
            var dbCategories = _repo.GetCategories();
            return new CategoriesRepresentation(dbCategories);
        }

        [HttpGet("{id}")] //get in functie de id dat (merge + testata)
        public ActionResult<Category> GetCategory(int id)
		{
			var category = _repo.GetCategories().FirstOrDefault(x => x.CategoryID == id);
            if(category == null)
			{
                return NotFound();
			}
            return category;
        }
        [HttpPost("NewCategory")] //Creare categorie noua (merge + testata)
        public ActionResult<Category> NewCategory(Category category)
		{
            try
            {
                if (ModelState.IsValid)
                {
                    _repo.Insert(category);
                    return RedirectToAction("api/Category/");
                }
                else { return RedirectToAction("api/Category"); }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.ToString());
                return RedirectToAction("api/Category");
            }
        }

        [HttpPut("UpdateCategory/{id}")] //modificare categorie
        public ActionResult<Category> UpdateCategory(Category category, int id)
		{
            if (id != category.CategoryID)
            {
                return BadRequest();
            }
            try
            {
                _repo.Edit(category, id);
                return RedirectToAction("api/Category");
            }
            catch(Exception e)
			{
                Console.WriteLine(e.ToString());
                return RedirectToAction("api/Category");
            }
        }
        
        [HttpDelete("DeleteCategory/{id}")] //sterge categorie (merge + testata)
        public ActionResult<Category> DeleteCategory(int id)
		{
			try
			{
                _repo.Delete(id);
                return RedirectToAction("api/Category");
            }
            catch (Exception e)
            {
                Console.WriteLine(e.ToString());
                return RedirectToAction("api/Category");
            }
        }
    }
}