using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using PhoneStore_Website.Data;
using PhoneStore_Website.Models;
using PhoneStore_Website.ViewModels;
using System.Security.Claims;

namespace PhoneStore_Website.Controllers
{
    public class EncargadoComprasController : Controller
    {
        private readonly AplicationDBContext _context;

        public EncargadoComprasController(AplicationDBContext context)
        {
            _context = context;
        }

        // 1) Menú principal del encargado de compras
        public IActionResult Purchase_Index()
        {
            return View();
        }

        // 2) Ver lista de proveedores
        public async Task<IActionResult> ListaProveedores()
        {
            var proveedores = await _context.Proveedores.ToListAsync();
            return View(proveedores);
        }

        // GET: HistorialCompras
        public async Task<IActionResult> HistorialCompras()
        {
            var detallesCompras = await _context.Det_Compras
                .Include(dc => dc.producto)
                .Include(dc => dc.compra)
                    .ThenInclude(c => c.empleado)
                .Include(dc => dc.compra)
                    .ThenInclude(c => c.proveedores)
                .ToListAsync();

            if (!detallesCompras.Any())
            {
                ViewBag.Mensaje = "No hay detalles de compras registradas.";
            }

            return View(detallesCompras);
        }


        // GET: Registrar nueva compra
        [HttpGet]
        public async Task<IActionResult> RegistrarCompra()
        {
            var proveedores = await _context.Proveedores.ToListAsync();

            var proveedoresList = new List<SelectListItem>
    {
        new SelectListItem { Value = "", Text = "Seleccionar un proveedor", Selected = true }
    };
            proveedoresList.AddRange(proveedores.Select(p => new SelectListItem
            {
                Value = p.Prov_Id.ToString(),
                Text = p.Prov_Name
            }));

            var empleados = await _context.Empleado
                                  .Where(e => e.Role_Id == 3)
                                  .ToListAsync();

            var empleadosList = new List<SelectListItem>
    {
        new SelectListItem { Value = "", Text = "Seleccionar un empleado", Selected = true }
    };
            empleadosList.AddRange(empleados.Select(e => new SelectListItem
            {
                Value = e.Id_Empleado.ToString(),
                Text = e.Employee_Fullname
            }));

            ViewBag.Proveedores = proveedoresList;
            ViewBag.Empleados = empleadosList;

            var productos = await _context.Producto.ToListAsync();

            var viewModel = new RegistrarCompraViewModel
            {
                ProductosSeleccionados = productos.Select(p => new ProductoCompraDetalle
                {
                    ProductoId = p.Prod_Id,
                    ProductoNombre = p.Prod_Name,
                    PrecioCompra = p.Purchase_Price,
                    PrecioVenta = p.Sale_Price,
                    Cantidad = 0
                }).ToList()
            };

            return View(viewModel);
        }


        // POST: Procesar registro de la compra
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> RegistrarCompra(RegistrarCompraViewModel vm)
        {
            if (!ModelState.IsValid)
            {
                // Recargar dropdowns con la misma lógica
                var proveedores = await _context.Proveedores.ToListAsync();
                var proveedoresList = new List<SelectListItem>
        {
            new SelectListItem { Value = "", Text = "Seleccionar un proveedor" }
        };
                proveedoresList.AddRange(proveedores.Select(p => new SelectListItem
                {
                    Value = p.Prov_Id.ToString(),
                    Text = p.Prov_Name
                }));

                var empleados = await _context.Empleado
                                      .Where(e => e.Role_Id == 3)
                                      .ToListAsync();

                var empleadosList = new List<SelectListItem>
        {
            new SelectListItem { Value = "", Text = "Seleccionar un empleado" }
        };
                empleadosList.AddRange(empleados.Select(e => new SelectListItem
                {
                    Value = e.Id_Empleado.ToString(),
                    Text = e.Employee_Fullname
                }));

                ViewBag.Proveedores = proveedoresList;
                ViewBag.Empleados = empleadosList;

                // Recargar productos en ViewModel para que la vista funcione bien
                var productos = await _context.Producto.ToListAsync();
                vm.ProductosSeleccionados = productos.Select(p => new ProductoCompraDetalle
                {
                    ProductoId = p.Prod_Id,
                    ProductoNombre = p.Prod_Name,
                    PrecioCompra = p.Purchase_Price,
                    PrecioVenta = p.Sale_Price,
                    Cantidad = vm.ProductosSeleccionados?.FirstOrDefault(x => x.ProductoId == p.Prod_Id)?.Cantidad ?? 0
                }).ToList();

                return View(vm);
            }

            // Validar al menos un producto comprado con cantidad > 0
            var productosComprados = vm.ProductosSeleccionados.Where(p => p.Cantidad > 0).ToList();
            if (productosComprados.Count == 0)
            {
                ModelState.AddModelError("", "Debe seleccionar al menos un producto con cantidad mayor a cero.");

                var proveedores = await _context.Proveedores.ToListAsync();
                var proveedoresList = new List<SelectListItem>
        {
            new SelectListItem { Value = "", Text = "Seleccionar un proveedor" }
        };
                proveedoresList.AddRange(proveedores.Select(p => new SelectListItem
                {
                    Value = p.Prov_Id.ToString(),
                    Text = p.Prov_Name
                }));

                var empleados = await _context.Empleado
                                      .Where(e => e.Role_Id == 3)
                                      .ToListAsync();

                var empleadosList = new List<SelectListItem>
        {
            new SelectListItem { Value = "", Text = "Seleccionar un empleado" }
        };
                empleadosList.AddRange(empleados.Select(e => new SelectListItem
                {
                    Value = e.Id_Empleado.ToString(),
                    Text = e.Employee_Fullname
                }));

                ViewBag.Proveedores = proveedoresList;
                ViewBag.Empleados = empleadosList;

                return View(vm);
            }

            // Crear la compra
            var compra = new Compra
            {
                Prov_ID = vm.Prov_ID,
                Id_Empleado = vm.Id_Empleado,
                Doc_Num = vm.Doc_Num,
                Doc_Type = vm.Doc_Type,
                Total = productosComprados.Sum(p => p.PrecioCompra * p.Cantidad),
                Reg_Date = DateTime.Now,
            };

            _context.Compras.Add(compra);
            await _context.SaveChangesAsync();

            // Crear detalle compra y actualizar stock producto
            foreach (var prod in productosComprados)
            {
                var detalle = new Det_Compra
                {
                    Purchase_Id = compra.Purchase_Id,
                    Prod_Id = prod.ProductoId,
                    Stock = prod.Cantidad,
                    Purchase_Price = prod.PrecioCompra,
                    Sale_Price = prod.PrecioVenta,
                    Total = prod.Subtotal
                };
                _context.Det_Compras.Add(detalle);

                // Actualizar stock producto
                var productoDb = await _context.Producto.FindAsync(prod.ProductoId);
                if (productoDb != null)
                {
                    productoDb.Stock += prod.Cantidad;
                    _context.Producto.Update(productoDb);
                }
            }

            await _context.SaveChangesAsync();

            TempData["SuccessMessage"] = "Compra registrada exitosamente.";

            return RedirectToAction("Purchase_Index");
        }

    }
}
