using AutoMapper;

namespace EnShop.Api.Extensions
{
    public class AutoMapperConfig
    {
        public static MapperConfiguration RegiestMappers()
        {
            return new MapperConfiguration(cfg =>
            {
                cfg.AddProfile(new CustomProfile());
            });
        }
    }
}
