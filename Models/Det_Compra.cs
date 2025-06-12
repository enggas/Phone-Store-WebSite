
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PhoneStore_Website.Models
{
    public class Det_Compra
    {

        [Key]
        public int Purc_Det_Id { get; set; }


        [ForeignKey("Purchase_Id")]
        public required int Purchase_Id { get; set; }
        public Compra compra { get; set; } = null!;



        [ForeignKey("Prod_Id")]
        public required int Prod_Id { get; set; }
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
