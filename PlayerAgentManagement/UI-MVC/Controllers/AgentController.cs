using Microsoft.AspNetCore.Mvc;
using PlayerAgentManagement.BL;



namespace PlayerAgentManagement.UI.Web.MVC.Controllers;

public class AgentController : Controller
{
    private readonly IManager _manager;
    
    public AgentController(IManager manager)
    {
        _manager = manager;
    }
    
    [HttpGet]
    public IActionResult Index()
    {
        return View();
    }
}