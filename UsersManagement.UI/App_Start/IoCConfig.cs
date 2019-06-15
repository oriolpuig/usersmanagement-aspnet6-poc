using Autofac;
using Autofac.Integration.Mvc;
using Autofac.Integration.WebApi;
using System.Web.Http;
using System.Web.Mvc;
using UsersManagement.IoC;
using UsersManagement.UI.Controllers;

namespace UsersManagement.UI.App_Start
{
    public class IoCConfig
    {
        public static void RegisterIoC()
        {
            var container = ContainerIoC.Create();
            RegisterControllerLayer(container);
            RegisterWebApiControllerLayer(container);
            var build = container.Build();
            DependencyResolver.SetResolver(new AutofacDependencyResolver(build));
            GlobalConfiguration.Configuration.DependencyResolver = new AutofacWebApiDependencyResolver(build);
        }
        
        private static void RegisterControllerLayer(ContainerBuilder builder)
        {
            builder.RegisterType<AccountController>().InstancePerRequest();
        }

        private static void RegisterWebApiControllerLayer(ContainerBuilder builder)
        {
            builder.RegisterType<UsersController>().InstancePerRequest();
        }
    }
}