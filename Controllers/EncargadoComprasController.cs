using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using PhoneStore_Website.Data;
using PhoneStore_Website.Models;
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

        // 3) Ver Historial de todas las compras
        public IActionResult HistorialCompras()
        {

            var compras = _context.Compras
                .Include(c => c.proveedores)
                .Include(c => c.empleado)
                .ToList();

            if (compras.Count == 0)
            {
                ViewBag.Mensaje = "No hay compras registradas aún.";
            }

            return View(compras);
        }

        // 4) Registrar una nueva compra
        // GET: RegistrarCompra
        [HttpGet]
        public IActionResult RegistrarCompra()
        {
            CargarDropdowns();
            return View();
        }

        // POST: RegistrarCompra
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult RegistrarCompra(Compra compra)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    if (!compra.Reg_Date.HasValue)
                    {
                        compra.Reg_Date = DateTime.Now;
                    }

                    _context.Compras.Add(compra);
                    _context.SaveChanges();

                    return RedirectToAction(nameof(Purchase_Index));
                }
                catch (Exception ex)
                {
                    ModelState.AddModelError("", "Error al guardar la compra: " + ex.Message);
                }
            }

            // Si llegamos acá, hubo error o falla de validación
            CargarDropdowns();
            return View(compra);
        }

        private void CargarDropdowns()
        {
            var empleadosEncargados = _context.Empleado
                .Where(e => e.Role_Id == 3)
                .ToList();

            ViewBag.Empleados = new SelectList(empleadosEncargados, "Id_Empleado", "Employee_Fullname");

            var proveedores = _context.Proveedores.ToList();
            ViewBag.Proveedores = new SelectList(proveedores, "Prov_Id", "Prov_Name");
        }

    }
}
