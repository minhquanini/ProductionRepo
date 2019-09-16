using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using ProductUI.IProductTaskManagement;
using ProductUI.Models;

namespace ProductUI.Controllers
{
    public class ProductController : Controller
    {
        private readonly IProductManagement _productManagement;

        public ProductController(IProductManagement productManagement)
        {
            _productManagement = productManagement;
        }

        public async Task<IActionResult> Index()
        {
            var vm = await _productManagement.GetProducts();
            return View(vm);
        }

        public async Task<IActionResult> ProductReview(int id)
        {
            var vm = await _productManagement.GetProductById(id);

            if (vm == null)
            {
                return RedirectToAction("Error");
            }

            var review = new ReviewViewModel()
            {
                ProductId = vm.Id,
                ProductName = vm.ProductName
            };

            return View(review);
        }

        [HttpPost]
        public async Task<IActionResult> ProductReview(ReviewViewModel vm)
        {
            if(vm.ProductId != 0 && ModelState.IsValid)
            {
                var user = await _productManagement.GetUserbyEmail(vm.Email);
                if(user != null)
                {
                    vm.UserId = user.Id;
                    var result = await _productManagement.PostReview(vm);
                    if (result)
                        return RedirectToAction("Index");
                }
                else
                {
                    ModelState.AddModelError("Email", "Email is not included in system");
                }
            }
            
            return View(vm);
        }

        public IActionResult Error()
        {
            return View();
        }

        public async Task<IActionResult> GetProductsByBrandId(int brandId)
        {
            var products = await _productManagement.GetProductsByBrandId(brandId);
            if (products.Count() == 0)
            {
                return RedirectToAction("Error");
            }
            return View("Index", products);
        }
       
    }
}