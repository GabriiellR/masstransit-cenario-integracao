using Microsoft.Extensions.DependencyInjection;

namespace Benner.ModulesIoc
{
    public static class Modules
    {
        public static void RegisterModules(this IServiceCollection service)
        {
            RegisterTransient(service);
            RegisterSingleton(service);
            RegisterScoped(service);
        }

        private static void RegisterTransient(IServiceCollection service) { }

        private static void RegisterSingleton(IServiceCollection service)
        {
        }

        private static void RegisterScoped(IServiceCollection service)
        {

        }
    }
}
