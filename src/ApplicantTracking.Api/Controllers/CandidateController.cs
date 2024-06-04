using ApplicantTracking.Application.DTOs;
using ApplicantTracking.Application.Interfaces;
using ApplicantTracking.Domain.Entities;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace ApplicantTracking.Api.Controllers
{
    [ApiController]
    public sealed class CandidateController : ControllerBase
    {
        private readonly ICandidatesService _candidateService;

        public CandidateController(ICandidatesService candidateService)
        {
            _candidateService = candidateService;
        }


        [HttpGet("candidates")]
        public async Task<IActionResult> List()
        {
            var candidates = await _candidateService.GetAll();
            return Ok(candidates);
        }

        [HttpGet("candidates/{idCandidate:int}")]
        public async Task<IActionResult> Get([FromRoute] int idCandidate)
        {
            var candidates = await _candidateService.GetById(idCandidate);
            return Ok(candidates);
        }

        // TODO: Change 'object candidate' to your viewmodel
        [HttpPost("candidates")]
        public async Task<IActionResult> Create([FromBody] CandidatesRequestDto candidate)
        {
            var candidates = await _candidateService.Add(candidate);
            return Ok(candidates);
        }

        // TODO: Change 'object candidate' to your viewmodel
        [HttpGet("candidates/{idCandidate:int}")]
        public async Task<IActionResult> Edit([FromBody] Candidates candidate)
        {
            await _candidateService.Update(candidate);
            return Ok();
        }

        [HttpDelete("candidates/{idCandidate:int}")]
        public async Task<IActionResult> Delete([FromRoute] int idCandidate)
        {
            await _candidateService.Remove(idCandidate);
            return NoContent();
        }
    }
}
