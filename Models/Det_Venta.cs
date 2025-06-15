using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PhoneStore_Website.Models
{
    public class Det_Venta
    {

        [Key]
        public int Det_Sale_Id { get; set; }

        
        public required int Sale_Id { get; set; }
        [ForeignKey("Sale_Id")]
        public Venta venta { get; set; } = null!;


        
        public required int Prod_Id { get; set; }
        [ForeignKey("Prod_Id")]
        public Producto Producto { get; set; }= null!;


        [Required(ErrorMessage = "El Precio del Producto es Requerido")]
        public required decimal Sale_Price { get; set; }


        [Required(ErrorMessage = "La Cantidad del Producto Comprado es Requerida")]
        public required int Quantity { get; set; }


        [Required(ErrorMessage = "El Subtotal es Requerido")]
        public required decimal Subtotal { get; set; }
        



    }
}
