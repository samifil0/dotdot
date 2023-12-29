using PlayerAgentManagement.BL.Domain;

namespace PlayerAgentManagement.UI_CA.Extensions;

public static class TeamExtensions
{
    public static string GetStringRepresentation(this Team team)
    {
        return $"Name: {team.Name}\t" +
               $"Founded in: {team.Founded:yyyy-MM-dd}\t" +
               $"Country: {team.Country}\t" + 
               $"Contracts: {string.Join(", ", team.Contracts.Select(c => $"Player: {c.Player.Name}, Start Date: {c.StartDate}, End Date: {c.EndDate}"))}\t";

    }
}