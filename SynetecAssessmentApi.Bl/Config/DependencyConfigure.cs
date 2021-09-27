using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using SynetecAssessmentApi.Bl.BonusProvider;
using SynetecAssessmentApi.Bl.Services;
using SynetecAssessmentApi.Persistence.Database;

namespace SynetecAssessmentApi.Bl.Config
{
    public static class DependencyConfigure
    {
        public static void BlDependencyInjection(this IServiceCollection services, IConfiguration configuration)
        {
            AddDependencies(services);
            services.DatabaseAccessDependencyInjection(configuration);
        }

        private static void AddDependencies(IServiceCollection services)
        {
            services.AddScoped<IBonusPoolService, BonusPoolService>();
            services.AddScoped<IBonusProvider, BonusProvider.BonusProvider>();
        }
    }
}
