
using ApplicantTracking.Domain.Interfaces;
using Microsoft.Extensions.DependencyInjection;

namespace ApplicantTracking.Infra.IoC
{
    public static class DependencyInjection
    {
        public static void RegisterServices(this IServiceCollection services)
        {
            services.AddScoped<ITimelinesRepository, TimelinesRepository>();
            services.AddScoped<ICandidatesRepository, CandidatesRepository>();

            //services.AddScoped<IBookService, BookService>();
            //services.AddScoped<IGenreService, GenreService>();
        }
    }
}
