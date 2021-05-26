using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace WebApplication1.Models
{
	public class ProductRepresentation
	{
        public ProductRepresentation(int prodID, string name, string desc, decimal prc, decimal baseprc, string img, int categid)
        {
            this.ProductID = prodID;
            this.Name = name;
            this.Description = desc;
            this.Price = prc;
            this.BasePrice = baseprc;
            this.Image = img;
            this.CategoryID = categid;
        }

        [JsonProperty(PropertyName = "productId")]
        public int ProductID { get; set; }

        [JsonProperty(PropertyName = "name")]
        public string Name { get; set; }

        [JsonProperty(PropertyName = "description")]
        public string Description { get; set; }

        [JsonProperty(PropertyName = "price")]
        public decimal Price { get; set; }

        [JsonProperty(PropertyName = "baseprice")]
        public decimal BasePrice { get; set; }

        [JsonProperty(PropertyName = "image")]
        public string Image { get; set; }

        [JsonProperty(PropertyName = "categoryId")]
        public int CategoryID { get; set; }
    }
}
