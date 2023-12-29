using Microsoft.AspNetCore.Mvc;
using PlayerAgentManagement.BL;
using PlayerAgentManagement.BL.Domain;
using PlayerAgentManagement.UI.Web.MVC.Models.Dto;

namespace PlayerAgentManagement.UI.Web.MVC.Controllers.Api;

[ApiController]
[Route("api/[controller]")]
public class TeamsController : ControllerBase
{
    private readonly IManager _manager;
    
    public TeamsController(IManager manager)
    {
        _manager = manager;
    }

    [HttpGet]
    public IActionResult GetAllTeams()
    {
        var teams = _manager.GetAllTeamsWithContracts();
        if (!teams.Any())
        {
            return NoContent();
        }

        return Ok(teams.Select(team => new TeamDto()
        {
            Id = team.Id,
            Name = team.Name,
            Country = team.Country,
            Founded = team.Founded
        }));
    }
    
    [HttpGet("{id}")]
        public ActionResult<ContractDto> GetContract(int id)
        {
            var contract = _manager.GetContract(id);
            if (contract == null)
            {
                return NotFound();
            }

            return Ok(new ContractDto
            {
                Id = contract.Id,
                StartDate = contract.StartDate,
                EndDate = contract.EndDate,
                PlayerName = contract.Player.Name,
                TeamName = contract.Team.Name
            });
        }

    [HttpPost("addContract")]
    public ActionResult<ContractDto> AddContract(NewContractDto contractDto)
    {
        var createdContract = _manager.CreatePlayerTeamContract(contractDto.PlayerId, contractDto.TeamId,
            contractDto.StartDate, contractDto.EndDate);
        return CreatedAtAction("GetContract", new { id = createdContract.Id }, new ContractDto
        {
            StartDate = createdContract.StartDate,
            EndDate = createdContract.EndDate,
            PlayerName = createdContract.Player.Name,
            TeamName = createdContract.Team.Name
        });
    }

    [HttpGet("{id}/contracts")]
    public IActionResult GetPlayersOfTeams(int id)
    {
        var team = _manager.GetTeamWithContracts(id);
        if (team == null)
        {
            return NotFound();
        }

        return Ok(team.Contracts.Select(contract => new NewPlayerDto()
        {
            Name = contract.Player.Name,
            Position = contract.Player.Position,
            BirthDate = contract.Player.BirthDate,
            Salary = contract.Player.Salary
        }));

    }

    [HttpGet("{id}")]
    public IActionResult GetTeam(int id)
    {
        var team = _manager.GetTeamWithContracts(id);
        if (team == null)
        {
            return NotFound();
        }

        return Ok(new TeamDto()
        {
            Id = team.Id,
            Name = team.Name,
            Country = team.Country,
            Founded = team.Founded
        });
    }
    
    
}