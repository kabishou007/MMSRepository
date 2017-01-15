using Autofac;
using Autofac.Integration.Mvc;
using MMS.Core;
using System;
using System.Linq;
using System.Reflection;
using System.Web.Mvc;

namespace MMS.Web
{
    public class AutofacConfig
    {
        /// <summary>
        /// 负责调用autofac框架实现继承了IDependency接口的类或接口对象的创建
        /// 负责创建MVC控制器类的对象(调用控制器中的有参构造函数),接管DefaultControllerFactory的工作
        /// </summary>
        public static void RegisterAutofac()
        {
            ContainerBuilder builder = new ContainerBuilder();

            //注册所有的Controller，当实例化Controller类时，使用Autofac产生并注入
            builder.RegisterControllers(Assembly.GetExecutingAssembly()).InstancePerLifetimeScope();
            //属性注入到视图View(同时创建类继承viewpage，注入具体属性)
            //builder.RegisterSource(new ViewRegistrationSource());
            //属性注入到Action
            //builder.RegisterFilterProvider();
            //注册模型绑定器
            //builder.RegisterModelBinderProvider();

            //获得标记依赖注入的接口的类型
            Type baseType = typeof(IDependency);
            //注册所有程序集中的实现了IDependency接口的类，实例化这些类时使用autofac注入
            Assembly[] assemblies = AppDomain.CurrentDomain.GetAssemblies();
            builder.RegisterAssemblyTypes(assemblies).Where(type => baseType.IsAssignableFrom(type) && !type.IsAbstract).AsImplementedInterfaces().InstancePerLifetimeScope();

            //创建一个Autofac的IoC容器
            IContainer container = builder.Build();
            //设置由autofac的resolver提供类的实例(注入到MVC的IDependencyResolver创建Controller实例)
            DependencyResolver.SetResolver(new AutofacDependencyResolver(container));
        }

    }
}