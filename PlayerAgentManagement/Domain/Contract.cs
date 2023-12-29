using System.ComponentModel.DataAnnotations;

namespace PlayerAgentManagement.BL.Domain;

public class Contract
{
    [Required]
    public Player Player { get; set; }
    [Required]
    public Team Team { get; set; }
    
    public DateTime StartDate { get; set; }
    public DateTime EndDate { get; set; }
    
    public int Id { get; set; }
}