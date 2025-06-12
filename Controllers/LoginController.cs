using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
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
        public async Task<IActionResult> Login(Cliente cliente)
        {
            if (!ModelState.IsValid)
            {
                return View(cliente);
            }

            var user = await _context.Clientes.FirstOrDefaultAsync(u => u.Gmail == cliente.Gmail && u.Pssword == cliente.Pssword);

            if (user != null)
            {
                // Aquí puedes usar autenticación real más adelante
                return RedirectToAction("Index", "Home");
            }
            else
            {
                ViewBag.Error = "Credenciales incorrectas. Verifique su correo o contraseña.";
                return View();
            }
        }

        public IActionResult Logout()
        {
            HttpContext.Session.Clear();
            return RedirectToAction("Login");
        }
    }
}
