using Product.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProductAPI.IService
{
    public interface IProductService
    {
        IEnumerable<ProductModel> GetAll();
        IEnumerable<BrandModel> GetBrands();
        BrandModel GetBrandById(int brandId);
        ProductModel GetProductById(int id);
        IEnumerable<ProductModel> GetProductByBrandId(int brandId);
        bool PostReview(ReviewModel review);
        UserModel GetUserByEmail(string email);
        IEnumerable<ReviewModel> GetReviews();
        IEnumerable<UserModel> GetUsers();
    }
}
