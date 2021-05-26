using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApplication1.Domain;

namespace WebApplication1.Business
{
	public interface IProductRepository
	{
		List<Product> GetProducts();
		Product Get(int id);
		Product Insert(Product product);
		Product Update(Product product);
		void Delete(int id);
	}
}
