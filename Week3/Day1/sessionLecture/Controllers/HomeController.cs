using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using sessionLecture.Models;
using Microsoft.AspNetCore.Http;

namespace sessionLecture.Controllers;

public class HomeController : Controller
{
    private readonly ILogger<HomeController> _logger;

    public HomeController(ILogger<HomeController> logger)
    {
        _logger = logger;
    }

    public IActionResult Index()
    {
        // create our first Session
        // HttpContext.Session.SetString("User", "WaelHajji");
        // string? user = HttpContext.Session.GetString("User");
        // Console.WriteLine(user);

        // we need to check if there is anything in session ad do something based on the answer 
        if (HttpContext.Session.GetInt32("Sum") == null)
        {
            HttpContext.Session.SetInt32("Sum", 0);
        }
        return View();
    }

    [HttpPost("setName")]
    public IActionResult SetName(string Name, int Num)
    {
        HttpContext.Session.SetString("User", Name);
        int? original = HttpContext.Session.GetInt32("Sum");
        HttpContext.Session.SetInt32("Sum", (int)original + Num);
        // Console.WriteLine(original);
        return RedirectToAction("Index");
    }
    [HttpGet("delete")]
    public IActionResult DeleteSession()

    {
        HttpContext.Session.Clear();
        return RedirectToAction("Index");
    }


    public IActionResult Privacy()
    {
        return View();
    }

    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
}
