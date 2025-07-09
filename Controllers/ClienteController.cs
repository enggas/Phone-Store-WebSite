using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PhoneStore_Website.Data;
using PhoneStore_Website.Models;
using PhoneStore_Website.Models.ViewModels.Cliente;
using System.Security.Claims;
using System.Text.Json;
using System.Text.RegularExpressions;

namespace PhoneStore_Website.Controllers
{
    public class ClienteController : Controller
    {
        private readonly AplicationDBContext _context;

        public ClienteController(AplicationDBContext context)
        {
            _context = context;
        }

        private bool ValidarNumeroTarjeta(string cardNumber)
        {
            if (string.IsNullOrWhiteSpace(cardNumber))
                return false;

            var regex = new Regex(@"^\d{4}-\d{4}-\d{4}-\d{4}$");
            return regex.IsMatch(cardNumber);
        }

        [HttpGet]
        public ActionResult Cliente_Index(string search, int? selectedMarcaId, string RangoPrecio)
        {


            var productosQuery = _context.Producto
            .Where(p => p.Prod_State) // Solo productos activos
            .AsQueryable();

            // Filtro de búsqueda por nombre
            if (!string.IsNullOrEmpty(search))
            {
                productosQuery = productosQuery.Where(p => p.Prod_Name.Contains(search));
            }


            // Filtro por marca
            if (selectedMarcaId.HasValue)
            {
                productosQuery = productosQuery.Where(p => p.Id_Marca == selectedMarcaId.Value);
            }

            // Filtro por rango de precio
            if (!string.IsNullOrEmpty(RangoPrecio))
            {
                switch (RangoPrecio)
                {
                    case "0-200":
                        productosQuery = productosQuery.Where(p => p.Sale_Price < 200);
                        break;
                    case "200-500":
                        productosQuery = productosQuery.Where(p => p.Sale_Price >= 200 && p.Sale_Price <= 500);
                        break;
                    case "500-1000":
                        productosQuery = productosQuery.Where(p => p.Sale_Price >= 500 && p.Sale_Price <= 1000);
                        break;
                    case "1000":
                        productosQuery = productosQuery.Where(p => p.Sale_Price > 1000);
                        break;
                }
            }

            var productos = productosQuery.ToList();

            var marcas = _context.Set<Marca>()
                .Where(m => m.Marca_State)
                .ToList();

            var model = new ClienteIndexViewModel
            {
                Productos = productos,
                Marcas = marcas
            };

            return View(model);


        }

        [HttpPost]
        public ActionResult AgregarAlCarrito(int productoId, int cantidad)
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


        [HttpGet]
        public IActionResult Carrito()
        {
            var carritoJson = HttpContext.Session.GetString("Carrito");
            if (string.IsNullOrEmpty(carritoJson))
            {
                return View(new List<Carrito>());
            }
            var carrito = JsonSerializer.Deserialize<List<Carrito>>(carritoJson);
            return View(carrito ?? new List<Carrito>());
        }

        [HttpPost]
        public IActionResult DisminuirCantidad(int productoId)
        {
            var carritoJson = HttpContext.Session.GetString("Carrito");
            if (string.IsNullOrEmpty(carritoJson))
                return RedirectToAction("Carrito");

            var carrito = JsonSerializer.Deserialize<List<Carrito>>(carritoJson) ?? new List<Carrito>();
            var producto = carrito.FirstOrDefault(p => p.Prod_Id == productoId);

            if (producto != null)
            {
                producto.Cantidad--;
                if (producto.Cantidad <= 0)
                {
                    carrito.Remove(producto);
                }
            }

            HttpContext.Session.SetString("Carrito", JsonSerializer.Serialize(carrito));
            return RedirectToAction("Carrito");
        }

        [HttpPost]
        public IActionResult EliminarProducto(int productoId)
        {
            var carritoJson = HttpContext.Session.GetString("Carrito");
            if (string.IsNullOrEmpty(carritoJson))
                return RedirectToAction("Carrito");

            var carrito = JsonSerializer.Deserialize<List<Carrito>>(carritoJson) ?? new List<Carrito>();
            carrito.RemoveAll(p => p.Prod_Id == productoId);

            HttpContext.Session.SetString("Carrito", JsonSerializer.Serialize(carrito));
            return RedirectToAction("Carrito");
        }




        [HttpPost]
        public async Task<IActionResult> RealizarCompra(int Pay_Type, string Card_Num)
        {
            if (!ValidarNumeroTarjeta(Card_Num))
            {
                TempData["Error"] = "El número de tarjeta no es válido. Debe tener el formato ####-####-####-####.";
                return RedirectToAction("Carrito");
            }

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
                TempData["Error"] = "Cliente no registrado.";
                return RedirectToAction("CrearCuenta", "Cuenta");
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

            // 1. Crea la venta
            var venta = new Venta
            {
                Client_Id = cliente.Client_Id,
                Id_Empleado = null,
                Id_Estado_Pago = 1,
                Id_Tipo_Pago = Pay_Type,
                Card_Num = Card_Num ?? "",
                Pay_Amount = carrito.Sum(i => i.Subtotal),
                Total_Amount = carrito.Sum(i => i.Subtotal),
                Change_Amount = 0,
                Det_Venta = new List<Det_Venta>()
            };

            // 2. Agrega los detalles de la venta
            foreach (var item in carrito)
            {
                venta.Det_Venta.Add(new Det_Venta
                {
                    Sale_Id = venta.Sale_Id,
                    Prod_Id = item.Prod_Id,
                    Quantity = item.Cantidad,
                    Sale_Price = item.Precio,
                    Subtotal = item.Subtotal
                });
            }

            _context.Venta.Add(venta);
            await _context.SaveChangesAsync();

            // 3. Actualiza el stock de los productos vendidos
            foreach (var item in carrito)
            {
                var producto = await _context.Producto.FindAsync(item.Prod_Id);
                if (producto != null)
                {
                    producto.Stock -= item.Cantidad;
                    _context.Entry(producto).State = EntityState.Modified;
                }
            }

            await _context.SaveChangesAsync();

            // 4. Limpia el carrito y redirige
            HttpContext.Session.Remove("Carrito");
            TempData["Exito"] = "¡Compra realizada con éxito!";
            return RedirectToAction("Factura", new { id = venta.Sale_Id });


        }

        [HttpGet]
        public async Task<IActionResult> Factura(int id)
        {
            var venta = await _context.Venta
                .Include(v => v.Cliente)
                .Include(v => v.Det_Venta)
                .ThenInclude(d => d.Producto)
                .FirstOrDefaultAsync(v => v.Sale_Id == id);

            if (venta == null)
            {
                return NotFound();
            }

            var facturaVM = new FacturaViewModel
            {
                IdVenta = venta.Sale_Id,
                ClienteNombre = venta.Cliente.Client_Fullname,
                FechaVenta = DateTime.Now, 
                MetodoPago = venta.Id_Tipo_Pago == 1 ? "Tarjeta" : "Efectivo", // Cambia según tu lógica
                Card_Num = venta.Card_Num,
                Total = venta.Total_Amount,
                Detalles = venta.Det_Venta.Select(d => new DetalleFacturaViewModel
                {
                    NombreProducto = d.Producto.Prod_Name,
                    Cantidad = d.Quantity,
                    Precio = d.Sale_Price,
                    Subtotal = d.Subtotal
                }).ToList()
            };

            return View(facturaVM);
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
