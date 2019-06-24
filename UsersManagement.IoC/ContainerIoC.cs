using Autofac;
using Autofac.Extensions.DependencyInjection;

namespace UsersManagement.IoC
{
    public static class ContainerIoC
    {

        public static IContainer Container { get; set; }

        public static T GetInstance<T>()
        {
            return Container.Resolve<T>();
        }

        public static ContainerBuilder Create()
        {
            var containerBuilder = new ContainerBuilder();
            containerBuilder.RegisterModule(new ResolverIoC());
            return containerBuilder;
        }
    }
}
