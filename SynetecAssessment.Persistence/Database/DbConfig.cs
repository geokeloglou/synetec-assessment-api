using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using SynetecAssessmentApi.Persistence.Repositories;

namespace SynetecAssessmentApi.Persistence.Database
{
    public static class DbConfig
    {
        public static void DatabaseAccessDependencyInjection(
            this IServiceCollection services,
            IConfiguration configuration)
        {
            AddDbContext(services);
            AddDependencies(services);
            Initialize(services);
        }

        private static void AddDbContext(IServiceCollection services)
        {
            services.AddDbContext<AppDbContext>(options => options.UseInMemoryDatabase(databaseName: "HrDb"));
        }

        private static void Initialize(IServiceCollection services)
        {
            ServiceProvider serviceProvider = services.BuildServiceProvider();
            DbContextGenerator.Initialize(serviceProvider);
        }

        private static void AddDependencies(IServiceCollection services)
        {
            services.AddTransient<IEmployeeRepository, EmployeeRepository>();
        }
    }
}
