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
        public IActionResult CrearCuenta(Cliente cliente)
        {
            if (!ModelState.IsValid)
            {
                return View(cliente);
            }

            _context.SaveChanges();

            // Redirige al login después de crear cuenta
            return RedirectToAction("Login", "Login");
        }
    }
}
