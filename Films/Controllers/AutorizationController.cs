using Films.Models;
using Films.Services;
using Microsoft.AspNetCore.Mvc;

namespace Films.Controllers
{
    public class AuthorizationController : Controller
    {
        private readonly User_service user_service;
        public AuthorizationController()
        {
            user_service = User_service.Get_user_service();
        }
        public IActionResult Log_in(User user)
        {
            user_service.Check_user(user);
            return Redirect(Request.Headers["Referer"].ToString());
        }
    }
}
