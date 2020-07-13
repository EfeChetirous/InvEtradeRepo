using Inveon.Data.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Inveon.Data.Entity
{
    public class ProductImage : BaseEntity
    {
        public int Id { get; set; }
        public string ImageUrl { get; set; }
        public int? ProductId { get; set; }

        public virtual Product Product { get; set; }
    }
}
