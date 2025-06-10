using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.ComponentModel.DataAnnotations;

namespace PhoneStore_Website.Models
{
    public class Sucursal
    {

        [Key]
        public int Id_Sucursal { get; set; }


        [Required(ErrorMessage = "El Nombre de la Sucursal es Requerido")]
        public required String Nombre_Sucursal { get; set; }


        [Required(ErrorMessage = "La Direccion del Proveedor es Requerida")]
        public required String Direccion { get; set; }


        // Relación de navegación (una categoría tiene muchos productos)
        public ICollection<Empleado> Empleados { get; set; } = new List<Empleado>();
        public ICollection<Det_Venta> Det_Ventas { get; set; } = new List<Det_Venta>();


    }
}
