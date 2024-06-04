using ApplicantTracking.Domain.Entities;
using Microsoft.EntityFrameworkCore;


namespace ApplicantTracking.Infra.Data.Context
{
    public class ApplicationContext(DbContextOptions<ApplicationContext> options) : DbContext(options)
    {

        public DbSet<Candidates> Candidates { get; set; }
        public DbSet<Timelines> Timelines { get; set; }
    }
}
