using BugTracker.Api.Common.Errors;
using BugTracker.Api.Common.Mapping;
using ProblemDetailsFactory = Microsoft.AspNetCore.Mvc.Infrastructure.ProblemDetailsFactory;

namespace BugTracker.Api
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddPresentation(this IServiceCollection services)
        {
            services.AddControllers();
            services.AddSingleton<ProblemDetailsFactory, BugTrackerProblemDetailsFactory>();

            services.AddMappings();
            return services;
        }
    }
}
