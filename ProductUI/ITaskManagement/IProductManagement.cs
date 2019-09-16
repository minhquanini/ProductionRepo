using Product.Core.Models;
using ProductUI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProductUI.IProductTaskManagement
{
    public interface IProductManagement
    {
        Task<IEnumerable<ProductViewModel>> GetProducts();
        Task<ProductViewModel> GetProductById(int id);
        Task<IEnumerable<ProductViewModel>> GetProductsByBrandId(int brandId);
        Task<bool> PostReview(ReviewViewModel review);
        Task<UserViewModel> GetUserbyEmail(string email);
    }
}
