namespace PhoneStore_Website.Models.ViewModels.Cliente
{
    public class FacturaViewModel
    {
        public int IdVenta { get; set; }
        public required string ClienteNombre { get; set; }
        public DateTime FechaVenta { get; set; }
        public required string MetodoPago { get; set; }
        public required string Card_Num { get; set; }
        public required List<DetalleFacturaViewModel> Detalles { get; set; }
        public decimal Total { get; set; }
    }

    public class DetalleFacturaViewModel
    {
        public required string NombreProducto { get; set; }
        public decimal Precio { get; set; }
        public int Cantidad { get; set; }
        public decimal Subtotal { get; set; }
    }
}
