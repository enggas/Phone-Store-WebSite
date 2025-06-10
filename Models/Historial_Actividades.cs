using System.ComponentModel.DataAnnotations;

namespace PhoneStore_Website.Models
{
    public class Historial_Actividades
    {

        [Key]
        public int Historial_Id { get; set; }


        [Required(ErrorMessage = "La Id del Empleado es Requerida")]
        public required int Empleado { get; set; }
        public Empleado Emp { get; set; }


        [Required(ErrorMessage = "La Descripcion de la Accion es Requerida")]
        public required String Accion { get; set; }


        [Required(ErrorMessage = "La Fecha de la Accion es Requerida")]
        public required DateTime Fecha { get; set; }


        [Required(ErrorMessage = "El Modulo en el que se Realizo la Accion es Requerido")]
        public required String Modulo { get; set; }

    }
}
