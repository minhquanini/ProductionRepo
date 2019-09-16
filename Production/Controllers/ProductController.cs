using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Product.Core.Models;
using ProductAPI.IService;

namespace ProductAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly IProductService _productService;

        public ProductController(IProductService productService)
        {
            _productService = productService;
        }

        [Route("getProducts")]
        public JsonResult GetProducts()
        {
            return new JsonResult(_productService.GetAll());
        }

        [Route("getProductById/{id}")]
        public JsonResult GetProductById(int id)
        {
            return new JsonResult(_productService.GetProductById(id));
        }

        [Route("getBrands")]
        public JsonResult GetBrands()
        {
            return new JsonResult(_productService.GetBrands());
        }

        [Route("getBrandById/{brandId}")]
        public JsonResult GetBrandById(int brandId)
        {
            return new JsonResult(_productService.GetBrandById(brandId));
        }

        [Route("getProductsByBrandId/{brandId}")]
        public JsonResult GetProductsByBrandId(int brandId)
        {
            return new JsonResult(_productService.GetProductByBrandId(brandId));
        }

        [Route("getUserbyEmail/{email}")]
        public JsonResult GetUserbyEmail(string email)
        {
            return new JsonResult(_productService.GetUserByEmail(email));
        }

        [HttpPost("postReview")]
        public JsonResult PostReview(ReviewModel review)
        {
            return new JsonResult(_productService.PostReview(review));
        }

        [Route("getReviews")]
        public JsonResult GetReviews()
        {
            return new JsonResult(_productService.GetReviews());
        }

        [Route("getUsers")]
        public JsonResult GetUsers()
        {
            return new JsonResult(_productService.GetUsers());
        }
    }
}