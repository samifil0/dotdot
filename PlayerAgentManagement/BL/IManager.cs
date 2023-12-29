using PlayerAgentManagement.BL.Domain;

namespace PlayerAgentManagement.BL;

public interface IManager
{
    public Player GetPlayer(int id);
    public Player GetPlayerWithAgent(int id);
    public Team GetTeam(int id);
    public Agent GetAgent(int id);
    public Contract GetContract(int id);
    public Agent GetAgentWithPlayers(int id);
    public Player GetPlayerWithContracts(int id);
    public Team GetTeamWithContracts(int id);
    public IEnumerable<Agent> GetAllAgentsWithPlayers();
    public IEnumerable<Player> GetAllPlayers();
    public IEnumerable<Player> GetPlayersFromTeam(int teamId);
    public IEnumerable<Player> GetAllPlayersNotFromTeam(int teamId);
    public IEnumerable<Position> GetAllPositions();
    public IEnumerable<Player> GetAllPlayersWithContracts();
    public IEnumerable<Player> GetAllPlayersWithAgents();
    public IEnumerable<Team> GetAllTeams();
    public IEnumerable<string> GetAllCountriesOfTeams();
    public IEnumerable<Team> GetAllTeamsWithContracts();
    public IEnumerable<Agent> GetAllAgents();
    
    public Team AddTeam(string name, DateTime founded, string country);
    public Player AddPlayer(string name, DateTime birthDate, Position position, double salary);
    public Agent AddAgent(string name, DateTime birthDate, string phoneNumber);
    
    public IEnumerable<Player> GetPlayerOfPosition(Position position);
    public IEnumerable<Player> GetAllPlayersByNameAndBirth(string name, DateTime? birth);
    public IEnumerable<Team> GetTeamOfCountry(string country);
    Task<IEnumerable<Agent>> GetAllAgentsAsync();
    Task<Agent> GetAgentAsync(int id);
    Task<Agent> AddAgentAsync(string name, DateTime birthDate, string phoneNumber);
    public void DeletePlayerFromTeam(int playerId, int teamId);
    public void DeletePlayerFromAgent(int playerId, int agentId);
    public Contract CreatePlayerTeamContract(int playerId, int teamId, DateTime startDate, DateTime endDate);
}