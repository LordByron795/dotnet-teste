using System.Collections.Generic;
using System.Threading.Tasks;
using ApplicantTracking.Application.DTOs;
using ApplicantTracking.Domain.Entities;

namespace ApplicantTracking.Application.Interfaces
{
    public interface ICandidatesService
    {
        Task<IEnumerable<Candidates>> GetAll();

        Task<Candidates> GetById(int id);

        Task<Candidates> Add(CandidatesRequestDto genre);

        Task Update(Candidates candidates);

        Task Remove(int id);


    }
}
