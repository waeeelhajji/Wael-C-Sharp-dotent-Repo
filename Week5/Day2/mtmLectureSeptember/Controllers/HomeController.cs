using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using mtmLectureSeptember.Models;
using Microsoft.EntityFrameworkCore;


namespace mtmLectureSeptember.Controllers;

public class HomeController : Controller
{
    private readonly ILogger<HomeController> _logger;

    private MyContext _context;

    public HomeController(ILogger<HomeController> logger , MyContext context)
    {

        _logger = logger;
        _context = context;
    }

    public IActionResult Index()
    {
        ViewBag.AllActors = _context.Actors.Include(s => s.MyMovies).ThenInclude(d => d.Movie).ToList();
        return View("Index");
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
        ViewBag.AllActors = _context.Actors.ToList();
        return View("Index");
    }
    [HttpGet("Movies")]
    public IActionResult Movies()
    {
        ViewBag.AllMovies = _context.Movies.Include(a => a.MyActors).ThenInclude(d => d.Actor).ToList();
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
        ViewBag.AllMovies = _context.Movies.Include(a => a.MyActors).ThenInclude(d => d.Actor).ToList();
        // ViewBag.AllMovies = _context.Movies.ToList();
        return View("Movies");
    }
    [HttpGet("Association")]
    public IActionResult Association()
    {
        ViewBag.AllActors = _context.Actors.ToList();
        ViewBag.AllMovies = _context.Movies.ToList();
        return View();
    }
    [HttpPost("association/add")]
    public IActionResult AddAssociation(Association newAssociation)
    {
        if(ModelState.IsValid)
        {
            _context.Add(newAssociation);
            _context.SaveChanges();
            return RedirectToAction("Association");
        }
        ViewBag.AllActors = _context.Actors.ToList();
        ViewBag.AllMovies = _context.Movies.ToList();
        return View("Association");
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
