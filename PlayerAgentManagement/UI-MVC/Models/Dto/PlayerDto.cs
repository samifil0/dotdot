using PlayerAgentManagement.BL.Domain;

namespace PlayerAgentManagement.UI.Web.MVC.Models.Dto;

public class PlayerDto
{
    public string Name { get; set; }
    public Position Position { get; set; }
    public DateTime BirthDate { get; set; }
    public double Salary { get; set; }
    public string AgentName { get; set; }
    public int Id { get; set; }
    
    
}