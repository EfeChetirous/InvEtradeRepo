using System;
using System.Collections.Generic;

namespace Inveon.Data.DummyEntity
{
    public partial class ProductImage
    {
        public int Id { get; set; }
        public string ImageUrl { get; set; }
        public int? ProductId { get; set; }
        public DateTime? DateCreated { get; set; }
        public string UserCreated { get; set; }
        public DateTime? DateModified { get; set; }
        public string UserModified { get; set; }

        public virtual Product Product { get; set; }
    }
}
