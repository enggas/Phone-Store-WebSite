
using System.ComponentModel.DataAnnotations;

namespace PhoneStore_Website.Models
{
    public class Det_Compra
    {

        [Key]
        public int Det_Compra_Id { get; set; }


        [Required(ErrorMessage = "El Id de la Compra es Requerido")]
        public required int Purchase_Id { get; set; }
        public Compra compra { get; set; } = null!;



        [Required(ErrorMessage = "El Id del Producto es Requerido")]
        public required int Id_Producto { get; set; }
        public Producto producto { get; set; } = null!;


        [Required(ErrorMessage = "El Precio de Compra del Producto es Requerido")]
        public required decimal Purchase_Price { get; set; }


        [Required(ErrorMessage = "El Precio de Venta del Producto es Requerido")]
        public required decimal Sale_Price { get; set; }


        [Required(ErrorMessage = "La Cantidad del Producto Comprado es Requerida")]
        public required decimal Stock { get; set; }


        [Required(ErrorMessage = "El Total de la Compra del Producto es Requerido")]
        public required decimal Total { get; set; }







    }
}
