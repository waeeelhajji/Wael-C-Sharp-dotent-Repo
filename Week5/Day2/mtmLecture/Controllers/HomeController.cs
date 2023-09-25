using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using mtmLecture.Models;
using Microsoft.EntityFrameworkCore;

namespace mtmLecture.Controllers;

public class HomeController : Controller
{
    private MyContext _context;
    private readonly ILogger<HomeController> _logger;

    public HomeController(ILogger<HomeController> logger, MyContext context)
    {
        _logger = logger;
        _context = context;
    }

    public IActionResult Index()
    {
        return View();
    }
    [HttpPost("/add/actor")]
    public IActionResult CreateActor(Actor newActor)
    {
        if(ModelState.IsValid)
        {
            _context.Add(newActor);
            _context.SaveChanges();
            return RedirectToAction("Index");
        }
        return View("Index");
    }
    [HttpGet("Movies")]
    public IActionResult Movies ()
    {
        return View();
    }
    [HttpPost("add/movie")]
    public IActionResult CreateMovie(Movie newMovie)
    {
        if(ModelState.IsValid)
        {
            _context.Add(newMovie);
            _context.SaveChanges();
            return RedirectToAction("Movies");
        }
        return View("Movies");
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
