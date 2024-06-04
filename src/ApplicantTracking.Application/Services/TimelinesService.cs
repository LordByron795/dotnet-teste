using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ApplicantTracking.Application.DTOs;
using ApplicantTracking.Application.Interfaces;
using ApplicantTracking.Domain.Entities;
using ApplicantTracking.Domain.Enumerators;
using ApplicantTracking.Domain.Interfaces;

namespace ApplicantTracking.Application.Services
{
    public class TimelinesService : ITimelinesService
    {
        private readonly ICandidatesRepository _candidatesRepository;
        private readonly ITimelinesRepository _timelinesRepository;

        public TimelinesService(ICandidatesRepository candidatesRepository, ITimelinesRepository timelinesRepository)
        {
            _candidatesRepository = candidatesRepository;
            _timelinesRepository = timelinesRepository;
        }

        public async Task<Timelines> Add(TimelinesRequestDto timelines)
        {

            Timelines timelinesEntity = new( (int)TimelineTypes.Create, timelines.idAggregateRoot,null, null, DateTime.Now);
            
            await _timelinesRepository.Add(timelinesEntity);
            
            return timelinesEntity;
        }

        public async Task<IEnumerable<Timelines>> GetAll()
        {
            IEnumerable<Timelines> timelines = await _timelinesRepository.GetAll();
            return timelines.OrderBy(timelines => timelines.IdAggregateRoot);
        }

        public async Task<IEnumerable<Timelines>> GetByIdAggregateRoot(int idAggregateRoot)
        {
            IEnumerable<Timelines> timelines = await _timelinesRepository.GetAll(x => x.IdAggregateRoot == idAggregateRoot);
            if (!timelines.Any())
            {
                throw new Exception("There are no Timelines for this candidate.");
            }

            return timelines;
        }

        public async Task<Timelines> GetById(int id)
        {
            var book = await _timelinesRepository.GetById(id);
            return book ?? throw new Exception("Timeline not found");
        }

        public async Task Remove(int id)
        {
            await _timelinesRepository.Delete(await GetById(id));
        }

        public async Task Update(Timelines timelines)
        {
            _ = GetById(timelines.Id).Result;

            await _timelinesRepository.Update(timelines);
        }

       
    }
}
