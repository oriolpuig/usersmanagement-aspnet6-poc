using Autofac;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using UsersManagement.Common.Repositories;
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
            RegisterIdentityLayer(builder);
        }

        private void RegisterRepositoryLayer(ContainerBuilder builder)
        {
            builder.RegisterType<UserRepository>().As<IUserRepository>().InstancePerLifetimeScope();
        }

        private void RegisterServiceLayer(ContainerBuilder builder)
        {
            builder.RegisterType<AuthenticationService>().As<IAuthenticationService>().InstancePerLifetimeScope();
            builder.RegisterType<UserService>().As<IUserService>().InstancePerLifetimeScope();
        }

        private void RegisterIdentityLayer(ContainerBuilder builder)
        {
            builder.RegisterType<UserStore<IdentityUser>>().As<IUserStore<IdentityUser>>();
            builder.RegisterType<RoleStore<IdentityRole>>().As<IRoleStore<IdentityRole, string>>();
            builder.RegisterType<ApplicationUserManager>();
            builder.RegisterType<ApplicationRoleManager>();
        }
    }
}
