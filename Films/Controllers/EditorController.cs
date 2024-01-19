using Films.Models;
using Films.Services;
using Microsoft.AspNetCore.Mvc;

namespace Films.Controllers
{
    public class EditorController : Controller
    {
        private readonly Film_service film_service;
        private readonly User_service user_service;
        IWebHostEnvironment app_environment;
        public EditorController(IWebHostEnvironment app_environment)
        {
            film_service = Film_service.Get_film_service();
            user_service = User_service.Get_user_service();
            this.app_environment = app_environment;
        }
        public IActionResult Create_film(Film new_film)
        {
            film_service.Create(new_film);
            return RedirectToAction("Films", "Home");
        }
        public IActionResult Update_film(Film film)
        {
            film_service.Update(film);
            return Redirect($"~/Home/Film/{film.Id}");
        }

        public IActionResult Remove_film(Film film)
        {
            film_service.Remove(film);
            return RedirectToAction("Films", "Home");
        }
        public IActionResult Add_image(string id, IFormFile image)
        {
            if (image != null)
            {
                string path = @$"{app_environment.WebRootPath}/images/{id}.jpg";
                var file_stream = new FileStream(path, FileMode.Create);
                image.CopyTo(file_stream);
            }
            return Redirect($"~/Home/Film/{id}");
        }
    }
}
