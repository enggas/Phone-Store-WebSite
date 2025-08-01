﻿using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PhoneStore_Website.Data;
using PhoneStore_Website.Models;
using System.Text.RegularExpressions;

namespace PhoneStore_Website.Controllers
{
    public class AdministradorController : Controller
    {

        private readonly AplicationDBContext _context;

        public AdministradorController(AplicationDBContext context)
        {
            _context = context;
        }

     
        private bool ValidarCedula(string cedula)
        {
            return Regex.IsMatch(cedula, @"^\d{3}-\d{6}-\d{4}[A-Z]$");
        }


        [HttpGet]
        public async Task<IActionResult> Admin_Index(string? searchString)
        {

            var empleados = from e in _context.Empleado
                            select e;

            if (!string.IsNullOrEmpty(searchString))
            {
                empleados = empleados.Where(e =>
                    e.Employee_Fullname.Contains(searchString) ||
                    e.Gmail.Contains(searchString) ||
                    e.Cedula.Contains(searchString));
            }

            return View(await empleados.ToListAsync());
        }


        [HttpGet]
        public IActionResult GenerarReporte() 
        { 
            return View();

        }

        [HttpGet]
        public IActionResult ConsultarReporte()
        {
            return View();

        }


        [HttpGet]
        public IActionResult CrearEmpleado()
        {
            return View();
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> CrearEmpleado(Empleado empleado)
        {

            bool existe = await _context.Empleado.AnyAsync(e => e.Gmail == empleado.Gmail);
            if (existe)
            {
                ModelState.AddModelError("", "El correo electrónico ya está en uso.");
                return View(empleado);
            }

            if (!ValidarCedula(empleado.Cedula))
            {
                ModelState.AddModelError("Cedula", "La cédula debe tener el formato 000-000000-0000X.");
            }

            if (ModelState.IsValid)
            {
                _context.Empleado.Add(empleado);
                await _context.SaveChangesAsync();
                return RedirectToAction("Admin_Index");
            }

            return View(empleado); 
        }


        [HttpGet]
        public IActionResult EditarEmpleado(int id)
        {
            var empleado = _context.Empleado.FirstOrDefault(e => e.Id_Empleado == id);

            if (empleado == null)
            {
                TempData["MensajeError"] = "Empleado no encontrado.";
                return RedirectToAction("Admin_Index");
            }

            return View(empleado);
        }


        
        [HttpPost]
        public IActionResult EditarEmpleado(Empleado empleado)
        {
            if (!ModelState.IsValid)
                return View(empleado);

            var empleadoExistente = _context.Empleado.FirstOrDefault(e => e.Id_Empleado == empleado.Id_Empleado);

            if (empleadoExistente == null)
            {
                TempData["MensajeError"] = "No se encontró el empleado a actualizar.";
                return View(empleado);
            }

            // Actualizar propiedades
            empleadoExistente.Employee_Fullname = empleado.Employee_Fullname;
            empleadoExistente.Gmail = empleado.Gmail;
            empleadoExistente.Pssword = empleado.Pssword;
            empleadoExistente.Role_Id = empleado.Role_Id;
            empleadoExistente.User_State = empleado.User_State;

            _context.SaveChanges();

            TempData["MensajeExito"] = "Empleado actualizado correctamente.";
            return RedirectToAction("Admin_Index");
        }

        [HttpGet]
        public async Task<IActionResult> DesactivarEmpleado(int id)
        {

            var empleado = await _context.Empleado.FindAsync(id);

            if (empleado == null)
            {
                TempData["MensajeError"] = "Empleado no encontrado.";
                return RedirectToAction("Admin_Index");
            }

            return View(empleado);


        }

        [HttpPost]
        public async Task<IActionResult> ConfirmarDesactivacion(int id)
        {
            var empleado = await _context.Empleado.FindAsync(id);
            if (empleado == null)
            {
                TempData["MensajeError"] = "Empleado no encontrado.";
                return RedirectToAction("DesactivarEmpleado");
            }

            empleado.User_State = false;
            await _context.SaveChangesAsync();

            TempData["MensajeExito"] = "Empleado desactivado correctamente.";
            return RedirectToAction("Admin_Index"); // Puedes cambiar el destino
        }


        [HttpGet]
        public IActionResult ReporteClientes()
        {
            var clientes = _context.Cliente.ToList();
            return View(clientes);
        }

        // Mostrar lista de ventas realizadas
        [HttpGet]
        public IActionResult ReporteVentas()
        {
            var ventas = _context.Venta
                .Include(v => v.Cliente)
                .Include(v => v.Empleado)
                .ToList();
            return View(ventas);
        }

        // Mostrar lista de compras realizadas
        [HttpGet]
        public IActionResult ReporteCompras()
        {
            var compras = _context.Compras
                .Include(c => c.proveedores)
                .Include(c => c.empleado)
                .ToList();
            return View(compras);
        }



        // GET: AdministradorController/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: AdministradorController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: AdministradorController/Create
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

        // GET: AdministradorController/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: AdministradorController/Edit/5
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

        // GET: AdministradorController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: AdministradorController/Delete/5
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
