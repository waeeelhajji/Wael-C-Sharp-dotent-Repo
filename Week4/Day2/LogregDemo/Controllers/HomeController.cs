using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Identity;
using LogregDemo.Models;

namespace LogregDemo.Controllers;

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
    [HttpPost("/user/register")]
    public IActionResult Register(User newUser)
    {
        if (ModelState.IsValid)
        {
            // we passed validation
            // we need to check if the email is unique 
            if (_context.Users.Any(w => w.Email == newUser.Email))
            {
                // we have a problem. this user already has this email in database
                ModelState.AddModelError("Email", "Email is already in use!");
                return View("Index");
            }
            PasswordHasher<User> Hasher = new PasswordHasher<User>();
            newUser.Password = Hasher.HashPassword(newUser, newUser.Password);
            _context.Add(newUser);
            _context.SaveChanges();
            return RedirectToAction("Success");
        }
        else
        {
            return View("Index");
        }
    }
    [HttpPost("user/login")]
    public IActionResult Login(LoginUser loginUser)
    {
        if (ModelState.IsValid)
        {
            // step 1 : find their email ad if we can't find it throw an error
            User userInDB = _context.Users.FirstOrDefault(a => a.Email == loginUser.LogEmail);
            if (userInDB == null)
            {
                // there was no Email in the database
                ModelState.AddModelError("LogEmail", "Invalid Login Attempt");
                return View("Index");
            }
            PasswordHasher<LoginUser> Hasher = new PasswordHasher<LoginUser>();
            var result = Hasher.VerifyHashedPassword(loginUser, userInDB.Password, loginUser.LogPassword);
            if (result == 0)
            {
                // this is a problem, we did not the correct password
                ModelState.AddModelError("LogEmail", "Invalid Login Attempt");
                return View("Index");
            }
            else
            {
                return RedirectToAction("success");
            }
        }
        else
        {
            return View("Index");
        }
    }
    [HttpGet("success")]
    public IActionResult Success()
    {
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
