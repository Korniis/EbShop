using AutoMapper;

namespace EnShop.Extension.ServiceExtensions
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
