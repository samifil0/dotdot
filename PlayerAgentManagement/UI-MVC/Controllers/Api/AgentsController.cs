using Microsoft.AspNetCore.Mvc;
using PlayerAgentManagement.BL;
using PlayerAgentManagement.UI.Web.MVC.Models.Dto;

namespace PlayerAgentManagement.UI.Web.MVC.Controllers.Api;

[ApiController]
[Route("api/[controller]")]
public class AgentsController : ControllerBase
{
    private readonly IManager _manager;
    
    public AgentsController(IManager manager)
    {
        _manager = manager;
    }
    
    [HttpGet]
    public async Task<IActionResult> GetAllAgents()
    {
        var agents = await _manager.GetAllAgentsAsync();
        if (!agents.Any())
        {
            return NoContent();
        }

        var agentDtos = agents.Select(a => AgentDto.FromAgent(a));
        return Ok(agentDtos);
    }
    
    [HttpGet("{id}")]
    public async Task<IActionResult> GetAgent(int id)
    {
        var agent = await _manager.GetAgentAsync(id);
        if (agent == null)
        {
            return NotFound();
        }

        return Ok(AgentDto.FromAgent(agent));
    }

    [HttpPost]
    public async Task<ActionResult> AddAgent([FromBody] NewAgentDto agentDto)
    {
        if (!ModelState.IsValid)
        {
            return BadRequest(ModelState);
        }

        var agent = await _manager.AddAgentAsync(agentDto.Name, agentDto.BirthDate, agentDto.PhoneNumber);
        return CreatedAtAction(nameof(GetAgent), new { id = agent.Id }, AgentDto.FromAgent(agent));
    }
}