using PlayerAgentManagement.BL.Domain;

namespace PlayerAgentManagement.DAL;


public interface IRepository    
{
    public Player ReadPlayer(int id);
    public Player ReadPlayerWithAgent(int id);
    public Team ReadTeam(int id);
    public Agent ReadAgent(int id);
    public Contract ReadContract(int id);
    public Agent ReadAgentWithPlayers(int id);
    public IEnumerable<Player> ReadAllPlayers();
    public IEnumerable<Player> ReadAllPlayersNotFromTeam(int teamId);
    public IEnumerable<Player> ReadPlayersFromTeam(int teamId);
    public IEnumerable<Position> ReadAllPositions();
    public IEnumerable<Player> ReadAllPlayersWithContracts();
    public IEnumerable<Player> ReadAllPlayersWithAgents();
    public IEnumerable<Team> ReadAllTeams();
    public IEnumerable<string> ReadAllCountriesOfTeams();
    public IEnumerable<Team> ReadAllTeamsWithContracts();
    public IEnumerable<Agent> ReadAllAgents();
    public Player ReadPlayerWithContracts(int id);
    public Team ReadTeamWithContracts(int id);
    public IEnumerable<Agent> ReadAllAgentsWithPlayers();
    
    public void DeletePlayerFromTeam(int playerId, int teamId);
    public void DeletePlayerFromAgent(int playerId, int agentId);
    public void CreatePlayerTeamContract(Contract contract);
    
    
    public void CreateTeam(Team team);
    public void CreatePlayer(Player player);
    public void CreateAgent(Agent agent);
    
    public IEnumerable<Player> ReadPlayerOfPosition(Position position);
    public IEnumerable<Player> ReadAllPlayersByNameAndBirth(string name, DateTime? birth);
    public IEnumerable<Team> ReadTeamOfCountry(string country);
    
    Task<IEnumerable<Agent>> ReadAllAgentsAsync();
    Task<Agent> ReadAgentAsync(int id);
    Task AddAgentAsync(Agent agent);
}