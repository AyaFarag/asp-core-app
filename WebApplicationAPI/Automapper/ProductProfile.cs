using AutoMapper;
using WebApplicationAPI.DTO;
using WebApplicationAPI.Model;

namespace WebApplicationAPI.Automapper
{
    public class ProductProfile : Profile
    {
        public ProductProfile()
        {
            CreateMap<Product, CreateProductDTO>().ReverseMap();
            CreateMap<Product, UpdateProductDTO>().ReverseMap();
            CreateMap<Product, ProductResponseDTO>().ReverseMap();

        }
    }
}
