using AutoMapper;
using Entity.DTO.Product;
using Entity.Entities;

namespace Entity.Profiles;

public class Mapper : Profile
{
    public Mapper()
    {
        //CreateMap<Product, ProductGetDTO>()
        //    .ForMember(n => n.Id, n => n.MapFrom(n => n.Id))
        //    .ForMember(n => n.Title, n => n.MapFrom(n => n.Title))
        //    .ForMember(n => n.Price, n => n.MapFrom(n => n.Price))
        //    .ForMember(n => n.ImageName, n => n.MapFrom(n => n.ProductImages.FirstOrDefault().Image.Name));
    }
}
