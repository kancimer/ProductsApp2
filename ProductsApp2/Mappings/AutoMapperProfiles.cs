using AutoMapper;
using ProductsApp2.Models.Domains;
using ProductsApp2.Models.DTOs;

namespace ProductsApp2.Mappings
{
    public class AutoMapperProfiles:Profile
    {
        public AutoMapperProfiles()
        {
            CreateMap<Products, ProductsDto>().ReverseMap();
            CreateMap<AddProductDto, Products>().ReverseMap();
            CreateMap<UpdateProductDto, Products>().ReverseMap();
        }
    }
}
