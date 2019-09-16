using AutoMapper;
using Product.Core.Entities;
using Product.Core.Models;
using ProductAPI.IRepository;
using ProductAPI.IService;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProductAPI.Services
{
    public class ProductService : IProductService
    {
        private readonly IProductRepository _productRepository;
        private readonly IMapper _mapper;
        public ProductService(IProductRepository productRepository, IMapper mapper)
        {
            _productRepository = productRepository;
            _mapper = mapper;
        }
        public IEnumerable<ProductModel> GetAll()
        {
            var result = _productRepository.GetAll();
            return _mapper.Map<IEnumerable<Products>, IEnumerable<ProductModel>>(result);
        }

        public BrandModel GetBrandById(int brandId)
        {
            var result = _productRepository.GetBrandById(brandId);
            return _mapper.Map<Brands, BrandModel>(result);
        }

        public IEnumerable<BrandModel> GetBrands()
        {
            var result = _productRepository.GetBrands();
            return _mapper.Map<IEnumerable<Brands>, IEnumerable<BrandModel>>(result);
        }

        public IEnumerable<ProductModel> GetProductByBrandId(int brandId)
        {
            var result = _productRepository.GetProductByBrandId(brandId);
            return _mapper.Map<IEnumerable<Products>, IEnumerable<ProductModel>>(result);
        }

        public ProductModel GetProductById(int id)
        {
            var result = _productRepository.GetProductById(id);
            return _mapper.Map<Products, ProductModel>(result);
        }

        public IEnumerable<ReviewModel> GetReviews()
        {
            var result = _productRepository.GetReviews();
            return _mapper.Map<IEnumerable<Reviews>, IEnumerable<ReviewModel>>(result);
        }

        public UserModel GetUserByEmail(string email)
        {
            var result = _productRepository.GetUserByEmail(email);
            return _mapper.Map<Users, UserModel>(result);
        }

        public IEnumerable<UserModel> GetUsers()
        {
            var result = _productRepository.GetUsers();
            return _mapper.Map<IEnumerable<Users>, IEnumerable<UserModel>>(result);
        }

        public bool PostReview(ReviewModel review)
        {
            var model = _mapper.Map<ReviewModel, Reviews>(review);
            return _productRepository.PostReview(model);
        }
    }
}
