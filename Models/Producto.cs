
using System.ComponentModel.DataAnnotations;
using System.Timers;

namespace PhoneStore_Website.Models
{
    public class Producto
    {

        [Key] 
        public int Prod_Id { get; set; }


        [Required(ErrorMessage = "El Codigo del Producto es Requerido")]
        public required String Prod_Cod { get; set; }


        [Required(ErrorMessage = "El Nombre del Producto es Requerido")]
        public required String Prod_Name { get; set; }


        [Required(ErrorMessage = "La Descripcion del Producto es Requerida")]
        public required String Prod_Descripcion { get; set; }


        [Required(ErrorMessage = "La Marca del Producto es Requerida")]
        public required int Id_Marca { get; set; }
        public Marca Marca { get; set; } = null!;


        [Required(ErrorMessage = "El Stock Disponible del Producto es Requerido")]
        public required int Prod_Stock { get; set; }


        [Required(ErrorMessage = "El Precio de Compra del Producto es Requerido")]
        public required decimal Purchase_Price { get; set; }


        [Required(ErrorMessage = "El Precio de Compra del Producto es Requerido")]
        public required decimal Sale_Price { get; set; }


        [Required(ErrorMessage = "El Estado del Producto es Requerido")]
        public required bool Prod_Estado { get; set; }

        [Required(ErrorMessage = "La Imagen del Producto es Requerida")]
        public required String Prod_Imagen { get; set; }




        public ICollection<Det_Compra> Det_Compras { get; set; } = new List<Det_Compra>();

    }
}
