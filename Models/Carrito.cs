namespace PhoneStore_Website.Models
{
    public class Carrito
    {

        public int Prod_Id { get; set; }
        public string Nombre { get; set; } = "";
        public decimal Precio { get; set; }
        public int Cantidad { get; set; }
        public decimal Subtotal => Precio * Cantidad;
    }
}
