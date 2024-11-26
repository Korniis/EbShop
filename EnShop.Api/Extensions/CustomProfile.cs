using AutoMapper;
using EnShop.Model.DTO;
using EnShop.Model.UserModel;

namespace EnShop.Api.Extensions
{
    public class CustomProfile : Profile
    {
        public CustomProfile()
        {
            CreateMap<Role, RoleDTO>().ForMember(a => a.RoleName, o => o.MapFrom(d => d.Name));
            CreateMap<RoleDTO, Role>().ForMember(a => a.Name, o => o.MapFrom(d => d.RoleName));
            CreateMap<User, UserDTO>().ForMember(a => a.UserName, o => o.MapFrom(d => d.Name));
            CreateMap<UserDTO, User>().ForMember(a => a.Name, o => o.MapFrom(d => d.UserName));

        }
    }
}
