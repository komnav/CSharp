using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using ASP.NETWithYoutube.Models;

namespace ASP.NETWithYoutube.Controllers;

public class HomeController : Controller
{
    private readonly ILogger<HomeController> _logger;
    private readonly IConfiguration _configuration;
    private Dictionary<string, int> _users = new Dictionary<string, int>();

    public HomeController(ILogger<HomeController> logger, IConfiguration configuration)
    {
        _logger = logger;
        _configuration = configuration;
    }

    public IActionResult PrintInfo()
    {
        var numbersList = new List<int>
        {
            1, 2, 3, 4, 4, 5, 6, 7, 8, 9
        };
        var numberArray = new string[] { "1", "2", "3", "4", "5", "6", "7", "8", "9" };
        var users = new List<User>()
        {
            new User { Name = "John", Age = 20 },
            new User { Name = "Jane", Age = 30 },
            new User { Name = "Johny", Age = 40 }
        };
        return View(users);
    }

    [HttpGet]
    public IActionResult Calculate(int firstNumber, int secondNumber)
    {
        var result = firstNumber + secondNumber;
        return View(result);
    }

    [HttpGet]
    public IActionResult CreateUser()
    {
        return View();
    }

    [HttpPost]
    public IActionResult CreateUser(User user)
    {
        if (ModelState.IsValid)
        {
            _logger.LogInformation("User created");
            _users.Add(user.Name, user.Age);
            TempData["Message"] = $"User {user.Name} created";
            return RedirectToAction("Index");
        }

        return View();
    }

    public IActionResult Index()
    {
        return View();
    }

    public IActionResult Privacy()
    {
        return View();
    }
}