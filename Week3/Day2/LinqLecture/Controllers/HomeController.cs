using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using LinqLecture.Models;

namespace LinqLecture.Controllers;

public class HomeController : Controller
{
    public static Game[] AllGames = new Game[] {
        new Game {Title="Elden Ring", Price=59.99, Genre="Action RPG", Rating="M", Platform="PC"},
        new Game {Title="League of Legends", Price=0.00, Genre="MOBA", Rating="T", Platform="PC"},
        new Game {Title="World of Warcraft", Price=39.99, Genre="MMORPG", Rating="T", Platform="PC"},
        new Game {Title="Elder Scrolls Online", Price=14.99, Genre="Action RPG", Rating="M", Platform="PC"},
        new Game {Title="Smite", Price=0.00, Genre="MOBA", Rating="T", Platform="All"},
        new Game {Title="Overwatch", Price=39.00, Genre="First-person Shooter", Rating="T", Platform="PC"},
        new Game {Title="Scarlet Nexus", Price=59.99, Genre="Action JRPG", Rating="T", Platform="All"},
        new Game {Title="Wonderlands", Price=59.99, Genre="RPG FPS", Rating="M", Platform="All"},
        new Game {Title="Rocket League", Price=0.00, Genre="Sports", Rating="E", Platform="All"},
        new Game {Title="StarCraft", Price=0.00, Genre="RTS", Rating="T", Platform="PC"},
        new Game {Title="God of War", Price=29.99, Genre="Action-adventure ", Rating="M", Platform="PC"},
        new Game{Title="Doki Doki Literature Club Plus!", Price=10.00, Genre="Casual", Rating="E", Platform="PC"},
        new Game {Title="Red Dead Redemption", Price=40.00, Genre="Action adventure", Rating="M", Platform="All"},
        new Game {Title="My Little Pony A Maretime Bay Adventure", Price=39.99, Genre="Adventure", Rating="E",Platform="All"},
        new Game {Title="Fallout New Vegas", Price=10.00, Genre="Open World RPG", Rating="M", Platform="PC"}
    };
    private readonly ILogger<HomeController> _logger;

    public HomeController(ILogger<HomeController> logger)
    {
        _logger = logger;
    }

    public IActionResult Index()
    {
        // get us all the date(games )from database 
        List<Game> allGamesFromData = AllGames.ToList();
        ViewBag.allGamesFromData = allGamesFromData;
        // List of Acceding Data 
        // List<Game> OrderedData = AllGames.OrderBy(s => s.Title).ToList();
        List<Game> OrderedData = AllGames.OrderByDescending(s => s.Title).ToList();
        ViewBag.Ordered = OrderedData;
        // List Of Games Order By Price
        List<Game> OrderByPrice = AllGames.OrderBy(s => s.Price).ToList();
        ViewBag.OrdPrice = OrderByPrice;
        // List o Games order by Price and Title
        List<Game> OrderPT = AllGames.OrderBy(f => f.Title).OrderBy(a => a.Price).ToList();
        ViewBag.OrderPT = OrderPT;
        //List of Games available in All Platforms 
        List<Game> AllPlatforms = AllGames.Where(j => j.Platform == "All" && j.Rating == "M").ToList();
        ViewBag.AllPlatforms = AllPlatforms;
        // Top 3 of games that have Rating M and the low Price
        List<Game> topGames = AllGames.Where(w => w.Rating == "M").OrderBy(q => q.Price).Take(3).ToList();
        ViewBag.topGames = topGames;

        // Search for one Game called Rocket League
        Game singLeGame = AllGames.FirstOrDefault(k => k.Title == "Rocket League");
        ViewBag.singLeGame = singLeGame;
        return View();
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
