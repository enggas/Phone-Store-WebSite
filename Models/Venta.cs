using System.ComponentModel.DataAnnotations;

namespace PhoneStore_Website.Models
{
    public class Venta
    {

        [Key]
        public int Sale_Id { get; set; }


        [Required(ErrorMessage = "La Id del Empleado es Requerida")]
        public required int Id_Empleado { get; set; }
        public Empleado Empleado { get; set; } = null!;


        [Required(ErrorMessage = "La Id del Cliente es Requerida")]
        public required int Id_Cliente { get; set; }
        public Cliente Clientes { get; set; } = null!;


        [Required(ErrorMessage = "El Tipo de Pago es Requerido")]
        public required int Pay_Type { get; set; }


        [Required(ErrorMessage = "El Estado del Pago es Requerido")]
        public required int Sale_Status { get; set; }


        [Required(ErrorMessage = "El Monto a Pagar es Requerido")]
        public required decimal Pay_Amount { get; set; }


        [Required(ErrorMessage = "El Monto de Cambio es Requerido")]
        public required decimal Change_Amount { get; set; }


        [Required(ErrorMessage = "El Total a Pagar es Requerido")]
        public required decimal Total_Amount { get; set; }


        public ICollection<Det_Venta> Det_Ventas { get; set; } = new List<Det_Venta>();
        public ICollection<Abonos> Abonos { get; set; } = new List<Abonos>();
    }
}
