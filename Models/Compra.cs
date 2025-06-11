

using System.ComponentModel.DataAnnotations;

namespace PhoneStore_Website.Models
{
    public class Compra
    {

        [Key]
        public int Purchase_Id { get; set; }


        [Required(ErrorMessage = "El Id Del Empleado a cargo de la Compra es Requerido")]
        public required int Id_Empleado { get; set; }
        public Empleado empleado { get; set; } = null!;


        [Required(ErrorMessage = "El Id Del Proveedor es Requerido")]
        public required int Id_Prov { get; set; }
        public Proveedores proveedores { get; set; } = null!;


        [Required(ErrorMessage = "El Documento de la Compra es Requerido")]
        public required String Document { get; set; }


        [Required(ErrorMessage = "El Tipo de Documento de la Compra es Requerido")]
        public required String Type_Document { get; set; }


        [Required(ErrorMessage = "El Total de la Compra es Requerido")]
        public required decimal Total { get; set; }


        public ICollection<Det_Compra> Det_Compras { get; set; } = new List<Det_Compra>();

    }
}
