using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PlayerAgentManagement.BL.Domain;

public class Player : IValidatableObject
{
    [MinLength(2)]
    public string Name { get; set; }
    [DataType(DataType.Date)]
    public DateTime BirthDate { get; set; }
    [EnumDataType(typeof(Position))]
    public Position Position { get; set; }

    [Range(0, double.MaxValue)]
    public double Salary { get; set; }
    public ICollection<Team> Teams { get; set; }
    /*
    [Range(1, int.MaxValue)]
    */
    public int Id { get; set; }

    public ICollection<Contract> Contracts { get; set; }
    
    public Agent Agent { get; set; }
    


    public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
    {
        List<ValidationResult> results = new List<ValidationResult>();

        if (BirthDate > DateTime.Now)
        {
            results.Add(new ValidationResult("Birth date cannot be in the future.", new[] { "BirthDate" }));
        }

        if (!(Position.Equals(Position.Keeper) || Position.Equals(Position.Defender) ||
              Position.Equals(Position.Midfielder) || Position.Equals(Position.Attacker)))
        {
            results.Add(new ValidationResult("Position has to be Keeper, Defender, Midfielder or Attacker.",
                new [] { "Position" }));
        }

        return results;
    }


}