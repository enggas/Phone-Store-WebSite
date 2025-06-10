using System.ComponentModel.DataAnnotations;

namespace PhoneStore_Website.Models
{
    public class Abonos
    {

        [Key]
        public int Abono_Id { get; set; }


        [Required(ErrorMessage = "La Id de la Venta es Requerida")]
        public required int Sale_Id { get; set; }
        public Venta venta { get; set; } = null!;


        [Required(ErrorMessage = "El Monto del Abono es Requerido")]
        public required decimal Abono_Amount { get; set; }


        [Required(ErrorMessage = "La Fecha del Abono es Requerida")]
        public required DateTime Abono_Date { get; set; }


        [Required(ErrorMessage = "El Monto del Abono es Requerido")]
        public required String Observaciones { get; set; }


        [Required(ErrorMessage = "El Id del Empleado es Requerido")]
        public required int Id_Empleado { get; set; }
        public Empleado empleado { get; set; } = null!;



    }
}
