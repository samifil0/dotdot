using PlayerAgentManagement.BL.Domain;

namespace PlayerAgentManagement.UI.Web.MVC.Models.Dto;

public class NewPlayerDto
{
    
    public string Name { get; set; }
    public Position Position { get; set; }
    public DateTime BirthDate { get; set; }
    public double Salary { get; set; }
    public string AgentName { get; set; }
    
}