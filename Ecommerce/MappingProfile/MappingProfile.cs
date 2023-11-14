using AutoMapper;
using BLL.DTO;
using DAL.DTO;
using DAL.Models;
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
           CreateMap<CartDetails, CartDetailsDTO>().ReverseMap();
           CreateMap<ShoppingCart, ShoppingCartDTO>().ReverseMap();
           CreateMap<Customer, CustomerDTO>().ReverseMap();
            CreateMap<Customer, CreateCustomerDTO>().ReverseMap();
            CreateMap<Order, OrderDTO>().ReverseMap();
            CreateMap<OrderDetails, OrderDetailsDTO>().ReverseMap();
            CreateMap<ShoppingCart, ViewShoppingCartDTO>().ReverseMap();
            CreateMap<Order, ViewOrderDetailsDTO>().ReverseMap();
        }

    }
}
