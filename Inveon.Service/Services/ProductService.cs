using Inveon.Data.Entity;
using Inveon.Data.Repository;
using Inveon.Model.EntityModels;
using Inveon.Model.ResultModel;
using Inveon.Service.Interfaces;
using Mapster;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;

namespace Inveon.Service.Services
{

    public class ProductService : IProductService
    {
        private readonly IRepository<Product> _productRepository;
        private readonly IRepository<ProductImage> _productImageRepository;
        private readonly IUnitOfWork _unitOfWork;
        public ProductService(IRepository<Product> productRepository, IRepository<ProductImage> productImageRepository, IUnitOfWork unitOfWork)
        {
            _productRepository = productRepository;
            _productImageRepository = productImageRepository;
            _unitOfWork = unitOfWork;
        }

        public Result CreateProduct(ProductModel productModel)
        {
            //validation control
            if (string.IsNullOrWhiteSpace(productModel.Name) || string.IsNullOrWhiteSpace(productModel.Description) || productModel.Files.Length == 0
                || string.IsNullOrWhiteSpace(productModel.Barcode) || productModel.Quantity == 0 || productModel.Quantity == null || productModel.Price == null || productModel.Price == 0)
            {
                return new FailureResult("Please fill all fields.");
            }
            //product save
            var productEntity = productModel.Adapt<Product>();
            productEntity.DateCreated = DateTime.Now;
            productEntity.UserCreated = productModel.UserCreated;
            _unitOfWork.BeginTransaction();
            _productRepository.Insert(productEntity);
            _unitOfWork.SaveChanges();

            // save images
            var result = SaveProductPhoto(productModel, productEntity);
            if (!result.Success)
            {
                _unitOfWork.Rollback();
                return new FailureResult();
            }
            else
            {
                _unitOfWork.Commit();
            }
            return new SuccessResult(true,"Success");
        }

        private Result SaveProductPhoto(ProductModel productModel, Product entity)
        {
            try
            {
                string productFolder = $"Content\\ProductImages\\{entity.Id}";
                foreach (var file in productModel.Files)
                {
                    var physicalPath = HttpContext.Current.Request.PhysicalApplicationPath;
                    if (!Directory.Exists(Path.Combine(physicalPath, productFolder)))
                    {
                        Directory.CreateDirectory(Path.Combine(physicalPath, productFolder));
                    }
                    var newfilename = DateTime.Now.ToFileTimeUtc().ToString() + Path.GetExtension(file.FileName);
                    var path = Path.Combine(physicalPath, productFolder, newfilename);
                    file.SaveAs(path);

                    //Location of image
                    string productFolderDb = $"{HttpContext.Current.Request.Url.Scheme}://{HttpContext.Current.Request.Url.Authority}/Content/ProductImages/{entity.Id}/{newfilename}";

                    ProductImage image = new ProductImage();
                    image.ProductId = entity.Id;
                    image.ImageUrl = productFolderDb;
                    image.DateCreated = DateTime.Now;
                    image.UserCreated = productModel.UserCreated;

                    _productImageRepository.Insert(image);
                    _unitOfWork.SaveChanges();
                }
                return new SuccessResult(true, "success");
            }
            catch (Exception ex)
            {
                return new FailureResult();
            }
        }

        public Result DeleteProduct(int productId)
        {
            try
            {
                //open transaction
                _unitOfWork.BeginTransaction();
                //first delete images
                var productImages = _productImageRepository.Queryable().Where(x => x.ProductId == productId);
                foreach (var image in productImages)
                {
                    _productImageRepository.Delete(image);
                }

                // delete product
                var product = _productRepository.Queryable().FirstOrDefault(x => x.Id == productId);
                _productRepository.Delete(product);
                _unitOfWork.SaveChanges();
                _unitOfWork.Commit();
                return new SuccessResult(true,"The record is deleted");
            }
            catch (Exception ex)
            {
                _unitOfWork.Rollback();
                return new FailureResult("The record is not deleted.");
            }
        }

        public Result GetAll()
        {
            try
            {
                var allProducts = _productRepository.Queryable().Include(x=>x.ProductImageNavigation).ToList();
                var allProductModel = allProducts.Adapt<List<ProductModel>>();
                return new SuccessResult(allProductModel, "Operations is Succed");
            }
            catch (Exception ex)
            {
                return new FailureResult();
            }
        }

        public Result GetAllProductsWithImages()
        {
            try
            {
                List<ProductsWithImagesModel> products = new List<ProductsWithImagesModel>();
                var allProducts = _productRepository.Queryable().Include(x => x.ProductImageNavigation).ToList();
                foreach (var product in allProducts)
                {
                    ProductsWithImagesModel _product = new ProductsWithImagesModel();
                    _product.Barcode = product.Barcode;
                    _product.Description = product.Description;
                    _product.Name = product.Name;
                    _product.Price = product.Price;
                    _product.Quantity = product.Quantity;
                    _product.Id = product.Id;
                    if (product.ProductImageNavigation == null)
                    {
                        // If there is no photo don't show
                        continue;
                    }
                    foreach (var image in product.ProductImageNavigation)
                    {
                        _product.ProductImages.Add(image.ImageUrl);
                    }
                    products.Add(_product);
                }
                return new SuccessResult(products, "fetch product is success.");
            }
            catch (Exception ex)
            {
                return new FailureResult();
            }
        }
    }
}
