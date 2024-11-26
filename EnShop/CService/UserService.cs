using AutoMapper;
using EnShop.IService;
using EnShop.Model.DTO;
using EnShop.Model.UserModel;
using EnShop.Repository;
using EnShop.Repository.CRepository;

namespace EnShop.Service.CService
{
    public class UserService : BaseService<User, UserDTO>, IUserService
    {
   

        public UserService(IMapper mapper, IUserRepository baseRepository) : base(mapper, baseRepository)
        {
         
            base._baseRepository = baseRepository;
         
        }
    }
}
