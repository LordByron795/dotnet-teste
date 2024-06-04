using System.Collections.Generic;
using System.Threading.Tasks;
using ApplicantTracking.Application.DTOs;
using ApplicantTracking.Domain.Entities;

namespace ApplicantTracking.Application.Interfaces
{
    public interface ITimelinesService
    {
        Task<IEnumerable<Timelines>> GetAll();

        Task<Timelines> GetById(int id);

        Task<Timelines> Add(TimelinesRequestDto timelines);

        Task Update(Timelines timelines);

        Task Remove(int id);

        Task<IEnumerable<Timelines>> GetByIdAggregateRoot(int idAggregateRoot);
    }
}
