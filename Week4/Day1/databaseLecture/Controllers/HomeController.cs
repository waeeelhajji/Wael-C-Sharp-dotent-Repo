using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using databaseLecture.Models;

namespace databaseLecture.Controllers;

public class HomeController : Controller
{

    private MyContext _context;
    private readonly ILogger<HomeController> _logger;

    public HomeController(ILogger<HomeController> logger, MyContext context)
    {
        _logger = logger;
        // this will connect us to the database 
        _context = context;
    }

    public IActionResult Index()

    {
        ViewBag.AllItems = _context.Items.OrderBy(a => a.name).ToList();
        return View();
    }
    [HttpPost("item/add")]
    public IActionResult AddItem(Item newItem)
    {
        // We add this to the database so long it's correct
        if (ModelState.IsValid)
        {
            // we can add to the database
            // and pass this object to the .Add() method
            _context.Add(newItem);
            _context.SaveChanges();
            return RedirectToAction("Index");
        }
        else
        {
            return View("Index");
        }
    }
    [HttpGet("/item/delete/{ItemId}")]
    public IActionResult DeleteItem(int ItemId)
    {
        Item itemToDelete = _context.Items.SingleOrDefault(a => a.ItemId == ItemId);
        _context.Items.Remove(itemToDelete);
        _context.SaveChanges();
        return RedirectToAction("Index");
    }
    [HttpGet("/item/edit/{ItemId}")]
    public IActionResult EditItem(int ItemId)
    {
        // we Need to find the item
        Item itemToEdit = _context.Items.FirstOrDefault(b => b.ItemId == ItemId);
        return View(itemToEdit);
    }
    [HttpPost("/item/update/{ItemId}")]
    public IActionResult UpdateItem(int ItemId, Item newVersionOfTheItem)
    {
        Item oldItem = _context.Items.FirstOrDefault(b => b.ItemId == ItemId);

        oldItem.name = newVersionOfTheItem.name;
        oldItem.Description = newVersionOfTheItem.Description;
        oldItem.UpdatedAt = newVersionOfTheItem.UpdatedAt;
        _context.SaveChanges();
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
