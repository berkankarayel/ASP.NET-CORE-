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
        kurs.Image = "resim1.jpeg";
        
        return View(kurs);
    }

    public IActionResult List()
    {
        var kurslar = new List<Course>
        {
            new Course { Id = 1, Title = "ASP.NET Core 8.0 Kursu", Description = "Bu kurs ASP.NET Core 8.0 ile web uygulamaları geliştirmeyi öğretir.",Image="resim1.jpeg" },
            new Course { Id = 2, Title = "Entity Framework Core Kursu", Description = "Bu kurs Entity Framework Core ile veri erişimini öğretir.",Image="resim2.jpeg" },
            new Course { Id = 3, Title = "C# 12.0 Yenilikleri", Description = "Bu kurs C# 12.0 dilindeki yeni özellikleri öğretir.",Image="resim3.jpeg" }
        };
        return View("CourseList",kurslar);
    }

}