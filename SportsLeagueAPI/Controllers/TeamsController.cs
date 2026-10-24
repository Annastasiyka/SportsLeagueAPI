using Microsoft.AspNetCore.Mvc;
using SportsLeagueAPI.Models;
using SportsLeagueAPI.Repositories;

namespace SportsLeagueAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TeamsController : ControllerBase
    {
        private readonly ITeamRepository _repository;

        // Контролер нічого не знає про AppDbContext, він працює лише через репозиторій
        public TeamsController(ITeamRepository repository)
        {
            _repository = repository;
        }

        // GET: api/Teams
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Team>>> GetTeams()
        {
            var teams = await _repository.GetAllAsync();
            return Ok(teams);
        }

        // GET: api/Teams/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Team>> GetTeam(int id)
        {
            var team = await _repository.GetByIdAsync(id);
            if (team == null) return NotFound();
            return Ok(team);
        }

        // POST: api/Teams
        [HttpPost]
        public async Task<ActionResult<Team>> PostTeam(Team team)
        {
            var createdTeam = await _repository.AddAsync(team);
            return CreatedAtAction(nameof(GetTeam), new { id = createdTeam.Id }, createdTeam);
        }

        // PUT: api/Teams/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutTeam(int id, Team team)
        {
            if (id != team.Id) return BadRequest();
            await _repository.UpdateAsync(team);
            return NoContent();
        }

        // DELETE: api/Teams/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteTeam(int id)
        {
            await _repository.DeleteAsync(id);
            return NoContent();
        }
    }
}