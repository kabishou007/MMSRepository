using Autofac;
using Autofac.Integration.Mvc;
using MMS.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;

namespace MMS.Web
{
    public class MvcApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            AutofacInit();

            AreaRegistration.RegisterAllAreas();
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);
        }

        private void AutofacInit()
        {
            ContainerBuilder builder = new ContainerBuilder();
            builder.RegisterGeneric(typeof(Repository<,>)).As(typeof(IRepository<,>));
            Type baseType = typeof(IDependency);

            // 获取所有相关类库的程序集
            Assembly[] assemblies = ...

            builder.RegisterAssemblyTypes(assemblies)
                .Where(type => baseType.IsAssignableFrom(type) && !type.IsAbstract)
                .AsImplementedInterfaces().InstancePerLifetimeScope();//InstancePerLifetimeScope 保证对象生命周期基于请求
            IContainer container = builder.Build();
            DependencyResolver.SetResolver(new AutofacDependencyResolver(container));


            =============================
            ContainerBuilder builder = new ContainerBuilder();

            //获得标记依赖注入的接口的类型
            Type baseType = typeof(IDependency);
            //注册所有程序集中的实现了IDependency接口的类，实例化这些类时使用autofac注入
            var assemblies = AppDomain.CurrentDomain.GetAssemblies();
            builder.RegisterAssemblyTypes(assemblies)
                .Where(type => baseType.IsAssignableFrom(type) && type != baseType)
                .AsImplementedInterfaces().PropertiesAutowired().InstancePerRequest().PreserveExistingDefaults();
            //属性注入到视图View(同时创建类继承viewpage，注入具体属性)
            //builder.RegisterSource(new ViewRegistrationSource());
            //属性注入到Action
            builder.RegisterFilterProvider();
            //注册模型绑定器
            builder.RegisterModelBinderProvider();
            //注册所有的Controller，当实例化Controller类时，使用Autofac产生并注入
            builder.RegisterControllers(Assembly.GetExecutingAssembly()).PropertiesAutowired().InstancePerRequest().PreserveExistingDefaults();

            IContainer container = builder.Build();
            //设置由autofac的resolver提供类的实例(注入到MVC的IDependencyResolver创建Controller实例)
            DependencyResolver.SetResolver(new AutofacDependencyResolver(container));







        }




    }
}
