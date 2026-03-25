using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PhoneStore_Website.Data;
using PhoneStore_Website.Models;

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
        public IActionResult Confirmacion(Cliente cliente)
        {
            if (!ModelState.IsValid)
                return View(cliente);

            var clienteExistente = _context.Cliente.FirstOrDefault(c => c.Client_Id == cliente.Client_Id);

            if (clienteExistente == null)
            {
                TempData["MensajeError"] = "No se Encontro el Cliente Seleccionado";
                return View(cliente);
            }

            return RedirectToAction("Sales_Index");
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
