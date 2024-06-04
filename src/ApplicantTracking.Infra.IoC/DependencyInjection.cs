using ApplicantTracking.Application.Interfaces;
using ApplicantTracking.Application.Services;
using ApplicantTracking.Domain.Interfaces;
using ApplicantTracking.Infra.Data.Repositories;
using Microsoft.Extensions.DependencyInjection;



namespace TechChallenge4.Infra.IoC
{
    public static class DependencyInjection
    {
        public static void RegisterServices(this IServiceCollection services)
        {
            services.AddScoped<ITimelinesRepository, TimelinesRepository>();
            services.AddScoped<ICandidatesRepository, CandidatesRepository>();

            services.AddScoped<ITimelinesService, TimelinesService>();
            services.AddScoped<ICandidatesService, ICandidatesService>();
        }
    }
}
