using AutoMapper;
using BLL.DTO;
using Ecommerce.Models;
using Ecommerce.Models.DTO;

namespace Ecommerce.MappingProfile
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
           CreateMap<Product, ProductDTO>().ReverseMap();
            CreateMap<Product, CreateProductDTO>().ReverseMap();
        }

    }
}
