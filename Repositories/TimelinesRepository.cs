using ApplicantTracking.Domain.Entities;
using ApplicantTracking.Domain.Interfaces;
using ApplicantTracking.Infra.Data.Context;


namespace ApplicantTracking.Infra.Data.Repositories
{
    public class TimelinesRepository(ApplicationContext context) : BaseRepository<Timelines>(context), ITimelinesRepository
    {
    }
}
