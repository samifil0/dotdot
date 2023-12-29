using PlayerAgentManagement.BL.Domain;

namespace PlayerAgentManagement.UI.Web.MVC.Models.Dto;

public class NewContractDto
{
    
    
    public int PlayerId { get; set; }
    public int TeamId { get; set; }
    public DateTime StartDate { get; set; }
    public DateTime EndDate { get; set; }
    
    
}