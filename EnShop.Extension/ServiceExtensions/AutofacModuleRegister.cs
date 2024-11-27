using Autofac;
using Autofac.Extras.DynamicProxy;
using EnShop.IService;
using EnShop.Repository;
using EnShop.Service.CService;
using System.Reflection;
namespace EnShop.Extension.ServiceExtensions
{
    public class AutofacModuleRegister : Autofac.Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            var basePath = AppContext.BaseDirectory;
            var servicesDllFile = Path.Combine(basePath, "EnShop.Service.dll");
            var repositoryDllFile = Path.Combine(basePath, "EnShop.Repository.dll");


            var aopTypes = new List<Type>() { typeof(ServiceAOP) };
            builder.RegisterType<ServiceAOP>();
            builder.RegisterGeneric(typeof(BaseRepository<>)).As(typeof(IBaseRepository<>))
                .InstancePerDependency()
                ;  //注册仓储
            builder.RegisterGeneric(typeof(BaseService<,>)).As(typeof(IBaseService<,>))
                 .InstancePerDependency()
                .EnableInterfaceInterceptors()
                   .InterceptedBy(aopTypes.ToArray());  //注册服务
            // 获取 Service.dll 程序集服务，并注册
            var assemblysServices = Assembly.LoadFrom(servicesDllFile);
            builder.RegisterAssemblyTypes(assemblysServices)
                   .AsImplementedInterfaces()
                   .InstancePerDependency()
                   .PropertiesAutowired()
                   .EnableInterfaceInterceptors()
                   .InterceptedBy(aopTypes.ToArray()); ;
            // 获取 Repository.dll 程序集服务，并注册
            var assemblysRepository = Assembly.LoadFrom(repositoryDllFile);
            builder.RegisterAssemblyTypes(assemblysRepository)
                .AsImplementedInterfaces()
                .PropertiesAutowired()
                .InstancePerDependency();
            /*
                        builder.RegisterType<UnitOfWorkManage>().As<IUnitOfWorkManage>()
                            .AsImplementedInterfaces()
                            .InstancePerLifetimeScope()
                            .PropertiesAutowired();*/
        }
    }
}
