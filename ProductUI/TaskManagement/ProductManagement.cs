using AutoMapper;
using Microsoft.Extensions.Configuration;
using Product.Core.Helpers;
using Product.Core.Models;
using ProductUI.IProductTaskManagement;
using ProductUI.Models;
using ProductUI.WebConsts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProductUI.TaskManagement
{
    public class ProductManagement : IProductManagement
    {
        private readonly IConfiguration _configuration;
        private readonly IMapper _mapper;

        public ProductManagement(IConfiguration configuration, IMapper mapper)
        {
            _configuration = configuration;
            _mapper = mapper;
        }
                
        public async Task<IEnumerable<ProductViewModel>> GetProducts()
        {
            var apiUrl = _configuration.GetSection("AppSettings:ApiUrl");
            var products = await WebApiUtils.GetWebApi<List<ProductModel>>(apiUrl.Value + $"/{WebApiConfig.ApiGetProducts}");
            var brands = await WebApiUtils.GetWebApi<List<BrandModel>>(apiUrl.Value + $"/{WebApiConfig.ApiGetBrands}");
            var reviews = await WebApiUtils.GetWebApi<List<ReviewModel>>(apiUrl.Value + $"/{WebApiConfig.ApiGetReviews}");
            var users = await WebApiUtils.GetWebApi<List<UserModel>>(apiUrl.Value + $"/{WebApiConfig.ApiGetUsers}");

            var vm = products.OrderBy(x => x.DateCreated).Take(10).Join(brands, p => p.BrandId, b => b.Id, (p, b) =>
              new ProductViewModel
              {
                  Id = p.Id,
                  ProductName = p.ProductName,
                  Description = p.Description,
                  BrandName = b.Name
              });

            var rw = reviews.Join(users, r => r.UserId, u => u.Id, (r, u) =>
                    new ReviewViewModel
                    {
                        Id = r.Id,
                        UserName = u.UserName,
                        Comment = r.Comment,
                        Rating = r.Rating,
                        ProductId = r.ProductId
                    });
            
            var result = from l1 in vm
                         join l2 in rw on l1.Id equals l2.ProductId
                         into all
                         from m in all.DefaultIfEmpty()
                             //select new { x = l1, y = m };
                         select new ProductViewModel
                         {
                             Id = l1.Id,
                             ProductName = l1.ProductName,
                             Description = l1.Description,
                             BrandName = l1.BrandName,
                             UserName = m?.UserName ?? null,
                             Comment = m?.Comment ?? null,
                             Rating = m?.Rating ?? 0
                         };

            return result;
        }

        public async Task<ProductViewModel> GetProductById(int id)
        {
            var apiUrl = _configuration.GetSection("AppSettings:ApiUrl");
            var product = await WebApiUtils.GetWebApi<ProductModel>(apiUrl.Value + $"/{WebApiConfig.ApiGetProductById}/{id}");
            if(product != null)
            {
                var brandId = product.BrandId;
                var brand = await WebApiUtils.GetWebApi<BrandModel>(apiUrl.Value + $"/{WebApiConfig.ApiGetBrandById}/{brandId}");

                return new ProductViewModel
                {
                    Id = product.Id,
                    ProductName = product.ProductName,
                    Description = product.Description,
                    BrandName = brand.Name
                };
            }

            return null;
        }


        public async Task<IEnumerable<ProductViewModel>> GetProductsByBrandId(int brandId)
        {
            var apiUrl = _configuration.GetSection("AppSettings:ApiUrl");
            var products = await WebApiUtils.GetWebApi<List<ProductModel>>(apiUrl.Value + $"/{WebApiConfig.ApiGetProductsByBrandId}/{brandId}");
            var brands = await WebApiUtils.GetWebApi<List<BrandModel>>(apiUrl.Value + $"/{WebApiConfig.ApiGetBrands}");
            return products.OrderBy(x => x.DateCreated).Take(10).Join(brands, p => p.BrandId, b => b.Id, (p, b) => new ProductViewModel()
            {
                Id = p.Id,
                ProductName = p.ProductName,
                Description = p.Description,
                BrandName = b.Name
            });
        }

        public async Task<bool> PostReview(ReviewViewModel review)
        {
            var apiUrl = _configuration.GetSection("AppSettings:ApiUrl");
            var model = new ReviewModel
            {
                ProductId = review.ProductId,
                Rating = review.Rating,
                Comment = review.Comment,
                UserId = review.UserId
            };
            var result = await WebApiUtils.PostWebApi(apiUrl.Value + $"/{WebApiConfig.ApiPostReview}", model);

            return result;
        }

        public async Task<UserViewModel> GetUserbyEmail(string email)
        {
            var apiUrl = _configuration.GetSection("AppSettings:ApiUrl");
            var result = await WebApiUtils.GetWebApi<UserModel>(apiUrl.Value + $"/{WebApiConfig.ApiGetUserbyEmail}/{email}");
            if (result == null)
                return null;
            return new UserViewModel
            {
                Id = result.Id,
                Email = result.Email
            };
        }
    }
}
