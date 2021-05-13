using System.Collections.Generic;
using WebApplication1.Domain;

namespace WebApplication1.Business
{
    public interface ICategoryRepository
    {
        List<Category> GetCategories();
        Category Get(int id);
        Category Insert(Category category);
        Category Update(Category category);
        void Delete(int id);
    }
}