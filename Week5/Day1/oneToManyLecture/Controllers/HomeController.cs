using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using oneToManyLecture.Models;
using Microsoft.EntityFrameworkCore;

namespace oneToManyLecture.Controllers;

public class HomeController : Controller
{
    private MyContext _context ;
    private readonly ILogger<HomeController> _logger;

    public HomeController(ILogger<HomeController> logger , MyContext context)
    {
        _logger = logger;
        _context = context;
    }

    public IActionResult Index()
    {
        ViewBag.AllOwners = _context.Owners.Include(p => p.PetOwned).ToList();
        // ViewBag.AllOwners = _context.Owners.ToList();
        return View();
    }
    [HttpPost("owner/add")]
    public IActionResult AddOwner(Owner newOwner)
    {
        if(ModelState.IsValid)
        {
            // we can add to the database
            _context.Add(newOwner);
            _context.SaveChanges();
            return RedirectToAction("Index");

        }else {
            ViewBag.AllOwners = _context.Owners.Include(p => p.PetOwned).ToList();
            return View("Index");
        }
    }
    [HttpGet("Pet")]
    public IActionResult Pets()
    {
        ViewBag.AllPets = _context.Pets.Include(a => a.Owner).ToList();
        ViewBag.AllOwners = _context.Owners.ToList();
        return View();
    }
    [HttpPost("pet/add")]
    public IActionResult AddPet(Pet newPet)
    {
        if(ModelState.IsValid)
        {
            // we can add to the database
            _context.Add(newPet);
            _context.SaveChanges();
            return RedirectToAction("Pets");

        }else {
            ViewBag.AllOwners = _context.Owners.ToList();
            ViewBag.AllPets = _context.Pets.Include(a => a.Owner).ToList();
            return View("Pets");
        }
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
