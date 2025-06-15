// PhoneStore_Website/Models/ViewModels/Cliente/ClienteIndexViewModel.cs
using System.Collections.Generic;
using PhoneStore_Website.Models;

namespace PhoneStore_Website.Models.ViewModels.Cliente
{
    public class ClienteIndexViewModel
    {
        public List<Producto>? Productos { get; set; }
        public List<Marca>? Marcas { get; set; }
        public string? SearchString { get; set; }
        public int? SelectedMarcaId { get; set; }
        public bool? EnOfertaFilter { get; set; }
    }
}