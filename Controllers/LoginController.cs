using Microsoft.AspNetCore.Mvc;
using Online_Store.Models;

namespace Online_Store.Controllers
{
    public class LoginController:Controller
    {
        private readonly LoginModel login;

        public LoginController()
        {
            login = new LoginModel();
        }

        [HttpPost]
        public ActionResult Login(string email, string name)
        {
            var loginModel = new LoginModel();
            int userId = loginModel.SelectUser(email, name);
            if (userId != -1)
            {

                HttpContext.Session.SetInt32("UserID", userId);


                // User found, proceed with login logic (e.g., set authentication cookie)
                // For demonstration, redirecting to a dummy page
                return RedirectToAction("Index", "Home");
            }
            else
            {
                // User not found, handle accordingly (e.g., show error message)
                return View("LoginFailed");
            }
        }
    }
}

