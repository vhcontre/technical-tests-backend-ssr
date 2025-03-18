using AutoMapper;
using technical_tests_backend_ssr.Models;

public class AutoMapperProfile : Profile
{
    public AutoMapperProfile()
    {
        CreateMap<Producto, ProductoDTO>().ReverseMap();
    }
}

