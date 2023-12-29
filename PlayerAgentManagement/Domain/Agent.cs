namespace PlayerAgentManagement.BL.Domain;

public class Agent
{
    public string Name { get; set; }
    public DateTime BirthDate { get; set; } 
    #nullable enable
    public string? PhoneNumber { get; set; }
    #nullable disable
    
    public int Id { get; set; }
    public ICollection<Player> Players { get; set; }
    
    
    
}