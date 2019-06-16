using Autofac;
using Autofac.Integration.Mvc;
using Autofac.Integration.WebApi;
using System.Web.Http;
using System.Web.Mvc;
using UsersManagement.IoC;
using UsersManagement.ServiceLibrary.Common.Contracts;
using UsersManagement.UI.Controllers;
using UsersManagement.UI.Filters;

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
            ServiceLocator.UserService = DependencyResolver.Current.GetService(typeof(IUserService)) as IUserService;
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