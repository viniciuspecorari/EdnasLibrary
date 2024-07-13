using Microsoft.Extensions.DependencyInjection;
using System.Reflection;

namespace EdnasLibrary.Application
{
    public class MediatrDependency
    {
        public static void RegisterServices(IServiceCollection services)
        {
            services.AddMediatR(cfg => cfg.RegisterServicesFromAssembly(Assembly.GetExecutingAssembly())); // Registra todos os handlers nesta camada
            // Outros serviços da camada de Application
        }
    }
}
