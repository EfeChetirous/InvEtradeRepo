using System;
using System.Collections.Generic;

namespace Inveon.Data.DummyEntity
{
    public partial class Product
    {
        public Product()
        {
            ProductImageNavigation = new HashSet<ProductImage>();
        }

        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public decimal? Price { get; set; }
        public string ProductImage { get; set; }
        public int? Quantity { get; set; }
        public DateTime? DateCreated { get; set; }
        public string UserCreated { get; set; }
        public DateTime? DateModified { get; set; }
        public string UserModified { get; set; }

        public virtual ICollection<ProductImage> ProductImageNavigation { get; set; }
    }
}
