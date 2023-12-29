

using Microsoft.EntityFrameworkCore;
using PlayerAgentManagement.BL.Domain;
using PlayerAgentManagement.DAL.EF;

namespace PlayerAgentManagement.DAL;

public class InMemoryRepository : IRepository
{

    private readonly List<Player> _players;
    private readonly List<Team> _teams;
    private readonly List<Agent> _agents;

    public InMemoryRepository()
    {
        _players = new List<Player>();
        _teams = new List<Team>();
        _agents = new List<Agent>();
        Seed();
    }

    private void Seed()
    {
    }

    public void CreateTeam(Team team)
    {
        team.Id = _teams.Count + 1;
        _teams.Add(team);
    }

    public void CreatePlayer(Player player)
    {
        player.Id = _players.Count + 1;
        _players.Add(player);
    }
    
    public void CreateAgent(Agent agent)
    {
        agent.Id = _agents.Count + 1;
        _agents.Add(agent);
    }

    public Player ReadPlayer(int id)
    {
        return _players.First(player => player.Id == id);
    }
    
    public Player ReadPlayerWithAgent(int id)
    {
        throw new NotImplementedException();
    }

    public Team ReadTeam(int id)
    {
        return _teams.First(team => team.Id == id);
    }
    
    public Agent ReadAgent(int id)
    {
        return _agents.First(agent => agent.Id == id);
    }
    
    public Contract ReadContract(int id)
    {
        throw new NotImplementedException();
    }
    
    public Agent ReadAgentWithPlayers(int id)
    {
        throw new NotImplementedException();
    }
    
    public Player ReadPlayerWithContracts(int id)
    {
        throw new NotImplementedException();
    }
    
    public Team ReadTeamWithContracts(int id)
    {
        throw new NotImplementedException();
    }
    
    public IEnumerable<Agent> ReadAllAgentsWithPlayers()
    {
        throw new NotImplementedException();
    }

    public IEnumerable<Player> ReadAllPlayers()
    {
        return _players;
    }
    
    public IEnumerable<Player> ReadPlayersFromTeam(int teamId)
    {
        throw new NotImplementedException();
    }
    
    public IEnumerable<Player> ReadAllPlayersNotFromTeam(int teamId)
    {
        throw new NotImplementedException();
    }
    
    public IEnumerable<Position> ReadAllPositions()
    {
        throw new NotImplementedException();
    }
    
    public IEnumerable<Player> ReadAllPlayersWithAgents()
    {
        throw new NotImplementedException();
    }
    
    public IEnumerable<Player> ReadAllPlayersWithContracts()
    {
        throw new NotImplementedException();
    }

    public IEnumerable<Team> ReadAllTeams()
    {
        return _teams;
    }
    
    public IEnumerable<string> ReadAllCountriesOfTeams()
    {
        throw new NotImplementedException();
    }
    
    public IEnumerable<Team> ReadAllTeamsWithContracts()
    {
        throw new NotImplementedException();
    }
    
    public IEnumerable<Agent> ReadAllAgents()
    {
        return _agents;
    }

    public IEnumerable<Player> ReadPlayerOfPosition(Position position)
    {
        return _players.Where(player => player.Position == position);
    }

    public IEnumerable<Player> ReadAllPlayersByNameAndBirth(string name, DateTime? birth)
    {
        return _players.Where(player => player.Name.Equals(name) && player.BirthDate.Equals(birth));
    }

    public IEnumerable<Team> ReadTeamOfCountry(string country)
    {
        return _teams.Where(team => team.Country.Equals(country));
    }
    
    public void DeletePlayerFromTeam(int playerId, int teamId)
    {
       throw new NotImplementedException();
    }
    
    public void DeletePlayerFromAgent(int playerId, int agentId)
    {
        throw new NotImplementedException();
    }
    
    public void CreatePlayerTeamContract(Contract contract)
    {
        throw new NotImplementedException();
    }
    
    public async Task<IEnumerable<Agent>> ReadAllAgentsAsync()
    {
        throw new NotImplementedException();
    }
    
    public async Task<Agent> ReadAgentAsync(int id)
    {
        throw new NotImplementedException();
    }
    
    public async Task AddAgentAsync(Agent agent)
    {
        throw new NotImplementedException();
    }
    
}
