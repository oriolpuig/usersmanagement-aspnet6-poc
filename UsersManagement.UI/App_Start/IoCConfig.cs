using Autofac;
using Autofac.Integration.Mvc;
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
            DependencyResolver.SetResolver(new AutofacDependencyResolver(container.Build()));
        }
        
        private static void RegisterControllerLayer(ContainerBuilder builder)
        {
            builder.RegisterType<AccountController>().InstancePerRequest();
        }
    }
}