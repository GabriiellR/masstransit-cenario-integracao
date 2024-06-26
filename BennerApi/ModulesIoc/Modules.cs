using BennerApi.Application;
using BennerApi.Application.Interfaces;
using BennerApi.Repository;
using BennerApi.Repository.Interfaces;

namespace BennerApi.ModulesIoc
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
            service.AddScoped<IApplicationServicePublisher, ApplicationServicePublisher>();
           
        }
    }
}
