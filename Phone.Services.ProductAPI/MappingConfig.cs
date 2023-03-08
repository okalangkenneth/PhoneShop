using AutoMapper;
using Phone.Services.ProductAPI.Models;
using Phone.Services.ProductAPI.Models.Dto;

namespace Phone.Services.ProductAPI
{
    public class MappingConfig
    {
        public static MapperConfiguration RegisterMaps()
        {
            var mappingConfig = new MapperConfiguration(config =>
            {
                config.CreateMap<ProductDto, Product>();
                config.CreateMap<Product, ProductDto>();

            });

            return mappingConfig;
        }

    }
}
