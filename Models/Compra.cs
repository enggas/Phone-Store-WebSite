

using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PhoneStore_Website.Models
{
    [Table("Compra")]
    public class Compra
    {

        [Key]
        public int Purchase_Id { get; set; }


        [ForeignKey(nameof(empleado))]
        public required int Id_Empleado { get; set; }
        public Empleado? empleado { get; set; }

        [ForeignKey(nameof(proveedores))]
        public required int Prov_ID { get; set; }
        public Proveedores? proveedores { get; set; }



        [Required(ErrorMessage = "El Numero de Documento es Requerido")]
        public required String Doc_Num { get; set; }


        [Required(ErrorMessage = "El Tipo de Documento de la Compra es Requerido")]
        public required String Doc_Type { get; set; }


        [Required(ErrorMessage = "El Total de la Compra es Requerido")]
        public required decimal Total { get; set; }

        [DataType(DataType.Date)]
        public DateTime? Reg_Date { get; set; }

        public ICollection<Det_Compra> Det_Compras { get; set; } = new List<Det_Compra>();

    }
}
