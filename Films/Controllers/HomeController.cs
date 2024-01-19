using Films.Models;
using Films.Services;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace Films.Controllers
{
    public class HomeController : Controller
    {
        private readonly Film_service film_service;
        private readonly User_service user_service;
        public HomeController()
        {
            film_service = Film_service.Get_film_service();
            user_service = User_service.Get_user_service();
        }

        public IActionResult Index()
        {
            ViewBag.Role = user_service.Role;
            return View();
        }

        public IActionResult About()
        {
            return View();
        }

        public IActionResult Films()
        {
            ViewBag.Role = user_service.Role;
            ViewBag.Films = film_service.Get();
            return View();
        }

        public IActionResult Film(string id)
        {
            ViewBag.Role = user_service.Role;
            ViewBag.Film = film_service.Get(id);
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