using Microsoft.EntityFrameworkCore;
using PlayerAgentManagement.BL.Domain;

namespace PlayerAgentManagement.DAL.EF;

public class Repository : IRepository
{
    private readonly PlayerAgentDbContext _context;

    public Repository(PlayerAgentDbContext context)
    {
        _context = context;
    }

    public void CreateTeam(Team team)
    {
        _context.Teams.Add(team);
        _context.SaveChanges();
    }

    public void CreatePlayer(Player player)
    {
        _context.Players.Add(player);
        _context.SaveChanges();
    }
    
    public void CreateAgent(Agent agent)
    {
        _context.Agents.Add(agent);
        _context.SaveChanges();
    }

    public Player ReadPlayer(int id)
    {
        return _context.Players.Single(player => player.Id == id);
    }
    
    public Player ReadPlayerWithAgent(int id)
    {
        return _context.Players.Include(player => player.Agent).Single(player => player.Id == id);
    }
    
    public Player ReadPlayerWithContracts(int id)
    {
        return _context.Players.Include(player => player.Contracts).ThenInclude(contract => contract.Team).Single(player => player.Id == id);
    }

    public Team ReadTeam(int id)
    {
        return _context.Teams.Single(team => team.Id == id);
    }
    
    public Contract ReadContract(int id)
    {
        return _context.Contracts.Include(contract => contract.Player).Include(contract => contract.Team).Single(contract => contract.Id == id);
    }
    
    public Team ReadTeamWithContracts(int id)
    {
        return _context.Teams.Include(team => team.Contracts).ThenInclude(contract => contract.Player).Single(team => team.Id == id);
    }
    
    public Agent ReadAgent(int id)
    {
        return _context.Agents.Single(agent => agent.Id == id);
    }
    
    public Agent ReadAgentWithPlayers(int id)
    {
        return _context.Agents.Include(agent => agent.Players).Single(agent => agent.Id == id);
    }

    public IEnumerable<Player> ReadAllPlayers()
    {
        return _context.Players.Include(p => p.Agent).Include(p => p.Contracts).ThenInclude(c => c.Team);
    }
    
    public IEnumerable<Player> ReadPlayersFromTeam(int teamId)
    {
        return _context.Players.Where(player => player.Contracts.Any(contract => contract.Team.Id == teamId)).Include(p => p.Agent).Include(p => p.Contracts).ThenInclude(c => c.Team);
    }
    
    public IEnumerable<Player> ReadAllPlayersNotFromTeam(int teamId)
    {
        return _context.Players.Where(player => player.Contracts.All(contract => contract.Team.Id != teamId)).Include(p => p.Agent).Include(p => p.Contracts).ThenInclude(c => c.Team);
    }
    
    public IEnumerable<Position> ReadAllPositions()
    {
        return Enum.GetValues<Position>();
    }
    
    public IEnumerable<Player> ReadAllPlayersWithContracts()
    {
        return _context.Players.Include(p => p.Contracts);
    }
    
    public IEnumerable<Player> ReadAllPlayersWithAgents()
    {
        return _context.Players.Include(p => p.Agent);
    }

    public IEnumerable<Team> ReadAllTeams()
    {
        return _context.Teams.Include(t => t.Contracts).ThenInclude(c => c.Player);
    }
    
    public IEnumerable<string> ReadAllCountriesOfTeams()
    {
        return _context.Teams.Select(team => team.Country).Distinct();
    }
    
    public IEnumerable<Team> ReadAllTeamsWithContracts()
    {
        return _context.Teams.Include(t => t.Contracts);
    }
    
    public IEnumerable<Agent> ReadAllAgents()
    {
        return _context.Agents.Include(agent => agent.Players).ToList();
    }
    
    public IEnumerable<Agent> ReadAllAgentsWithPlayers()
    {
        return _context.Agents.Include(agent => agent.Players);
    }

    public IEnumerable<Player> ReadPlayerOfPosition(Position position)
    {
        return _context.Players.Where(player => player.Position == position).Include(p => p.Agent).Include(p => p.Contracts).ThenInclude(c => c.Team);
    }

    public IEnumerable<Player> ReadAllPlayersByNameAndBirth(string name, DateTime? birth)
    {
        var asQueryable = _context.Players.AsQueryable();

        if (!string.IsNullOrEmpty(name))
        {
            asQueryable = asQueryable.Where(player => player.Name.Contains(name));
        }

        if (birth.HasValue)
        {
            asQueryable = asQueryable.Where(player => player.BirthDate == birth.Value);
        }

        return asQueryable;
    }

    public IEnumerable<Team> ReadTeamOfCountry(string country)
    {
        return _context.Teams.Where(team => team.Country == country).Include(t => t.Contracts).ThenInclude(c => c.Player);
    } 
    
    public void DeletePlayerFromTeam(int playerId, int teamId)
    {
        var player = _context.Players.Find(playerId);
        var team = _context.Teams.Find(teamId);
        var contract = _context.Contracts.FirstOrDefault(c => c.Player.Id == playerId && c.Team.Id == teamId);
        if (player != null && team != null && contract != null)
        {
            _context.Contracts.Remove(contract);
            _context.SaveChanges();
        }
    }
    
    public void DeletePlayerFromAgent(int playerId, int agentId)
    {
        var player = _context.Players.Find(playerId);
        var agent = _context.Agents.Find(agentId);
        if (player != null && agent != null)
        {
            player.Agent = null;
            _context.SaveChanges();
        }
    }
    
    public void CreatePlayerTeamContract(Contract contract)
    {
        _context.Contracts.Add(contract);
        _context.SaveChanges();
    }
    
    public async Task<IEnumerable<Agent>> ReadAllAgentsAsync()
    {
        return await _context.Agents.Include(agent => agent.Players).ToListAsync();
    }
    
    public async Task<Agent> ReadAgentAsync(int id)
    {
        return await _context.Agents.Include(agent => agent.Players).SingleAsync(agent => agent.Id == id);
    }
    
    public async Task AddAgentAsync(Agent agent)
    {
        await _context.Agents.AddAsync(agent);
        await _context.SaveChangesAsync();
    }
}