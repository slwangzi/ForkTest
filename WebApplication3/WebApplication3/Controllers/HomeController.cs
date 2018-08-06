using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using WebApplication3.Models;

namespace WebApplication3.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            ViewBag.Title = "CCC";
            TempData["Title1"] = "Dave";
            //HttpContext.Session.Set("Title0", Encoding.UTF8.GetBytes("Title0"));
            //HttpContext.Session.TryGetValue("Title0", out byte[] Title0);
            //ViewBag.Title0 = Encoding.UTF8.GetString(Title0);
            return View();
        }

        public IActionResult About()
        {
            ViewData["Message"] = "Your application description page.";
            HttpContext.Session.TryGetValue("Title0", out byte[] Title0);
            ViewBag.Title0 = Encoding.UTF8.GetString(Title0);
            ViewBag.Title1 = TempData["Title1"];
            ViewBag.Title2 = TempData["Title1"];
            return View();
        }

        public IActionResult Contact()
        {
            ViewData["Message"] = "Your contact page.";

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
}
