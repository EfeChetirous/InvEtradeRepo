using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Inveon.Model.EntityModels
{
    public class ProductsWithImagesModel
    {
        public ProductsWithImagesModel()
        {
            this.ProductImages = new List<string>();
        }
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public decimal? Price { get; set; }
        public string Barcode { get; set; }
        public int? Quantity { get; set; }
        public List<string> ProductImages { get; set; }
    }
}
