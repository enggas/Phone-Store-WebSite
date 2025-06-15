
namespace PhoneStore_Website.Models.ViewModels.Cliente
{
    public class FacturaViewModel
    {

        public int VentaId { get; set; }
        public string ClienteNombre { get; set; }
        public string MetodoPago { get; set; }
        public string NumeroTarjeta { get; set; }
        public decimal Total { get; set; }

        public List<DetalleFacturaItem> Items { get; set; } = new();

    }

    public class DetalleFacturaItem
    {
        public string ProductoNombre { get; set; }
        public int Cantidad { get; set; }
        public decimal PrecioUnitario { get; set; }
        public decimal Subtotal { get; set; }
    }

}
