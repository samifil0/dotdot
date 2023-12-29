using Microsoft.AspNetCore.Mvc;
using PlayerAgentManagement.BL;

namespace PlayerAgentManagement.UI.Web.MVC.Controllers;

public class TeamController : Controller
{
    private readonly IManager _manager;
    
    public TeamController(IManager manager)
    {
        _manager = manager;
    }
    
    [HttpGet]
    public IActionResult Index()
    {
        var teams = _manager.GetAllTeamsWithContracts();
        return View(teams);
    }
    
    [HttpGet]
    public IActionResult Details(int id)
    {
        var team = _manager.GetTeamWithContracts(id);
        return View(team);
    }
    
}