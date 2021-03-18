using Microsoft.AspNetCore.Mvc;
using SimpleAuthentication.Lib.Filter;
using SimpleAuthentication.Lib.Login;
using SimpleAuthentication.Models;
using SimpleAuthentication.Repositories.Contracts;
using System.Diagnostics;

namespace SimpleAuthentication.Controllers
{
    public class LoginController : Controller
    {
        private IUserRepository _userRepository;
        private UserLogin _userLogin;

        public LoginController(IUserRepository userRepository, UserLogin userLogin)
        {
            _userRepository = userRepository;
            _userLogin = userLogin;
        }

        [HttpGet]
        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Login([FromForm] User user)
        {
            User userDb = _userRepository.Login(user.Name, user.Password);

            if(userDb != null)
            {
                _userLogin.Login(userDb);

                return RedirectToAction("Authenticated", "Login");
            }
            else
            {
                ViewData["MSG_E"] = "Senha ou nome incorreto, por favor, digite novamente";
                return View();
            }
        }

        public IActionResult Logout()
        {
            _userLogin.Logout();

            return RedirectToAction("Login", "Login");
        }

        [UserAuthorization]
        public IActionResult Authenticated()
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
