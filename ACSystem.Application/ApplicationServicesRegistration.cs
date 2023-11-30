using ACSystem.Application.Contracts.Service;
using ACSystem.Application.Service;
using MediatR;
using Microsoft.Extensions.DependencyInjection;
using System.Reflection;

namespace ACSystem.Application
{
    public static class ApplicationServicesRegistration
    {
        public static void ConfigureApplicationServices(this IServiceCollection services)
        {
            services.AddTransient<IFileManager, FileManager>();

            // services.AddAutoMapper(typeof(MappingProfile));
            services.AddAutoMapper(Assembly.GetExecutingAssembly());
            services.AddMediatR(Assembly.GetExecutingAssembly());

            services.AddMemoryCache();


            
            


        }
    }
}
