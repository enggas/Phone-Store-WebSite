using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PhoneStore_Website.Data;
using System.Security.Claims;

namespace PhoneStore_Website.Controllers
{
    public class LoginEmpleadoController : Controller
    {

        private readonly AplicationDBContext _context;

        public LoginEmpleadoController(AplicationDBContext context)
        {
            _context = context;
        }


        [HttpGet]
        public IActionResult LoginEmpleado()
        {
            return View("LoginEmpleado");
        }

        [HttpPost]
        [AllowAnonymous]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> LoginEmpleado(string Gmail, string Password, string? returnUrl = null)
        {
            if (string.IsNullOrWhiteSpace(Gmail) || string.IsNullOrWhiteSpace(Password))
            {
                ModelState.AddModelError("", "El correo electrónico y la contraseña son obligatorios.");
                return View("LoginEmpleado");
            }

            var empleado = await _context.Empleado.FirstOrDefaultAsync(e => e.Gmail == Gmail);

            if (empleado == null || empleado.Password != Password || !empleado.User_State)
            {
                ModelState.AddModelError("", "Credenciales inválidas o usuario inactivo.");
                return View("LoginEmpleado");
            }

            // Crear los claims del empleado
            var claims = new List<Claim>
            {
                new Claim(ClaimTypes.Email, empleado.Gmail),
                new Claim("Empleado_Id", empleado.Id_Empleado.ToString()),
                new Claim("Nombre", empleado.Employee_Fullname),
                new Claim(ClaimTypes.Role, empleado.Role_Id.ToString())
            };

            var identity = new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme);
            var principal = new ClaimsPrincipal(identity);

            await HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, principal);


            switch (empleado.Role_Id)
            {
                case 1: // Administrador de Usuarios
                    return RedirectToAction("Admin_Index", "Administrador");

                case 2: // Encargado de Compras
                    return RedirectToAction("Dashboard", "Compras");

                case 3: // Encargado de Ventas
                    return RedirectToAction("Dashboard", "Ventas");

                case 4: // Cliente (si se permitiera login desde aquí)
                    return RedirectToAction("Catalogo", "Cliente");

                default:
                    // Rol no reconocido
                    await HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);
                    ModelState.AddModelError("", "Rol de usuario no reconocido.");
                    return View();

            }
        }


        // GET: LoginEmpleado/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: LoginEmpleado/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: LoginEmpleado/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: LoginEmpleado/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: LoginEmpleado/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: LoginEmpleado/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: LoginEmpleado/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}
