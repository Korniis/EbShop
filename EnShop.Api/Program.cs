using Autofac;
using Autofac.Extensions.DependencyInjection;
using EnShop.Api.Extensions;
using EnShop.Extension.ServiceExtensions;
using Microsoft.AspNetCore.Mvc.Controllers;
using Microsoft.Extensions.DependencyInjection.Extensions;
namespace EnShop.Api
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);
            builder.Host.UseServiceProviderFactory(new AutofacServiceProviderFactory())
                .ConfigureContainer<ContainerBuilder>(builder =>
                {
                    builder.RegisterModule<AutofacModuleRegister>();
                    builder.RegisterModule<AutofacPropertityModuleReg>();
                });
            //builder.ConfigureApplication();
            // Add services to the container.

            builder.Services.Replace(ServiceDescriptor.Transient<IControllerActivator, ServiceBasedControllerActivator>());

            // Add services to the container.
            builder.Services.AddControllers();
            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();
            // builder.Services.AddScoped<IUserService, UserService>();
            builder.Services.AddAutoMapper(typeof(AutoMapperConfig));
            AutoMapperConfig.RegiestMappers();
            /*     builder.Services.AddScoped<IUserRepository, UserRepository>();
                 builder.Services.AddScoped<IUserService, UserService>();
                 builder.Services.AddScoped(typeof(IBaseRepository<>), typeof(BaseRepository<>));
                 builder.Services.AddScoped(typeof(IBaseService<,>), typeof(BaseService<,>));*/
            var app = builder.Build();
            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }
           // app.UseHttpsRedirection();
            app.UseAuthorization();
            app.MapControllers();
            app.Run();
        }
    }
}
