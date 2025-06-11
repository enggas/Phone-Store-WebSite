using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PhoneStore_Website.Data;
using PhoneStore_Website.Models;

namespace PhoneStore_Website.Controllers
{
    public class LoginController : Controller
    {
        private readonly AplicationDBContext _context;

        public LoginController(AplicationDBContext context)
        {
            _context = context;
        }

        [HttpGet]
        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Login(Cuenta_Web cuenta)
        {
            if (!ModelState.IsValid)
            {
                return View(cuenta);
            }

            var usuario = _context.Cuenta_Web.FirstOrDefault(c =>
                c.Gmail == cuenta.Gmail &&
                c.Password == cuenta.Password &&
                c.Estado_Cuenta == true
            );

            if (usuario != null)
            {
                HttpContext.Session.SetString("Usuario", usuario.Gmail);
                return RedirectToAction("Index", "Home");
            }
            else
            {
                ViewBag.Error = "Usuario o contraseña incorrectos.";
                return View(cuenta);
            }
        }

        public IActionResult Logout()
        {
            HttpContext.Session.Clear();
            return RedirectToAction("Login");
        }
    }
}
