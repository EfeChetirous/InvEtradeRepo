using Inveon.Data.Repository;
using System;
using System.Collections.Generic;

namespace Inveon.Data.Entity
{
    public partial class Product : BaseEntity
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public decimal? Price { get; set; }
        public string Barcode { get; set; }
        public int? Quantity { get; set; }
        public virtual ICollection<ProductImage> ProductImageNavigation { get; set; }

    }
}
