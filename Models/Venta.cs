using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PhoneStore_Website.Models
{
    public class Venta
    {

        [Key]
        public int Sale_Id { get; set; }


        
        public int? Id_Empleado { get; set; }
        [ForeignKey("Id_Empleado")]
        public Empleado Empleado { get; set; } = null!;


        
        public required int Client_Id { get; set; }
        [ForeignKey("Client_Id")]
        public Cliente Cliente { get; set; } = null!;


        [Required(ErrorMessage = "El Tipo de Pago es Requerido")]

        public required int Id_Tipo_Pago { get; set; }
        [ForeignKey("Id_Tipo_Pago")]
        public Tipos_Pago Tipos_Pago { get; set; } = null!;



        [Required(ErrorMessage = "El Estado del Pago es Requerido")]
        public required int Id_Estado_Pago { get; set; }
        [ForeignKey("Id_Estado_Pago")]
        public Estado_Pago Estado_Pago { get; set; } = null!;


        public required String Card_Num { get; set; }

        [Required(ErrorMessage = "El Monto a Pagar es Requerido")]
        public required decimal Pay_Amount { get; set; }


        [Required(ErrorMessage = "El Monto de Cambio es Requerido")]
        public required decimal Change_Amount { get; set; }


        [Required(ErrorMessage = "El Total a Pagar es Requerido")]
        public required decimal Total_Amount { get; set; }

        public DateTime Reg_Date { get; set; }


        public ICollection<Det_Venta> Det_Venta { get; set; } = new List<Det_Venta>();
    }
}
