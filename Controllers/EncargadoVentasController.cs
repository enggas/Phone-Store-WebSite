using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PhoneStore_Website.Data;
using PhoneStore_Website.Models;
using PhoneStore_Website.Models.ViewModels;
using PhoneStore_Website.ViewModels;
using System.Text.Json;

public class EncargadoVentasController : Controller
{
    private readonly AplicationDBContext _context;

    public EncargadoVentasController(AplicationDBContext context)
    {
        _context = context;
    }

    // ================================
    // LISTA DE VENTAS
    // ================================

    [HttpGet]
    public IActionResult Sales_Index()
    {
        var ventas = _context.Venta
            .Include(v => v.Empleado)
            .Include(v => v.Cliente)
            .Include(v => v.Tipos_Pago)
            .Include(v => v.Estado_Pago)
            .ToList();

        return View(ventas);
    }


    // ================================
    // SELECCIONAR CLIENTE
    // ================================

    [HttpGet]
    public IActionResult Confirmacion()
    {
        var clientes = _context.Cliente.ToList();
        return View(clientes);
    }

    [HttpPost]
    public IActionResult Confirmacion(int clienteId)
    {
        return RedirectToAction("SeleccionProducto", new { clienteId = clienteId });
    }


    // ================================
    // MOSTRAR PRODUCTOS
    // ================================

    [HttpGet]
    public IActionResult SeleccionProducto(int clienteId)
    {
        var cliente = _context.Cliente
            .FirstOrDefault(c => c.Client_Id == clienteId);

        if (cliente == null)
            return NotFound();

        var productos = _context.Producto.ToList();

        var carritoJson = HttpContext.Session.GetString("CarritoVenta");

        List<Carrito> carrito = string.IsNullOrEmpty(carritoJson)
            ? new List<Carrito>()
            : JsonSerializer.Deserialize<List<Carrito>>(carritoJson) ?? new List<Carrito>();

        var model = new VentaIndexViewModel
        {
            Cliente = cliente,
            Productos = productos,
            Carrito = carrito
        };

        return View(model);
    }


    // ================================
    // AGREGAR PRODUCTO AL CARRITO
    // ================================

    [HttpPost]
    public IActionResult AgregarProductoVenta(int productoId, int cantidad, int clienteId)
    {
        var carritoJson = HttpContext.Session.GetString("CarritoVenta");

        List<Carrito> carrito;

        if (carritoJson == null)
            carrito = new List<Carrito>();
        else
            carrito = JsonSerializer.Deserialize<List<Carrito>>(carritoJson!)!;

        var producto = _context.Producto
            .FirstOrDefault(p => p.Prod_Id == productoId);

        if (producto == null)
            return BadRequest("Producto no encontrado");

        var existente = carrito.FirstOrDefault(p => p.Prod_Id == productoId);

        if (existente != null)
        {
            existente.Cantidad += cantidad;
        }
        else
        {
            carrito.Add(new Carrito
            {
                Prod_Id = producto.Prod_Id,
                Nombre = producto.Prod_Name,
                Precio = producto.Sale_Price,
                Cantidad = cantidad
            });
        }

        HttpContext.Session.SetString("CarritoVenta",
            JsonSerializer.Serialize(carrito));

        return RedirectToAction("SeleccionProducto", new { clienteId });
    }


    // ================================
    // VER CARRITO
    // ================================

    public IActionResult CarritoVenta()
    {
        var carritoJson = HttpContext.Session.GetString("CarritoVenta");

        if (carritoJson == null)
            return View(new List<Carrito>());

        var carrito = JsonSerializer.Deserialize<List<Carrito>>(carritoJson);

        return View(carrito);
    }


    // ================================
    // REALIZAR COMPRA
    // ================================
    /*
    [HttpPost]
    public IActionResult RealizarCompra(int clienteId)
    {
        var carritoJson = HttpContext.Session.GetString("CarritoVenta");

        if (string.IsNullOrEmpty(carritoJson))
            return RedirectToAction("Sales_Index");

        var carrito = JsonSerializer.Deserialize<List<Carrito>>(carritoJson);

        var venta = new Venta
        {
            Cliente_Id = clienteId,
            Fecha = DateTime.Now
        };

        _context.Venta.Add(venta);
        _context.SaveChanges();

        foreach (var item in carrito)
        {
            var detalle = new Det_Venta
            {
                Venta_Id = venta.Venta_Id,
                Prod_Id = item.Prod_Id,
                Cantidad = item.Cantidad,
                Precio = item.Precio
            };

            _context.Det_Venta.Add(detalle);
        }

        _context.SaveChanges();

        HttpContext.Session.Remove("CarritoVenta");

        return RedirectToAction("Factura", new { id = venta.Venta_Id });
    }


    // ================================
    // FACTURA
    // ================================

    [HttpGet]
    public IActionResult Factura(int id)
    {
        var venta = _context.Venta
            .Include(v => v.Cliente)
            .Include(v => v.Det_Venta)
            .ThenInclude(d => d.Producto)
            .FirstOrDefault(v => v.Venta_Id == id);

        if (venta == null)
            return NotFound();

        return View(venta);
    }
    */
}
