using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PhoneStore_Website.Data;

namespace PhoneStore_Website.Controllers
{
    public class AdministradorController : Controller
    {

        private readonly AplicationDBContext _context;

        public AdministradorController(AplicationDBContext context)
        {
            _context = context;
        }

        [HttpGet]
        public ActionResult Admin_Index()
        {
            var empleados = _context.Empleado.ToList();
            return View(empleados);
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
