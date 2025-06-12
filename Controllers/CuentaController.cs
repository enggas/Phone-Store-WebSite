using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using PhoneStore_Website.Data;
using PhoneStore_Website.Models;
using System.Linq;

namespace PhoneStore_Website.Controllers
{
    public class CuentaController : Controller
    {
        private readonly AplicationDBContext _context;

        public CuentaController(AplicationDBContext context)
        {
            _context = context;
        }

        [HttpGet]
        public IActionResult CrearCuenta()
        {

            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult CrearCuenta(Cuenta_Web cuenta)
        {
            if (!ModelState.IsValid)
            {
                ViewBag.Clientes = _context.Clientes
                    .Where(c => c.Cliente_Estado == true)
                    .Select(c => new SelectListItem
                    {
                        Text = c.Client_Fullname
                    }).ToList();

                return View(cuenta);
            }

            _context.Cuenta_Web.Add(cuenta);
            _context.SaveChanges();

            // Redirige al login después de crear cuenta
            return RedirectToAction("Login", "Login");
        }
    }
}
