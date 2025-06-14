using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PhoneStore_Website.Data;
using PhoneStore_Website.Models;
using System.Security.Claims;

namespace PhoneStore_Website.Controllers
{
    [Authorize]
    public class ClienteController : Controller
    {
        private readonly AplicationDBContext _context;

        public ClienteController(AplicationDBContext context)
        {
            _context = context;
        }

        // GET: /Cliente/DetalleCliente
        public async Task<IActionResult> DetalleCliente()
        {
            var clientIdClaim = User.FindFirst("Client_Id")?.Value;

            if (string.IsNullOrEmpty(clientIdClaim) || !int.TryParse(clientIdClaim, out int clientId))
            {
                return RedirectToAction("Login", "Login");
            }

            var cliente = await _context.Cliente.FirstOrDefaultAsync(c => c.Client_Id == clientId);

            if (cliente == null)
            {
                return NotFound();
            }

            return View(cliente); // Retorna a DetalleCliente.cshtml
        }

        // GET: /Cliente/EditarCliente
        public async Task<IActionResult> EditarCliente()
        {
            var clientIdClaim = User.FindFirst("Client_Id")?.Value;

            if (string.IsNullOrEmpty(clientIdClaim) || !int.TryParse(clientIdClaim, out int clientId))
            {
                return RedirectToAction("Login", "Login");
            }

            var cliente = await _context.Cliente.FirstOrDefaultAsync(c => c.Client_Id == clientId);

            if (cliente == null)
            {
                return NotFound();
            }

            return View(cliente); // Pronto crearás EditarCliente.cshtml
        }
    }
}
