using Microsoft.AspNetCore.Mvc;
using MvcApp.Models;

namespace MvcApp.Controllers;

public class CourseController : Controller
{
    public IActionResult Index()
    {
        var kurs = new Course();
        kurs.Id = 1;
        kurs.Title = "ASP.NET Core 8.0 Kursu";
        kurs.Description = "Bu kurs ASP.NET Core 8.0 ile web uygulamaları geliştirmeyi öğretir.";
        
        return View(kurs);
    }

    public IActionResult List()
    {
        return View();
    }

}