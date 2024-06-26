using Intranet.Application;
using Intranet.Application.Interfaces;
using Intranet.Repository;
using Intranet.Repository.Interface;

namespace Intranet.ModulesIoc
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
            service.AddSingleton<IRepositoryCentroCusto, RepositoryCentroCusto>();
        }

        private static void RegisterScoped(IServiceCollection service)
        {
            service.AddScoped<IApplicationServiceCentroCusto, ApplicationServiceCentroCusto>();
        }
    }
}
