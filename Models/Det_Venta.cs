using System.ComponentModel.DataAnnotations;

namespace PhoneStore_Website.Models
{
    public class Det_Venta
    {

        [Key]
        public int Det_Sale_Id { get; set; }


        [Required(ErrorMessage = "La Sucursal es Requerida")]
        public required int Sucursal { get; set; }
        public Sucursal sucursal { get; set; }


        [Required(ErrorMessage = "La Id de la Venta es Requerida")]
        public required int Venta_Id { get; set; }
        public Venta venta { get; set; }


        [Required(ErrorMessage = "La Id del Producto es Requerida")]
        public required int Prod_Id { get; set; }
        public Producto Producto { get; set; }


        [Required(ErrorMessage = "El Precio del Producto es Requerido")]
        public required decimal Sale_Price { get; set; }


        [Required(ErrorMessage = "La Cantidad del Producto Comprado es Requerida")]
        public required int Quantity { get; set; }


        [Required(ErrorMessage = "El Subtotal es Requerido")]
        public required decimal Subtotal { get; set; }
        



    }
}
