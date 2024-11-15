﻿using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using beltReview.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity;

namespace beltReview.Controllers;

public class HomeController : Controller
{
    private readonly ILogger<HomeController> _logger;
    private MyContext _context;


    public HomeController(ILogger<HomeController> logger, MyContext context)
    {
        _logger = logger;
        _context = context;
    }

    public IActionResult Index()
    {
        ViewBag.NotLogIn = true;
        return View();
    }
    [HttpPost("user/register")]
    public IActionResult Register(User newUser)
    {
        ViewBag.NotLogIn = true;
        if (ModelState.IsValid)
        {
            
            // Verify if the email is unique
            // hash the password before adding it to the database
            if (_context.Users.Any(u => u.Email == newUser.Email))
            {
            
            // error message
            ModelState.AddModelError("Email", "Email already in use!");
                return View("Index");
            }
            // Hash the password before adding it to the database
            PasswordHasher<User> Hasher = new PasswordHasher<User>();
            newUser.Password = Hasher.HashPassword(newUser, newUser.Password);
            _context.Add(newUser);
            _context.SaveChanges();
            HttpContext.Session.SetInt32("UserId", newUser.UserId);
            
            return RedirectToAction("Dashboard");
        }
        else
        {
            return View("Index");
        }
    }
    [HttpPost("user/login")]
    public IActionResult Login(LogUser LoginUser)
    {
        ViewBag.NotLogIn = true;
        if (ModelState.IsValid)
        {
            
            // Verify the email in our Database
            User? userInDb = _context.Users.FirstOrDefault(u => u.Email == LoginUser.LogEmail);
        // If no user exists with provided email
        if(userInDb == null)
        {
            // Add an error to ModelState and return to View!
            ModelState.AddModelError("LogEmail", "Invalid Login Attempt");
            return View("Index");
        }
            // then verify if the password matches what's in the database
            PasswordHasher<LogUser> hasher = new PasswordHasher<LogUser>();
            var result = hasher.VerifyHashedPassword(LoginUser, userInDb.Password, LoginUser.LogPassword);
            if(result == 0)
        {
            ModelState.AddModelError("LogEmail", "Invalid Login Attempt");
            return View("Index");
        }
            HttpContext.Session.SetInt32("UserId", userInDb.UserId);
            
            return RedirectToAction("Dashboard");
        }
        else
        {
            return View("Index");
        }
    }
    [HttpGet("Dashboard")]
    public IActionResult Dashboard()
    {
        if( HttpContext.Session.GetInt32("UserId")==null){
            return RedirectToAction("Index");
        }
        ViewBag.NotLogIn = false;
         
        User? userMusic = _context.Users.Include(a => a.SongsWritten).FirstOrDefault(a => a.UserId == HttpContext.Session.GetInt32("UserId"));
         

        User? userInDb = _context.Users.FirstOrDefault(a => a.UserId == HttpContext.Session.GetInt32("UserId"));
        ViewBag.LoggedIn = userInDb;
        ViewBag.userMusic=userMusic;
        return View();
    }
    [HttpGet("song/create")]
    public IActionResult AddSong()
    {
        if( HttpContext.Session.GetInt32("UserId")==null){
            return RedirectToAction("Index");
        }
        ViewBag.NotLogIn = false;
        return View();
    }
    [HttpPost("song/add")]
    public IActionResult CreateSong(Song newSong)
    {
        ViewBag.NotLogIn = false;
        if (ModelState.IsValid)
        {
            newSong.UserId = (int)HttpContext.Session.GetInt32("UserId");
            _context.Add(newSong);
            _context.SaveChanges();
            return RedirectToAction("Dashboard");
        }
        else {
            return View("AddSong");
        }
    }
    [HttpGet("song/all")]
    public IActionResult AllSongs()
    {
        if( HttpContext.Session.GetInt32("UserId")==null){
            return RedirectToAction("Index");
        }
        ViewBag.NotLogIn = false;
        ViewBag.Allsongs = _context.Songs.Include(a => a.Artist).ToList();
        return View();
    }
     [HttpGet("logout")]
    public IActionResult Logout()
    {
        HttpContext.Session.Clear();
        return RedirectToAction("Index");
    }

    

    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
}
