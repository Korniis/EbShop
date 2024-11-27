using AutoMapper;
using EnShop.Common.Option;
using EnShop.IService;
using EnShop.Model.DTO;
using EnShop.Service.CService;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;

namespace EnShop.Api.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private  IUserService userService;
       private  readonly IMapper mapper;
        private IOptions<RedisCli> redisoptions;

        public UserController(IMapper mapper, IUserService baseService, IOptions<RedisCli> options)
        {
            this.mapper = mapper;
            userService = baseService;
            this.redisoptions = options;
        }

        [HttpGet]
        public async Task<List<UserDTO>> Query()
        {
         
            var k =await userService.Query();
            var redis = AppSettings.app(["Redis", "Enable"]);
            var rediscon = AppSettings.app<string>("Redis");
            Console.WriteLine(redis);
            Console.WriteLine(rediscon);
            RedisCli hasdf = redisoptions.Value;
            Console.WriteLine(hasdf);
            return k;

        }
    }
}
