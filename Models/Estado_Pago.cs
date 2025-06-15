
using System.ComponentModel.DataAnnotations;

namespace PhoneStore_Website.Models
{
    public class Estado_Pago
    {

        [Key]
        public int Id_Estado_Pago { get; set; }


        [Required(ErrorMessage = "La Descripcion del Esatdo del Pago es Requerida")]
        public required String Descripcion { get; set; }


        public ICollection<Venta> Venta { get; set; } = new List<Venta>();

    }
}
