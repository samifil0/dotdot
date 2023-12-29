using PlayerAgentManagement.BL.Domain;
using PlayerAgentManagement.UI.Web.MVC.Models;
using PlayerAgentManagement.UI.Web.MVC.Models.Dto;

namespace PlayerAgentManagement.UI.Web.MVC.Controllers;
using Microsoft.AspNetCore.Mvc;
using BL;

public class PlayerController : Controller
{
    private readonly IManager _manager;
    private readonly ILogger<PlayerController> _logger;


    public PlayerController(IManager manager, ILogger<PlayerController> logger)
    {
        _manager = manager;
        _logger = logger;

    }
    [HttpGet]
    public IActionResult Index()
    {
        var players = _manager.GetAllPlayers();
        return View(players);
    }
    [HttpGet]
    public IActionResult Add()
    {
        return View();
    }

    [HttpPost]
    public IActionResult Add(NewPlayerViewModel player)
    {
        _logger.LogInformation("Add action called with player: {Player}", player);

        if (!ModelState.IsValid)
        {
            foreach (var modelState in ModelState)
            {
                foreach (var error in modelState.Value.Errors)
                {
                    _logger.LogWarning("Validation error on {Field}: {ErrorMessage}", modelState.Key, error.ErrorMessage);
                }
            }
            return View(player);
        }

        _manager.AddPlayer(player.Name, player.BirthDate, player.Position, player.Salary);
        ModelState.Clear();

        _logger.LogInformation("Player added successfully, redirecting to Index action");

        return RedirectToAction("Index", "Player");
    }

   
    [HttpGet]
    public IActionResult Details(int id)
    {
        var player = _manager.GetPlayerWithContracts(id);
        if (player == null)
        {
            return NotFound();
        }
        return View(player);
    }
    
}