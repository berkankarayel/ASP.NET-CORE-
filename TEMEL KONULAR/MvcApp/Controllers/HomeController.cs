using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using MvcApp.Models;

namespace MvcApp.Controllers;

public class HomeController : Controller
{
   

    public IActionResult Index()
    {
        return View();
    }

    public IActionResult Contact()
    {
        return  View();
    }

}

