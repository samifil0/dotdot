using System.ComponentModel.DataAnnotations;
using PlayerAgentManagement.DAL;
using PlayerAgentManagement.BL.Domain;

namespace PlayerAgentManagement.BL;

public class Manager : IManager
{
    private readonly IRepository _repository;
    
    public Manager(IRepository repository)
    {
        _repository = repository;
    }

    public Player GetPlayer(int id)
    {
        return _repository.ReadPlayer(id);
    }
    
    public Player GetPlayerWithAgent(int id)
    {
        return _repository.ReadPlayerWithAgent(id);
    }

    public Team GetTeam(int id)
    {
        return _repository.ReadTeam(id);

    }
    
    public Contract GetContract(int id)
    {
        return _repository.ReadContract(id);
    }
    
    public Agent GetAgent(int id)
    {
        return _repository.ReadAgent(id);
    }
    
    public Agent GetAgentWithPlayers(int id)
    {
        return _repository.ReadAgentWithPlayers(id);
    }
    
    public Player GetPlayerWithContracts(int id)
    {
        return _repository.ReadPlayerWithContracts(id);
    }
    
    public Team GetTeamWithContracts(int id)
    {
        return _repository.ReadTeamWithContracts(id);
    }
    
    public IEnumerable<Agent> GetAllAgentsWithPlayers()
    {
        return _repository.ReadAllAgentsWithPlayers();
    }
    
    public IEnumerable<Player> GetAllPlayers()
    {
        return _repository.ReadAllPlayers();
    }
    
    public IEnumerable<Player> GetAllPlayersNotFromTeam(int teamId)
    {
        return _repository.ReadAllPlayersNotFromTeam(teamId);
    }
    
    public IEnumerable<Position> GetAllPositions()
    {
        return _repository.ReadAllPositions();
    }
    
    public IEnumerable<Player> GetAllPlayersWithContracts()
    {
        return _repository.ReadAllPlayersWithContracts();
    }
    
    public IEnumerable<Player> GetAllPlayersWithAgents()
    {
        return _repository.ReadAllPlayersWithAgents();
    }
    
    public IEnumerable<Player> GetPlayersFromTeam(int teamId)
    {
        return _repository.ReadPlayersFromTeam(teamId);
    }

    public IEnumerable<Team> GetAllTeams()
    {
        return _repository.ReadAllTeams();
    }
    
    public IEnumerable<string> GetAllCountriesOfTeams()
    {
        return _repository.ReadAllCountriesOfTeams();
    }
    
    public IEnumerable<Team> GetAllTeamsWithContracts()
    {
        return _repository.ReadAllTeamsWithContracts();
    }

    public IEnumerable<Agent> GetAllAgents()
    {
        return _repository.ReadAllAgents();
    }
    public Team AddTeam(string name, DateTime founded, string country)
    {

        var team = new Team
        {
            Name = name,
            Founded = founded,
            Country = country
        };
        var context = new ValidationContext(team);
        var results = new List<ValidationResult>();
        if (!Validator.TryValidateObject(team, context, results, validateAllProperties: true))
        {
            throw new ValidationException("Team validation failed: " +
                                          string.Join("\n", results.Select(r => r.ErrorMessage)));
        }
        _repository.CreateTeam(team);
        return team;
        
    }

    public Player AddPlayer(string name, DateTime birthDate, Position position, double salary)
    {
     
        var player = new Player
        {
            Name = name,
            BirthDate = birthDate,
            Position = position,
            Salary = salary
        };
        var context = new ValidationContext(player);
        var results = new List<ValidationResult>();
        if (!Validator.TryValidateObject(player, context, results, validateAllProperties: true))
        {
            throw new ValidationException("Player validation failed: " +
                                          string.Join("\n", results.Select(r => r.ErrorMessage)));
        }
        _repository.CreatePlayer(player);
            return player;
       
    }
    
    public Agent AddAgent(string name, DateTime birthDate, string phoneNumber)
    {
        var agent = new Agent
        {
            Name = name,
            BirthDate = birthDate,
            PhoneNumber = phoneNumber
        };
        var context = new ValidationContext(agent);
        var results = new List<ValidationResult>();
        if (!Validator.TryValidateObject(agent, context, results, validateAllProperties: true))
        {
            throw new ValidationException("Agent validation failed: " +
                                          string.Join("\n", results.Select(r => r.ErrorMessage)));
        }
        _repository.CreateAgent(agent);
        return agent;
    }
    
    public IEnumerable<Player> GetPlayerOfPosition(Position position)
    {
        return _repository.ReadPlayerOfPosition(position);
    }
    
    public IEnumerable<Player> GetAllPlayersByNameAndBirth(string name, DateTime? birth)
    {
        return _repository.ReadAllPlayersByNameAndBirth(name, birth);
    }

    public IEnumerable<Team> GetTeamOfCountry(string country)
    {
        return _repository.ReadTeamOfCountry(country);
    }
    
    public async Task<IEnumerable<Agent>> GetAllAgentsAsync()
    {
        return await _repository.ReadAllAgentsAsync();
    }

    public async Task<Agent> GetAgentAsync(int id)
    {
        return await _repository.ReadAgentAsync(id);
    }

    public async Task<Agent> AddAgentAsync(string name, DateTime birthDate, string phoneNumber)
    {
        var agent = new Agent
        {
            Name = name,
            BirthDate = birthDate,
            PhoneNumber = phoneNumber
        };

        await _repository.AddAgentAsync(agent);
        return agent;
    }
    
    public void DeletePlayerFromTeam(int playerId, int teamId)
    {
        _repository.DeletePlayerFromTeam(playerId, teamId);
    }
    
    public void DeletePlayerFromAgent(int playerId, int agentId)
    {
        _repository.DeletePlayerFromAgent(playerId, agentId);
    }
    
    public Contract CreatePlayerTeamContract(int playerId, int teamId, DateTime startDate, DateTime endDate)
    {
        var contract = new Contract
        {
            Player = _repository.ReadPlayer(playerId),
            Team = _repository.ReadTeam(teamId),
            StartDate = startDate,
            EndDate = endDate
        };
        var context = new ValidationContext(contract);
        var results = new List<ValidationResult>();
        if (!Validator.TryValidateObject(contract, context, results, validateAllProperties: true))
        {
            throw new ValidationException("Contract validation failed: " +
                                          string.Join("\n", results.Select(r => r.ErrorMessage)));
        }
        _repository.CreatePlayerTeamContract(contract);
        return contract;
    }
}