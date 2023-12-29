using System.ComponentModel.DataAnnotations;
using System.Globalization;
using PlayerAgentManagement.BL;
using PlayerAgentManagement.BL.Domain;
using PlayerAgentManagement.UI_CA.Extensions;

namespace PlayerAgentManagement.UI_CA;

class ConsoleUi
{
    private bool _continueRunning = true;
    private readonly IManager _imanager;
    public ConsoleUi(IManager imanager)
    {
        _imanager = imanager;
    }
    public void Run()
    {
        while (_continueRunning)
        {
            Console.WriteLine("\nWhat would you like to do?");
            Console.WriteLine("====================");
            Console.WriteLine("0) Quit");
            Console.WriteLine("1) Show all players");
            Console.WriteLine("2) Show players of position");
            Console.WriteLine("3) Show all teams");
            Console.WriteLine("4) Show players with name and/or date of birth");
            Console.WriteLine("5) Show teams of country");
            Console.WriteLine("6) Show all agents");
            Console.WriteLine("7) Add a player");
            Console.WriteLine("8) Add a team");
            Console.WriteLine("9) Add an Agent");
            Console.WriteLine("10) Delete a player from a team");
            Console.WriteLine("11) Delete a player from an agent");
            Console.WriteLine("12) Create a player-team contract");
            Console.Write("Choose (0-12): ");
            var choice = Console.ReadLine();
            if (int.TryParse(choice, out var numericChoice) && numericChoice >= 0 && numericChoice <= 12)
            {
                switch (choice)
                {
                    case "0":
                        Console.WriteLine("Bye! Until next time! :)");
                        _continueRunning = false;
                        Environment.Exit(1);
                        break;
                    case "1":
                        Console.WriteLine("\nAll players");
                        Console.WriteLine("=========");
                        foreach (var player in _imanager.GetAllPlayers())
                        {
                            Console.WriteLine(player.GetStringRepresentation());
                        }

                        break;
                    case "2":
                        Console.WriteLine("\nChoose a position:");
                        var allPositions = _imanager.GetAllPositions();

                        foreach (var position in allPositions)
                        {
                            Console.WriteLine(position);
                        }
                        Console.Write("Enter the position name: ");
                        var positionChoice = Console.ReadLine();
                        if (Enum.TryParse(positionChoice, out Position selectedPosition) && Enum.IsDefined(typeof(Position), selectedPosition))
                        {
                            var playersOfPosition = _imanager.GetPlayerOfPosition(selectedPosition);
                            foreach (var player in playersOfPosition)
                            {
                                Console.WriteLine(player.GetStringRepresentation());
                            }
                        }
                        else
                        {
                            Console.WriteLine("Invalid choice. Please enter a valid position name.");
                        }
                        break;
                    case "3":
                        Console.WriteLine("\nAll teams");
                        Console.WriteLine("=========");
                        foreach (var team in _imanager.GetAllTeams())
                        {
                            Console.WriteLine(team.GetStringRepresentation());
                        }

                        break;
                    case "4":
                        Console.Write("\nEnter (part of) a name or leave blank: ");
                        var nameTyped = Console.ReadLine();
                        Console.Write("Enter a full date (yyyy/mm/dd) or leave blank: ");
                        var dateTyped = Console.ReadLine();
                        DateTime? convertedDate = null;
                        if (!string.IsNullOrWhiteSpace(dateTyped))
                        {
                            if (!DateTime.TryParseExact(dateTyped, "yyyy/MM/dd", CultureInfo.InvariantCulture, DateTimeStyles.None, out var validDate))
                            {
                                Console.WriteLine("Invalid date format. Please use yyyy/mm/dd.");
                                break;
                            }
                            convertedDate = validDate;
                        }
                        var filteredPlayers = _imanager.GetAllPlayersByNameAndBirth(nameTyped, convertedDate);
                        var foundPlayer = false;
                        foreach (var player in filteredPlayers)
                        {
                            if (!foundPlayer)
                            {
                                foundPlayer = true;
                            }
                            Console.WriteLine(player.GetStringRepresentation());
                        }
                        if (!foundPlayer)
                        {
                            Console.WriteLine("No player was found! Check if the birth date was in the correct format and if the name was typed correctly.");
                        }
                        break;
                    case "5":
                        Console.WriteLine("\nChoose a country:");
                        var countriesTeams = _imanager.GetAllCountriesOfTeams();
                        foreach(var country in countriesTeams)
                        {
                            Console.WriteLine(country);
                        }
                        var isCountryFound = false;
                        Console.Write("Enter the country name: ");
                        var countryTyped = Console.ReadLine();
                        foreach (var country in countriesTeams)
                        {
                            if (!isCountryFound && country.Equals(countryTyped, StringComparison.OrdinalIgnoreCase))
                            {
                                isCountryFound = true;
                            }
                        }
                        if (isCountryFound)
                        {
                            var teamsOfCountry = _imanager.GetTeamOfCountry(countryTyped);
                            foreach (var team in teamsOfCountry)
                            {
                                Console.WriteLine(team.GetStringRepresentation());
                            }
                        }
                        else
                        {
                            Console.WriteLine("Invalid choice. Please enter a valid country name.");
                        }
                        break;

                    case "6":
                        Console.WriteLine("\nAll Agents");
                        Console.WriteLine("=========");
                        foreach (var agent in _imanager.GetAllAgents())
                        {
                            Console.WriteLine(agent.GetStringRepresentation());
                        }

                        break;
                    case "7":
                        bool valid;
                        do
                        {
                            try
                            { 
                                Console.Write("\nName: ");
                                var name = Console.ReadLine();
                                Console.Write("\nBirthdate (dd/mm/yyyy): ");
                                var birthdateString = Console.ReadLine();
                                DateTime.TryParse(birthdateString, out var date);
                                Console.Write("\nPosition (Keeper, Defender, Midfielder, Attacker): ");
                                var positionString = Console.ReadLine();
                                Enum.TryParse(positionString, out Position position);
                                Console.Write("\nSalary (f.e. 10000): ");
                                var salaryString = Console.ReadLine();
                                double.TryParse(salaryString, out var salary);
                                _imanager.AddPlayer(name, date, position, salary);
                                Console.WriteLine($"{name} has been added to the database.");
                                valid = true;
                            }
                            catch (ValidationException ve)
                            {
                                Console.Write("\nError: ");
                                Console.WriteLine(ve.ValidationResult.ErrorMessage);
                                valid = false;
                            }
                        } while (!valid);
                        break;
                    case "8":
                        bool valid2;
                        do
                        {
                            try
                            {
                                Console.Write("\nName: ");
                                var name = Console.ReadLine();
                                Console.Write("\nDate founded (dd/mm/yyyy): ");
                                var foundedString = Console.ReadLine();
                                DateTime.TryParse(foundedString, out var founded);
                                Console.Write("\nCountry: ");
                                var countryString = Console.ReadLine();
                                _imanager.AddTeam(name, founded, countryString);
                                Console.WriteLine($"{name} has been added to the database.");
                                valid2 = true;
                            }
                            catch (ValidationException ve)
                            {
                                Console.Write("\nError: ");
                                Console.WriteLine(ve.ValidationResult.ErrorMessage);
                                valid2 = false;
                            }
                        } while (!valid2);
                        break;
                    case "9":
                        bool valid3;
                        do
                        {
                            try
                            {
                                Console.WriteLine("\nName: ");
                                var name = Console.ReadLine();
                                Console.WriteLine("\nBirthdate (dd/mm/yyyy): ");
                                var birthdateString = Console.ReadLine();
                                DateTime.TryParse(birthdateString, out var birthdate);
                                Console.WriteLine("\nPhone number: ");
                                var phoneNumber = Console.ReadLine();
                                _imanager.AddAgent(name, birthdate, phoneNumber);
                                Console.WriteLine($"{name} has been added to the database.");
                                valid3 = true;
                            }
                            catch (ValidationException ve)
                            {
                                Console.Write("\nError: ");
                                Console.WriteLine(ve.ValidationResult.ErrorMessage);
                                valid3 = false;
                            }
                        } while (!valid3);

                        break;
                    case "10":
                        var players = _imanager.GetAllPlayers();
                        foreach (var player in players)
                        {
                            var teams = string.Join(", ", player.Contracts.Select(c => $"{c.Team.Name} (ID: {c.Team.Id})"));
                            Console.WriteLine($"Player ID: {player.Id}, Name: {player.Name}, Teams: {teams}");
                        }
                        Console.Write("Enter the Player ID to remove from their team: ");
                        if (int.TryParse(Console.ReadLine(), out var playerId))
                        {
                            var selectedPlayer = _imanager.GetPlayer(playerId);
                            if (selectedPlayer != null)
                            {
                                Console.WriteLine($"Selected Player: {selectedPlayer.Name}");
                                Console.WriteLine("Teams associated with the player:");
                                foreach (var contract in selectedPlayer.Contracts)
                                {
                                    Console.WriteLine($"Team ID: {contract.Team.Id}, Name: {contract.Team.Name}");
                                }
                                Console.Write("Enter the Team ID to remove the player from: ");
                                if (int.TryParse(Console.ReadLine(), out var teamId))
                                {
                                    _imanager.DeletePlayerFromTeam(playerId, teamId);
                                    Console.WriteLine($"Player {selectedPlayer.Name} has been removed from the team.");
                                }
                                else
                                {
                                    Console.WriteLine("Invalid Team ID.");
                                }
                            }
                            else
                            {
                                Console.WriteLine("Player not found.");
                            }
                        }
                        else
                        {
                            Console.WriteLine("Invalid Player ID.");
                        }
                        break;
                    case "11":
                        var agents = _imanager.GetAllAgentsWithPlayers();
                        foreach (var agent in agents)
                        {
                            var s = string.Join(", ", agent.Players.Select(p => $"{p.Name} (ID: {p.Id})"));
                            Console.WriteLine($"Agent ID: {agent.Id}, Name: {agent.Name}, Players: {s}");
                        }
                        Console.Write("Enter the Agent ID: ");
                        if (int.TryParse(Console.ReadLine(), out var agentId))
                        {
                            var selectedAgent = _imanager.GetAgent(agentId);
                            if (selectedAgent != null)
                            {
                                Console.WriteLine($"Selected Agent: {selectedAgent.Name}");
                                Console.WriteLine("Players managed by the agent:");

                                foreach (var player in selectedAgent.Players)
                                {
                                    Console.WriteLine($"Player ID: {player.Id}, Name: {player.Name}");
                                }
                                Console.Write("Enter the Player ID to remove from this agent's list: ");
                                if (int.TryParse(Console.ReadLine(), out int result))
                                {
                                    _imanager.DeletePlayerFromAgent(result, agentId);
                                    Console.WriteLine($"Player has been removed from {selectedAgent.Name}'s list.");
                                }
                                else
                                {
                                    Console.WriteLine("Invalid Player ID.");
                                }
                            }
                            else
                            {
                                Console.WriteLine("Agent not found.");
                            }
                        }
                        else
                        {
                            Console.WriteLine("Invalid Agent ID.");
                        }
                        break;
case "12":
    var playersForContract = _imanager.GetAllPlayers();
    foreach (var player in playersForContract)
    {
        Console.WriteLine($"Player ID: {player.Id}, Name: {player.Name}");
    }
    Console.Write("Enter the Player ID for the contract: ");
    if (int.TryParse(Console.ReadLine(), out var id))
    {
        var selectedPlayer = _imanager.GetPlayer(id);
        if (selectedPlayer != null)
        {
            Console.WriteLine($"Selected Player: {selectedPlayer.Name}");
            var teamsForContract = _imanager.GetAllTeams();
            foreach (var team in teamsForContract)
            {
                Console.WriteLine($"Team ID: {team.Id}, Name: {team.Name}");
            }
            Console.WriteLine("\nChoose a team for the contract:");
            var teams = _imanager.GetAllTeams();
            foreach (var team in teams)
            {
                Console.WriteLine($"Team ID: {team.Id}, Name: {team.Name}");
            }
            Console.Write("Enter the Team ID for the contract: ");
            if (int.TryParse(Console.ReadLine(), out var teamId))
            {
                Console.Write("Enter contract start date (yyyy/mm/dd): ");
                if (DateTime.TryParseExact(Console.ReadLine(), "yyyy/MM/dd", CultureInfo.InvariantCulture, DateTimeStyles.None, out var startDate))
                {
                    Console.Write("Enter contract end date (yyyy/mm/dd): ");
                    if (DateTime.TryParseExact(Console.ReadLine(), "yyyy/MM/dd", CultureInfo.InvariantCulture, DateTimeStyles.None, out var endDate))
                    {
                        _imanager.CreatePlayerTeamContract(id, teamId, startDate, endDate);
                        Console.WriteLine($"Contract created for {selectedPlayer.Name} with team ID {teamId} from {startDate:yyyy-MM-dd} to {endDate:yyyy-MM-dd}.");
                    }
                    else
                    {
                        Console.WriteLine("Invalid end date format. Please use yyyy/mm/dd.");
                    }
                }
                else
                {
                    Console.WriteLine("Invalid start date format. Please use yyyy/mm/dd.");
                }
            }
            else
            {
                Console.WriteLine("Invalid Team ID.");
            }
        }
        else
        {
            Console.WriteLine("Player not found.");
        }
    }
    else
    {
        Console.WriteLine("Invalid Player ID.");
    }
    break;
                }
                Thread.Sleep(1000);
            }
            else
            {
                Console.WriteLine("Invalid choice. Please choose a number between 0 and 12.");
                Thread.Sleep(1000);
            }
        }
    }
}