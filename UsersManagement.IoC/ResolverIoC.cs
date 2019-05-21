using System;
using Autofac;
using UsersManagement.Common.Repositories;
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
        }
        private void RegisterServiceLayer(ContainerBuilder builder)
        {
            builder.RegisterType<AuthenticationService>().As<IAuthenticationService>().InstancePerLifetimeScope();
        }
    }
}
