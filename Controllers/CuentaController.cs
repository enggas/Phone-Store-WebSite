using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using PhoneStore_Website.Data;
using PhoneStore_Website.Models;
using System.Linq;
using System.Security.Claims;
using System.Text.RegularExpressions;

namespace PhoneStore_Website.Controllers
{
    public class CuentaController : Controller
    {
        private readonly AplicationDBContext _context;

        public CuentaController(AplicationDBContext context)
        {
            _context = context;
        }


        private bool ValidarTelefono(string telefono) { 
            return Regex.IsMatch(telefono, @"^[2578][0-9]{7}$");
        }

        private bool ValidarCedula(string cedula)
        {
            return Regex.IsMatch(cedula, @"^\d{3}-\d{6}-\d{4}[A-Z]$");
        }


        [HttpGet]
        public IActionResult CrearCuenta()
        {

            return View();
        }

        [HttpPost]
        [AllowAnonymous]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> CrearCuenta(CrearCuentaViewModel cuenta)
        {
            if (!ModelState.IsValid)
            {
                return View(cuenta);
            }

            if (!ValidarTelefono(cuenta.Telefono))
            {
                ModelState.AddModelError("Telefono", "El teléfono debe tener 8 dígitos y comenzar por 2, 5, 7 u 8.");
                return View(cuenta);
            }

            if (!ValidarCedula(cuenta.Cedula))
            {
                ModelState.AddModelError("Cedula", "La cédula debe tener el formato 000-000000-0000A.");
                return View(cuenta);
            }

            bool existe = await _context.Cliente.AnyAsync(c => c.Gmail == cuenta.Gmail);
            if (existe)
            {
                ModelState.AddModelError("", "El correo electrónico ya está en uso.");
                return View(cuenta);
            }

            var user = new Cliente
            {
                Cedula = cuenta.Cedula,
                Client_Fullname = cuenta.Nombre,
                Gmail = cuenta.Gmail,
                Pssword = cuenta.Pssword,
                Telephone = cuenta.Telefono
            };

            _context.Cliente.Add(user);
            await _context.SaveChangesAsync();

            var claims = new List<Claim>
            {
                new Claim(ClaimTypes.Email, user.Gmail),
                new Claim("Client_Id", user.Client_Id.ToString())
            };

            var identity = new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme);
            var principal = new ClaimsPrincipal(identity);

            await HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, principal);


            return RedirectToAction("Index", "Home");
        }
    }
}
