using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace ApplicantTracking.Api.Controllers
{
    [ApiController]
    public sealed class CandidateController : ControllerBase
    {
        [HttpGet("candidates")]
        public async Task<IActionResult> List()
        {
            // TODO: Implement this method
            return Ok();
        }

        [HttpGet("candidates/{idCandidate:int}")]
        public async Task<IActionResult> Get([FromRoute] int idCandidate)
        {
            // TODO: Implement this method
            return Ok();
        }

        // TODO: Change 'object candidate' to your viewmodel
        [HttpPost("candidates")]
        public async Task<IActionResult> Create([FromBody] object candidate)
        {
            // TODO: Implement this method
            return Ok();
        }

        // TODO: Change 'object candidate' to your viewmodel
        [HttpGet("candidates/{idCandidate:int}")]
        public async Task<IActionResult> Edit([FromRoute] int idCandidate, [FromBody] object candidate)
        {
            // TODO: Implement this method
            return NoContent();
        }

        [HttpDelete("candidates/{idCandidate:int}")]
        public async Task<IActionResult> Delete([FromRoute] int idCandidate)
        {
            // TODO: Implement this method
            return NoContent();
        }
    }
}
