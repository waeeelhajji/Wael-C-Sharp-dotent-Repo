using Microsoft.AspNetCore.Mvc;

namespace WebProject.Controllers;

public class HelloController : Controller
{
    [HttpGet]
    [Route("")]
    public ViewResult Index()
    {
        return View();
    }

    [HttpGet]
    [Route("Second")]
    public RedirectToActionResult Second()
    {
        return RedirectToAction("Index");
    }
    // Other code
    [HttpGet("third/{name}")]

    public ViewResult Third(string name)
    {
        ViewBag.Name = name;
        ViewBag.MyArray = new int[4] { 5, 8, 9, 6 };
        return View("Second");
    }

    [HttpGet("form")]
    public IActionResult Form()
    {
        return View("Form");
    }
    [HttpPost("process")]
    public IActionResult process(string Name, int Age)

    {
        Console.WriteLine($"Name:   {Name}");
        Console.WriteLine($"Age:   {Age}");
        return RedirectToAction("form");
    }


}
