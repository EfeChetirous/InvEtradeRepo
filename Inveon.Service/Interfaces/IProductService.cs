using Inveon.Model.EntityModels;
using Inveon.Model.ResultModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Inveon.Service.Interfaces
{
    public interface IProductService
    {
        Result GetAll();
        Result GetAllProductsWithImages();
        Result CreateProduct(ProductModel productModel);
        Result DeleteProduct(int id);
    }
}
