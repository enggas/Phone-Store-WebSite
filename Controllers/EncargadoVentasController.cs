using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PhoneStore_Website.Data;
using PhoneStore_Website.Models;
using PhoneStore_Website.Models.ViewModels;
using System.Text.Json;
using System.Text.RegularExpressions;

namespace PhoneStore_Website.Controllers
{
    public class EncargadoVentasController : Controller
    {

        private readonly AplicationDBContext _context;

        public EncargadoVentasController(AplicationDBContext context)
        {
            _context = context;
        }


        // GET: EmpleadoVentasController
        [HttpGet]
        public ActionResult Sales_Index()
        {
            var ventas = _context.Venta
            .Include(v => v.Empleado)
            .Include(v => v.Cliente)
            .Include(v => v.Tipos_Pago)
            .Include(v => v.Estado_Pago)
            .ToList();

            return View(ventas);

        }


        [HttpPost]
        public IActionResult Confirmacion()
        {
            var clientes = _context.Cliente.ToList();
            return View(clientes);
        }



        [HttpGet]
        public IActionResult SeleccionProducto(int clienteId)
        {
            var cliente = _context.Cliente
                .FirstOrDefault(c => c.Client_Id == clienteId);

            if (cliente == null)
                return NotFound();

            var productos = _context.Producto
                .Where(p => p.Prod_State)
                .ToList();

            var carritoJson = HttpContext.Session.GetString("CarritoVenta");

            List<Carrito>? carrito = string.IsNullOrEmpty(carritoJson)
                ? new List<Carrito>()
                : JsonSerializer.Deserialize<List<Carrito>>(carritoJson);

            var model = new VentaIndexViewModel
            {
                Cliente = cliente,
                Productos = productos,
                Carrito = carrito
            };

            return View(model);
        }

        [HttpPost]
        public IActionResult AgregarProductoVenta(int productoId, int cantidad)
        {

            var carritoJson = HttpContext.Session.GetString("CarritoVenta");

            List<Carrito> carrito;

            if (carritoJson == null)
                carrito = new List<Carrito>();
            else
                carrito = JsonSerializer.Deserialize<List<Carrito>>(carritoJson!)!;

            var producto = _context.Producto
            .FirstOrDefault(p => p.Prod_Id == productoId);

            var existente = carrito.FirstOrDefault(p => p.Prod_Id == productoId);

            if (existente != null)
                existente.Cantidad += cantidad;

            else
                carrito.Add(new Carrito
                {
                    Prod_Id = producto.Prod_Id,
                    Nombre = producto.Prod_Name,
                    Precio = producto.Sale_Price,
                    Cantidad = cantidad
                });

            HttpContext.Session.SetString("CarritoVenta",
                JsonSerializer.Serialize(carrito));

            return RedirectToAction("VentaIndex");
        }

        public IActionResult CarritoVenta()
        {
            var carritoJson = HttpContext.Session.GetString("CarritoVenta");

            if (carritoJson == null)
                return View(new List<Carrito>());

            var carrito = JsonSerializer.Deserialize<List<Carrito>>(carritoJson);

            return View(carrito);
        }



        // GET: EmpleadoVentasController/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: EmpleadoVentasController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: EmpleadoVentasController/Create
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

        // GET: EmpleadoVentasController/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: EmpleadoVentasController/Edit/5
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

        // GET: EmpleadoVentasController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: EmpleadoVentasController/Delete/5
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
