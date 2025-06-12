using System.Diagnostics;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PhoneStore_Website.Data;
using PhoneStore_Website.Models;

namespace PhoneStore_Website.Controllers
{
    public class HomeController : Controller
    {
        private readonly AplicationDBContext _context;

        public HomeController(AplicationDBContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<IActionResult> Index()
        {
            return View(await _context.Producto.ToListAsync());
        }


        [HttpGet]
        public async Task<IActionResult> Lista_Producto()
        { 
            var productosconmarca = await _context.Producto
                .Include(p => p.Marca)
                .ToListAsync();

            return View(productosconmarca);
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
