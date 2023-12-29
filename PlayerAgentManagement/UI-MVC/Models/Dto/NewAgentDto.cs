using PlayerAgentManagement.BL.Domain;

namespace PlayerAgentManagement.UI.Web.MVC.Models.Dto;
using System.ComponentModel.DataAnnotations;

public class NewAgentDto
{
    [Required]
    [MaxLength(50)]
    public string Name { get; set; }

    [Required]
    [DataType(DataType.Date)]
    public DateTime BirthDate { get; set; }

    [MaxLength(20)] 
    public string? PhoneNumber { get; set; }
}