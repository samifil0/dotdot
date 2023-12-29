using PlayerAgentManagement.BL.Domain;

namespace PlayerAgentManagement.UI_CA.Extensions;

public static class AgentExtensions
{
    public static string GetStringRepresentation(this Agent agent)
    {
        var playersInfo = agent.Players != null 
            ? string.Join(", ", agent.Players.Select(p => p.Name))
            : "No players";
        return $"Name: {agent.Name} " +
               $"Birth date: {agent.BirthDate:yyyy-MM-dd} " +
               $"Phone number: {agent.PhoneNumber} " +
               $"Players: {playersInfo}";
    }
}