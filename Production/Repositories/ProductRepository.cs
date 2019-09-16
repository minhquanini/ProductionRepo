using Product.Core.Entities;
using ProductAPI.IRepository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProductAPI.Repositoty
{
    public class ProductRepository : IProductRepository
    {
        private readonly ProductDBContext _productDBContext;
        public ProductRepository(ProductDBContext productDBContext)
        {
            _productDBContext = productDBContext;
        }

        public IEnumerable<Products> GetAll()
        {
            return _productDBContext.Products.ToList();
        }

        public Brands GetBrandById(int brandId)
        {
            return _productDBContext.Brands.Where(x => x.Id == brandId).FirstOrDefault();
        }

        public IEnumerable<Brands> GetBrands()
        {
            return _productDBContext.Brands.ToList();
        }

        public IEnumerable<Products> GetProductByBrandId(int brandId)
        {
            return _productDBContext.Products.Where(x => x.BrandId == brandId).ToList();
        }

        public Products GetProductById(int id)
        {
            return _productDBContext.Products.Where(x => x.Id == id).FirstOrDefault();
        }

        public IEnumerable<Reviews> GetReviews()
        {
            var result = from element in _productDBContext.Reviews
                         group element by element.ProductId
                         into groups
                         select groups.OrderByDescending(x => x.Id).First();

            return result;
        }

        public Users GetUserByEmail(string email)
        {
            return _productDBContext.Users.Where(x => x.Email == email).FirstOrDefault();
        }

        public IEnumerable<Users> GetUsers()
        {
            return _productDBContext.Users.ToList();
        }

        public bool PostReview(Reviews review)
        {
            try
            {
                _productDBContext.Reviews.Add(review);
                _productDBContext.SaveChanges();
                return true;
            }
            catch(Exception e)
            {
                return false;
            }

            
        }
    }
}
