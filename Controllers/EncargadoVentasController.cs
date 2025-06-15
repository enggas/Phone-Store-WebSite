using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PhoneStore_Website.Data;

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
        public ActionResult Index()
        {
            return View();
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
