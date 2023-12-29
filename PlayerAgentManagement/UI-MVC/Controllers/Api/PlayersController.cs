using Microsoft.AspNetCore.Mvc;
using PlayerAgentManagement.BL;
using PlayerAgentManagement.UI.Web.MVC.Models.Dto;

namespace PlayerAgentManagement.UI.Web.MVC.Controllers.Api;

[ApiController]
[Route("api/[controller]")]
public class PlayersController : ControllerBase
{
    private readonly IManager _manager;
    private readonly ILogger<PlayersController> _logger;

    public PlayersController(IManager manager, ILogger<PlayersController> logger)
    {
        _manager = manager;
        _logger = logger;
    }



    [HttpGet("{id}")]
    public IActionResult GetPlayer(int id)
    {
        var player = _manager.GetPlayer(id);
        if (player == null)
        {
            return NotFound();
        }

        return Ok(new PlayerDto
        {
            Name = player.Name,
            BirthDate = player.BirthDate,
            Position = player.Position,
            Salary = player.Salary,
            AgentName = player.Agent.Name
        });
    }
    
    [HttpPost]
    public IActionResult AddPlayer([FromBody] NewPlayerDto playerDto)
    {
        if (!ModelState.IsValid)
        {
            return BadRequest(ModelState);
        }
        
        var player = _manager.AddPlayer(playerDto.Name, playerDto.BirthDate, playerDto.Position, playerDto.Salary);
        return CreatedAtAction(nameof(GetPlayer), new { id = player.Id }, new PlayerDto
        {
            Name = player.Name,
            BirthDate = player.BirthDate,
            Position = player.Position,
            Salary = player.Salary,
            AgentName = player.Agent.Name
        });
    }
    
    [HttpGet("allPlayers")]
    public IActionResult GetAllPlayers()
    {
        var players = _manager.GetAllPlayers();
        if (!ModelState.IsValid)
        {
            return BadRequest(ModelState);
        }
        
        return Ok(players.Select(player => new PlayerDto
        {
            Id = player.Id,
            Name = player.Name,
            BirthDate = player.BirthDate,
            Position = player.Position,
            Salary = player.Salary,
            AgentName = player.Agent.Name
        }));
    }
}