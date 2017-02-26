using AutoMapper;
using DataModels.Database;
using DataModels.Response;

namespace ProductHelper
{
    public class MapperConfig
    {
        public static void InitMapper()
        {
            Mapper.Initialize(cfg =>
            {
                cfg.CreateMap<Product, ProductResponse>();
                cfg.CreateMap<Ailment, AilmentResponse>();
            });
        }
    }
}