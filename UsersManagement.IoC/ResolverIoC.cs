using Autofac;
using Microsoft.AspNet.Identity.EntityFramework;
using Microsoft.AspNet.Identity.Owin;
using UsersManagement.Common.Repositories;
using UsersManagement.DataAccess.Context;
using UsersManagement.DataAccess.Managers;
using UsersManagement.DataAccess.Repositories;
using UsersManagement.ServiceLibrary.Common.Contracts;
using UsersManagement.ServiceLibrary.Implementations;

namespace UsersManagement.IoC
{
    public class ResolverIoC : Module
    {
        public ResolverIoC()
        {
        }

        protected override void Load(ContainerBuilder builder)
        {
            base.Load(builder);
            RegisterRepositoryLayer(builder);
            RegisterServiceLayer(builder);
        }

        private void RegisterRepositoryLayer(ContainerBuilder builder)
        {
            builder.RegisterType<UserRepository>().As<IUserRepository>().InstancePerLifetimeScope();

            var x = new MyContext();
            builder.Register<MyContext>(c => x);
            builder.Register<UserStore<IdentityUser>>(c => new UserStore<IdentityUser>(x)).AsImplementedInterfaces();
            builder.Register<RoleStore<IdentityRole>>(c => new RoleStore<IdentityRole>(x)).AsImplementedInterfaces();
            builder.Register<IdentityFactoryOptions<ApplicationUserManager>>(c => new IdentityFactoryOptions<ApplicationUserManager>()
            {
                DataProtectionProvider = new Microsoft.Owin.Security.DataProtection.DpapiDataProtectionProvider("ApplicationName")
            });
            builder.RegisterType<ApplicationUserManager>();
            builder.RegisterType<ApplicationRoleManager>();
        }

        private void RegisterServiceLayer(ContainerBuilder builder)
        {
            builder.RegisterType<AuthenticationService>().As<IAuthenticationService>().InstancePerLifetimeScope();
            builder.RegisterType<UserService>().As<IUserService>().InstancePerLifetimeScope();
        }
    }
}
