using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Text.Json;
using PhoneStore_Website.Data;
using PhoneStore_Website.Models;
using System.Security.Claims;

namespace PhoneStore_Website.Controllers
{
    [Authorize]
    public class ClienteController : Controller
    {
        private readonly AplicationDBContext _context;

        public ClienteController(AplicationDBContext context)
        {
            _context = context;
        }

        [HttpGet]
        public ActionResult Cliente_Index()
        {
            return View();
        }

        public IActionResult AgregarAlCarrito(int productoId, int cantidad)
            {
            // Obtener carrito actual desde la sesión
            var carrito = HttpContext.Session.GetString("Carrito");
            List<Carrito> lista;

            if (carrito == null)
            {
                lista = new List<Carrito>();
            }
            else
            {
                lista = JsonSerializer.Deserialize<List<Carrito>>(carrito) ?? new List<Carrito>();
            }

            // Obtener datos del producto desde la BD
            var producto = _context.Producto.FirstOrDefault(p => p.Prod_Id == productoId);
            if (producto == null)
                return NotFound();

            // Agregar o actualizar el producto en la lista
            var existente = lista.FirstOrDefault(p => p.Prod_Id == productoId);
            if (existente != null)
                existente.Cantidad += cantidad;
            else
                lista.Add(new Carrito
            {
                    Prod_Id = producto.Prod_Id,
                    Nombre = producto.Prod_Name,
                    Precio = producto.Sale_Price,
                    Cantidad = cantidad
                });

            // Guardar de nuevo en sesión
            HttpContext.Session.SetString("Carrito", JsonSerializer.Serialize(lista));

            return RedirectToAction("Cliente_Index");
            }

        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: ClienteController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: ClienteController/Create
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

        // GET: ClienteController/Edit/5
        public ActionResult Edit(int id)
            {
            return View();
            }

        // POST: ClienteController/Edit/5
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

        // GET: ClienteController/Delete/5
        public ActionResult Delete(int id)
            {
            return View();
            }

        // POST: ClienteController/Delete/5
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
