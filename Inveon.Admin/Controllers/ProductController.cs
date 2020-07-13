using Inveon.Admin.Core;
using Inveon.Model.EntityModels;
using Inveon.Service.Interfaces;
using Microsoft.AspNet.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Inveon.Admin.Controllers
{
    [Authorize(Roles = "Admin")]
    public class ProductController : BaseController
    {
        private readonly IProductService _productService;
        public ProductController(IProductService productService)
        {
            _productService = productService;
        }
        // GET: Product
        public ActionResult Index()
        {
            var result = _productService.GetAll();
            if (result.Success)
            {
                return View(result.Root as IEnumerable<Inveon.Model.EntityModels.ProductModel>);
            }
            return new RedirectResult("~/Views/Shared/Error.cshtml");
        }

        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult CreateProduct(ProductModel product)
        {
            product.UserCreated = CurrentUser.UserName;
            var result = _productService.CreateProduct(product);
            if (result.Success)
            {
                var products = _productService.GetAll();
                return View("Index", products.Root as IEnumerable<Inveon.Model.EntityModels.ProductModel>);
            }
            ViewBag.ErrorMessages = result.Message;
            return View("Create");
        }

        public ActionResult Edit()
        {
            return View();
        }

        [HttpPost]
        public ActionResult DeleteProduct(int id)
        {
            var result = _productService.DeleteProduct(id);
            if (result.Success)
            {
                var products = _productService.GetAll();
                return Json(result);
            }
            ViewBag.ErrorMessages = result.Message;
            return Json(result);
        }
    }
}