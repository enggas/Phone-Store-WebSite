using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PhoneStore_Website.Data;
using PhoneStore_Website.Models;
using System.Security.Claims;

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
        [AllowAnonymous]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Login(string Gmail, string Pssword, string? returnUrl = null)
        {
            if (string.IsNullOrWhiteSpace(Gmail) || string.IsNullOrWhiteSpace(Pssword))
            {
                ModelState.AddModelError("", "El Correo Electronico y la Contraseña son obligatorios.");
                return View();
            }

            var user = await _context.Cliente.FirstOrDefaultAsync(c => c.Gmail == Gmail);

            if (user == null || user.Pssword != Pssword)
            {
                ModelState.AddModelError("", "Credenciales inválidas.");
                return View();
            }

            var claims = new List<Claim>
            {
                new Claim(ClaimTypes.Email, user.Gmail),
                new Claim("Client_Id", user.Client_Id.ToString())
            };

            var identity = new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme);
            var principal = new ClaimsPrincipal(identity);

            await HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, principal);

            if (!string.IsNullOrEmpty(returnUrl) && Url.IsLocalUrl(returnUrl))
                return Redirect(returnUrl);

            return RedirectToAction("Cliente_Index", "Cliente");

        }


        public IActionResult Logout()
        {
            HttpContext.Session.Clear();
            return RedirectToAction("Login");
        }
    }
}


