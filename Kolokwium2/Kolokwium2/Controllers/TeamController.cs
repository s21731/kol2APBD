using Kolokwium2.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace Kolokwium2.Controllers
{
    [Route("teams")]
    [ApiController]
    public class TeamController : ControllerBase
    {
        private readonly ITeamDbService _teamDbService;
        
        public TeamController(ITeamDbService teamDbService)
        {
            _teamDbService = teamDbService;
        }

        [HttpGet("{idTeam}")]
        public async Task<IActionResult> GetTeam(int idTeam)
        {

            return Ok(await _teamDbService.GetTeam(idTeam));

        }

    }
}
