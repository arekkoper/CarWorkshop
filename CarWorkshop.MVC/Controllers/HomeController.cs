using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using CarWorkshop.MVC.Models;

namespace CarWorkshop.MVC.Controllers;

public class HomeController : Controller
{
    private readonly ILogger<HomeController> _logger;

    public HomeController(ILogger<HomeController> logger)
    {
        _logger = logger;
    }

    public IActionResult Index()
    {
        return View();
    }

    public IActionResult Privacy()
    {
        var model = new List<Person>()
        {
            new Person()
            {
                FirstName = "Arek",
                LastName = "Arek"
            },
            new Person()
            {
                FirstName = "Anitka",
                LastName = "Kożuszek-Koper"
            }
        };

        return View(model);
    }

    public IActionResult About()
    {
        var model = new About("Some words about me", "Hi everyone! Im Arek and it's nice to see you :D", new string[] { "nice", "code", "nicepayment" }  );

        return View(model);
    }

    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
}
