using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Xml.Linq;
using ApplicantTracking.Application.DTOs;
using ApplicantTracking.Application.Interfaces;
using ApplicantTracking.Domain.Entities;
using ApplicantTracking.Domain.Enumerators;
using ApplicantTracking.Domain.Interfaces;

namespace ApplicantTracking.Application.Services
{
    public class CandidateService : ICandidatesService
    {
        private readonly ICandidatesRepository _candidatesRepository;
        private readonly ITimelinesRepository _timelinesRepository;

        public CandidateService(ICandidatesRepository candidatesRepository, ITimelinesRepository timelinesRepository)
        {
            _candidatesRepository = candidatesRepository;
            _timelinesRepository = timelinesRepository;
        }

        public async Task<Candidates> Add(CandidatesRequestDto candidates)
        {
            Candidates candidatesEntity = new(candidates.Name, candidates.Surname, candidates.Birthdate, candidates.Email, DateTime.Now, DateTime.Now);
            await _candidatesRepository.Add(candidatesEntity);

            Timelines timelinesEntity = new((int)TimelineTypes.Create, candidatesEntity.Id, null, null, DateTime.Now);

            await _timelinesRepository.Add(timelinesEntity);
            
            return candidatesEntity;
        }

        public async Task<IEnumerable<Candidates>> GetAll()
        {
            IEnumerable<Candidates> candidates = await _candidatesRepository.GetAll();
            return candidates.OrderBy(can => can.Name);
        }

        public async Task<Candidates> GetById(int id)
        {
            Candidates? candidates = await _candidatesRepository.GetById(id);

            return candidates ?? throw new Exception("Candidate not found");
        }

        public async Task Remove(int id)
        {
            await _candidatesRepository.Delete(await GetById(id));
            Timelines timelinesEntity = new((int)TimelineTypes.Delete, id, null, null, null);

            await _timelinesRepository.Update(timelinesEntity);
        }

        public async Task Update(Candidates candidates)
        {
            _ = await GetById(candidates.Id);
            await _candidatesRepository.Update(candidates);

            Timelines timelinesEntity = new((int)TimelineTypes.Update, candidates.Id, null, null, null);

            await _timelinesRepository.Update(timelinesEntity);
        }
    }
}
