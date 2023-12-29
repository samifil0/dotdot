using System.ComponentModel.DataAnnotations;
using PlayerAgentManagement.BL.Domain;

namespace PlayerAgentManagement.UI.Web.MVC.Models;

public class NewPlayerViewModel
{
    [MinLength(2)]
    public string Name { get; set; }
    [DataType(DataType.Date)]
    public DateTime BirthDate { get; set; }
    [EnumDataType(typeof(Position))]
    public Position Position { get; set; }
    
    [Range(0, double.MaxValue)]
    public double Salary { get; set; }
    public int Id { get; set; }
}