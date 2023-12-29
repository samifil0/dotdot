using PlayerAgentManagement.BL.Domain;

namespace PlayerAgentManagement.UI_CA.Extensions;

public static class PlayerExtensions
{
    public static string GetStringRepresentation(this Player player)
    {
        var agentName = player.Agent != null ? player.Agent.Name : "No Agent";
        return $"Name: {player.Name}\t" +
               $"Birth date: {player.BirthDate:yyyy-MM-dd}\t" +
               $"Position: {player.Position}\t" +
               $"Salary: {player.Salary:F2}\t" +
               $"Agent: {agentName}\t" +
               $"Contracts: {string.Join(", ", player.Contracts.Select(c => 
                   $"Team: {c.Team.Name}, Start: {c.StartDate:yyyy-MM-dd}, End: {c.EndDate:yyyy-MM-dd}"))}\t";

    }
}