using CandidateApi.Dtos;
using CandidateApi.Models;
using CandidateApi.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace CandidateApi.Controllers
{
    [ApiController]
    [Route("api/[controller]s")]
    public class CandidateController : ControllerBase
    {
        private readonly ICandidateService _candidateService;
        public CandidateController(ICandidateService candidateService)
        {
            _candidateService = candidateService;
        }
        

       
        [Authorize]
        [HttpPost]
        public IActionResult UpsertCandidate([FromBody] CandidateDto candidateDto)
        {
            
            Candidate result = _candidateService.UpsertCandidate(candidateDto);

            bool wasNew = result.CreatedAt == result.UpdatedAt;
            if (wasNew)
            {
                return CreatedAtAction(
                    nameof(UpsertCandidate), 
                    new { email = result.Email }, 
                    result);
            }
            else
            {
                return Ok(result);
            }
        }
    }
}
