
using System.ComponentModel.DataAnnotations;

namespace PhoneStore_Website.Models
{
    public class Tipos_Pago
    {

        [Key]
        public int Id_Tipo_Pago { get; set; }


        [Required(ErrorMessage = "La Descripcion del Tipo de Pago es Requerida")]
        public required String Descripcion { get; set; }


        public ICollection<Venta> Ventas { get; set; } = new List<Venta>();

    }
}
