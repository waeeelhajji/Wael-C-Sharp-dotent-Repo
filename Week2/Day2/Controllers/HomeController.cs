using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using Day2.Models;

namespace Day2.Controllers;

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
        return View();
    }
    [HttpPost("process")]

    public IActionResult process(User newUser)

    {
        if (ModelState.IsValid)
        {
            //this means we passed our validation
            // then would you redirect to success
            return RedirectToAction("Success", newUser);
        }
        else
        {
            return View("Index");
        }

        // Console.WriteLine(newUser.Name);
        // Console.WriteLine(newUser.FavColor);
        // Console.WriteLine(newUser.FavNumber);

    }

    [HttpGet("Success")]
    public IActionResult Success(User newUser)

    {
        ViewBag.User = newUser;
        return View(newUser);

    }


    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
}
