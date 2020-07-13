using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Inveon.Model.EntityModels
{
    public class ProductImageModel
    {
        public int Id { get; set; }
        public string ImageUrl { get; set; }
        public int? ProductId { get; set; }
        public DateTime? DateCreated { get; set; }
        public string UserCreated { get; set; }
        public DateTime? DateModified { get; set; }
        public string UserModified { get; set; }

        public virtual ProductModel Product { get; set; }
    }
}
