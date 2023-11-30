using ACSystem.Application.Contracts.Persistence;
using ACSystem.Persistence.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System.ComponentModel;

namespace ACSystem.Persistence
{
    public static class PersistenceServicesRegistration
    {
        public static IServiceCollection ConfigurePersistenceServices(this IServiceCollection services,
            IConfiguration configuration)
        {

            services.AddDbContext<ACSystemDbContext>(options =>
            {
                options.UseSqlServer(configuration
                    .GetConnectionString("ACSystemConnectionString"));
            });


            services.AddScoped(typeof(IGenericRepository<>), typeof(GenericRepository<>));
            services.AddScoped<ILetterTypeRepository, LetterTypeRepository>();
            services.AddScoped<IEmployeeRepository, EmployeeRepository>();
            services.AddScoped<ILetterRepository, LetterRepository>();
            services.AddScoped<ILetterReferenceRepository, LetterReferenceRepository>();
            services.AddScoped<ILetterAttachRepository, LetterAttachRepository>();
            services.AddScoped<ILetterNoteRepository, LetterNoteRepository>();


            return services;
        }
    }
}
