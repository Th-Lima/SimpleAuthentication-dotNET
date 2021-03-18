using Microsoft.AspNetCore.Mvc;
using SimpleAuthentication.Lib.Filter;
using SimpleAuthentication.Lib.Login;
using SimpleAuthentication.Models;

namespace SimpleAuthentication.Controllers
{
    public class AdministrativePanelController : Controller
    {
        public UserLogin _userLogin { get; set; }

        public AdministrativePanelController(UserLogin userLogin)
        {
            _userLogin = userLogin;
        }

        [UserAuthorization]
        public IActionResult Index()
        {
            User user = _userLogin.GetUser();
            if (user.IsAdmin)
            {
                return View();
            }
            else
            {
                TempData["MSG_E"] = "Você não tem acesso ao painel administrativo, pois não é um administrador.";
                return RedirectToAction("Authenticated", "Login");
            }
        }
    }
}
