using API.Core.Models;
using API.Dtos;
using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API.Helpers
{
    public class MappingProfiles:Profile
    {
        public MappingProfiles()
        {
            CreateMap<Product, ProductDto>()
                .ForMember(x => x.ProductBrand, o => o.MapFrom(x => x.ProductBrand.Name))
                .ForMember(x => x.ProductType, o => o.MapFrom(x => x.ProductType.Name))
                .ForMember(x => x.ImageUrl, o => o.MapFrom<ProductUrlResolver>());
        }
    }
}
