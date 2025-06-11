using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
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

        public IActionResult Index()
        {
            return View();
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
