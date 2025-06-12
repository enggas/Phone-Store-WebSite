

using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PhoneStore_Website.Models
{
    public class Compra
    {

        [Key]
        public int Purchase_Id { get; set; }


        [ForeignKey("Id_Empleado")]
        public required int Id_Empleado { get; set; }
        public Empleado empleado { get; set; } = null!;


        [ForeignKey("Prov_Id")]
        public required int Prov_ID { get; set; }
        public Proveedores proveedores { get; set; } = null!;


        [Required(ErrorMessage = "El Numero de Documento es Requerido")]
        public required String Doc_Num { get; set; }


        [Required(ErrorMessage = "El Tipo de Documento de la Compra es Requerido")]
        public required String Doc_Type { get; set; }


        [Required(ErrorMessage = "El Total de la Compra es Requerido")]
        public required decimal Total { get; set; }


        public ICollection<Det_Compra> Det_Compras { get; set; } = new List<Det_Compra>();

    }
}
