using Product.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProductAPI.IRepository
{
    public interface IProductRepository
    {
        IEnumerable<Products> GetAll();
        IEnumerable<Brands> GetBrands();
        Brands GetBrandById(int brandId);
        IEnumerable<Products> GetProductByBrandId(int brandId);
        Products GetProductById(int id);
        bool PostReview(Reviews review);
        Users GetUserByEmail(string email);
        IEnumerable<Reviews> GetReviews();
        IEnumerable<Users> GetUsers();
    }
}
