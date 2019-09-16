using AutoMapper;
using Product.Core.Entities;
using Product.Core.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Product.Core.Helpers
{
    public class MappingProfiles : Profile
    {
        public MappingProfiles()
        {
            CreateMap<Products, ProductModel>();
            CreateMap<Brands, BrandModel>();
            CreateMap<Users, UserModel>();
            CreateMap<Reviews, ReviewModel>();
            CreateMap<ReviewModel, Reviews>();
        }
    }
}
