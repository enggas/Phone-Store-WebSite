using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PhoneStore_Website.Data;
using PhoneStore_Website.Models;
using PhoneStore_Website.Models.ViewModels.Cliente;
using System.Security.Claims;
using System.Text.Json;

namespace PhoneStore_Website.Controllers
{
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
            var model = new ClienteIndexViewModel
            {
                Productos = new List<Producto>(), // O carga tus productos aquí
                Marcas = new List<Marca>()        // O carga tus marcas aquí
            };
            return View(model);

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

        [HttpPost]
        public async Task<IActionResult> RealizarCompra(Venta ventaForm)
        {
            var carritoJson = HttpContext.Session.GetString("Carrito");
            if (string.IsNullOrEmpty(carritoJson))
            {
                TempData["Error"] = "El carrito está vacío.";
                return RedirectToAction("Cliente_Index");
            }

            var carrito = JsonSerializer.Deserialize<List<Carrito>>(carritoJson);
            if (carrito == null || carrito.Count == 0)
            {
                TempData["Error"] = "No se pudo cargar el carrito.";
                return RedirectToAction("Cliente_Index");
            }

            if (!User.Identity?.IsAuthenticated ?? true || string.IsNullOrEmpty(User.Identity?.Name))
            {

                TempData["Error"] = "Cliente no Registrado.";
                return RedirectToAction("Cuenta", "CrearCuenta");
            
            }

            // Obtener datos del usuario autenticado (cliente)
            var cliente = await _context.Cliente.FirstOrDefaultAsync(c => c.Gmail == User.Identity.Name);
            if (cliente == null)
            {
                TempData["Error"] = "Cliente no autenticado.";
                return RedirectToAction("Login", "Login");
            }

            // Crear nueva venta
            var venta = new Venta
            {
                Client_Id = cliente.Client_Id,
                Id_Empleado = null, // Cliente realiza la compra
                Sale_Status = 1, // Pendiente
                Pay_Type = ventaForm.Pay_Type,
                Card_Num = ventaForm.Card_Num,
                Pay_Amount = carrito.Sum(i => i.Subtotal),
                Total_Amount = carrito.Sum(i => i.Subtotal),
                Change_Amount = 0,
                Det_Ventas = new List<Det_Venta>()
            };


            // Agregar productos al detalle de venta
            foreach (var item in carrito)
            {
                venta.Det_Ventas.Add(new Det_Venta
                {
                    Prod_Id = item.Prod_Id,
                    Quantity = item.Cantidad,
                    Sale_Price = item.Precio,
                    Subtotal = item.Subtotal,
                    Sale_Id = venta.Sale_Id
                });
            }

            // Guardar la venta y sus detalles
            _context.Ventas.Add(venta);
            await _context.SaveChangesAsync();

            // Limpiar el carrito después de la compra
            HttpContext.Session.Remove("Carrito");

            TempData["Exito"] = "¡Compra realizada con éxito!";
            return RedirectToAction("HistorialCompras");
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

        [HttpGet]
        [HttpGet]
        public async Task<IActionResult> DetalleCliente()
        {
            var clientIdClaim = User.FindFirst("Client_Id")?.Value;
            if (string.IsNullOrEmpty(clientIdClaim) || !int.TryParse(clientIdClaim, out int clientId))
            {
                return RedirectToAction("Login", "Login");
            }

            var cliente = await _context.Cliente.FirstOrDefaultAsync(c => c.Client_Id == clientId);
            if (cliente == null)
            {
                return NotFound();
            }

            return View(cliente);
        }

        [HttpGet]
        public async Task<IActionResult> EditarCuentaCliente()
        {
            var clientIdClaim = User.FindFirst("Client_Id")?.Value;
            if (string.IsNullOrEmpty(clientIdClaim) || !int.TryParse(clientIdClaim, out int clientId))
            {
                return RedirectToAction("Login", "Login");
            }

            var cliente = await _context.Cliente.FirstOrDefaultAsync(c => c.Client_Id == clientId);
            if (cliente == null)
            {
                return NotFound();
            }

            return View(cliente);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> EditarCuentaCliente(Cliente model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }

            var clientIdClaim = User.FindFirst("Client_Id")?.Value;
            if (string.IsNullOrEmpty(clientIdClaim) || !int.TryParse(clientIdClaim, out int clientId))
            {
                return RedirectToAction("Login", "Login");
            }

            var cliente = await _context.Cliente.FirstOrDefaultAsync(c => c.Client_Id == clientId);
            if (cliente == null)
            {
                return NotFound();
            }

            // Validaciones manuales adicionales
            if (string.IsNullOrWhiteSpace(model.Client_Fullname))
            {
                ModelState.AddModelError("Client_Fullname", "El nombre completo es obligatorio.");
                return View(model);
            }

            if (string.IsNullOrWhiteSpace(model.Gmail))
            {
                ModelState.AddModelError("Gmail", "El correo electrónico es obligatorio.");
                return View(model);
            }

            if (string.IsNullOrWhiteSpace(model.Pssword))
            {
                ModelState.AddModelError("Pssword", "La contraseña es obligatoria.");
                return View(model);
            }

            if (string.IsNullOrWhiteSpace(model.Telephone))
            {
                ModelState.AddModelError("Telephone", "El número de teléfono es obligatorio.");
                return View(model);
            }

            // Actualizar campos
            cliente.Client_Fullname = model.Client_Fullname;
            cliente.Gmail = model.Gmail;
            cliente.Pssword = model.Pssword;
            cliente.Telephone = model.Telephone;

            await _context.SaveChangesAsync();

            return RedirectToAction("DetalleCliente");
        }

    }
}
