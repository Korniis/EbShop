using AutoMapper;
using EnShop.IService;
using EnShop.Model.DTO;
using EnShop.Model.UserModel;
using EnShop.Service.CService;
using Microsoft.AspNetCore.Mvc;

namespace EnShop.Api.Controllers
{
    [ApiController]
    [Route("[controller]/[action]")]
    public class WeatherForecastController : ControllerBase
    {
        private static readonly string[] Summaries = new[]
        {
            "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
        };

        private readonly ILogger<WeatherForecastController> _logger;
        private readonly IMapper mapper;
        private readonly IBaseService<Role, RoleDTO> roleService;
        public WeatherForecastController(ILogger<WeatherForecastController> logger, IMapper mapper, IBaseService<Role, RoleDTO> roleService)
        {
            _logger = logger;
            this.mapper = mapper;
            this.roleService = roleService;
        }

        [HttpGet(Name = "GetWeatherForecast")]
        public IEnumerable<WeatherForecast> Get()
        {
            return Enumerable.Range(1, 5).Select(index => new WeatherForecast
            {
                Date = DateOnly.FromDateTime(DateTime.Now.AddDays(index)),
                TemperatureC = Random.Shared.Next(-20, 55),
                Summary = Summaries[Random.Shared.Next(Summaries.Length)]
            })
            .ToArray();
        }
        [HttpGet(Name ="query")]
        public async Task<List<RoleDTO>> Query()
        {
            /*      UserService userService = new UserService();
                  var k = await userService.Query();
                  return k;*/

            
            return await roleService.Query();

        }
    }
}
