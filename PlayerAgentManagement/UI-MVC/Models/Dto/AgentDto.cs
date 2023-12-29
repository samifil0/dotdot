using System.ComponentModel.DataAnnotations;
using PlayerAgentManagement.BL.Domain;

namespace PlayerAgentManagement.UI.Web.MVC.Models.Dto;

public class AgentDto
{
    public int Id { get; set; }
    public string Name { get; set; }
    public DateTime BirthDate { get; set; }
    public string? PhoneNumber { get; set; }

    public static AgentDto FromAgent(Agent agent)
    {
        return new AgentDto
        {
            Id = agent.Id,
            Name = agent.Name,
            BirthDate = agent.BirthDate,
            PhoneNumber = agent.PhoneNumber
        };
    }
}
