using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using RandomPass.Models;

namespace RandomPass.Controllers;

public class HomeController : Controller
{
    private readonly ILogger<HomeController> _logger;

    public HomeController(ILogger<HomeController> logger)
    {
        _logger = logger;
    }
    int contador = 0;
    public IActionResult Index()
    {
        ViewBag.Times = HttpContext.Session.GetInt32("ContadorGenerador") ?? 0;
        return View();
    }
    [HttpPost]
    [Route("generate")]
    public IActionResult Generate()
    {
        HttpContext.Session.SetString("RandomsVal", "1G253FR4D5R67A");

        char[] numerosRan = new char[14];
        Random ran = new Random();
        string chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789";
        for (int i = 0; i < numerosRan.Length; i++)
        {
            numerosRan[i] = chars[ran.Next(chars.Length)];
        }
        string numRam = new string(numerosRan);
        HttpContext.Session.SetString("RandomsVal", numRam);
        contador = 1;

        int? numeroSumar = HttpContext.Session.GetInt32("ContadorGenerador");
        if (numeroSumar != null)
        {
            contador += numeroSumar.Value;
        }
        HttpContext.Session.SetInt32("ContadorGenerador", contador);

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
