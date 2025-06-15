using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PhoneStore_Website.Models
{
    public class Empleado
    {

        [Key]
        public int Id_Empleado { get; set; }


        [Required(ErrorMessage = "La Cedula es Requerida")]
        public required String Cedula { get; set; }


        [Required(ErrorMessage = "El Nombre es Requerido")]
        public required String Employee_Fullname { get; set; }


        [Required(ErrorMessage = "El Gmail es Requerido")]
        public required String Gmail { get; set; }


        [Required(ErrorMessage = "La Contraseña es Requerido")]
        public required String Pssword { get; set; }
        


        [Required(ErrorMessage = "El Rol del Empleado es Requerido")]
        public required int Role_Id { get; set; }


        [Required(ErrorMessage = "El Estado del Empleado es Requerido")]
        public required bool User_State { get; set; }

        public ICollection<Venta> Ventas { get; set; } = new List<Venta>();
        public ICollection<Compra> Compras { get; set; } = new List<Compra>();



    }
}
