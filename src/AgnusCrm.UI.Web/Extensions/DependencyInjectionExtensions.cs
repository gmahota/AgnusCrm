
using AgnusCrm.Infra.CrossCutting.IoC;
using Microsoft.Extensions.DependencyInjection;

namespace Site.Extensions
{
    public static class DependencyInjectionExtensions
    {
        public static void AddDependencyInjection(this IServiceCollection services)
        {
            NativeInjectorBootStrapper.RegisterServices(services);
        }
    }
}