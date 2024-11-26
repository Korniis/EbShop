using AutoMapper;
using EnShop.IService;
using EnShop.Model.DTO;
using EnShop.Service.CService;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace EnShop.Api.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private  IUserService userService;
        readonly IMapper mapper;
        public UserController(IMapper mapper,IUserService baseService)
        {
            this.mapper = mapper;
            userService = baseService;
      
        }

        [HttpGet]
        public async Task<List<UserDTO>> Query()
        {
         
            var k =await userService.Query();
            return k;
        }
    }
}
