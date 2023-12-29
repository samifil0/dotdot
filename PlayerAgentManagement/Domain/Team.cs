using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PlayerAgentManagement.BL.Domain;

public class Team
{
    [MinLength(2)]
    public string Name { get; set; }
    [DataType(DataType.Date)]
    public DateTime Founded { get; set; }
    [StringLength(30, MinimumLength = 3)]
    public string Country { get; set; }
    public ICollection<Player> Players { get; set; }
    [Range(1, int.MaxValue)]
    public int Id { get; set; }
    
    public ICollection<Contract> Contracts { get; set; }
}