using AutoMapper;
using GrantAdvance.Backend.Application.Products.GetProducts;
using GrantAdvance.Backend.Domain.Products;

namespace GrantAdvance.Backend.Application.Mapper;

public sealed class MappingProfile : Profile
{
    public MappingProfile()
    {
        CreateMap<Product, ProductResponse>()
            .ForMember(d => d.Name, o =>
            {
                o.MapFrom(s => s.Name.Value);
            })
            .ForMember(d => d.Price, o =>
            {
                o.MapFrom(s => s.Price.Value);
            })
            .ForMember(d => d.CreationDate, o =>
            {
                o.MapFrom(s => s.CreationDate.Value);
            });
    }
}
