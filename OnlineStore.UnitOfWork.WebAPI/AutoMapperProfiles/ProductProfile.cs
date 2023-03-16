using AutoMapper;
using OnlineStore.UnitOfWork.WebAPI.DTO;
using OnlineStore.UnitOfWork.WebAPI.Models;

namespace OnlineStore.UnitOfWork.WebAPI.AutoMapperProfiles
{
    public class ProductProfile : Profile
    {
        public ProductProfile()
        {
            //Map for Get Products
            CreateMap<Product, ProductDto>()
                .ForMember(d => d.Product_Name, option => option.MapFrom(s => s.ProductName))
                .ForMember(d => d.CategoryName, option => option.MapFrom(s => s.Category.CategoryName));

            //Map for Add or Update
            CreateMap<AddOrUpdateProductDto, Product>().ForMember(d => d.ProductName, option => option.MapFrom(s => s.Product_Name));
        }
    }
}
