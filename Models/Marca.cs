using System.ComponentModel.DataAnnotations;

namespace PhoneStore_Website.Models
{
    public class Marca
    {

        [Key]
        public int Id_Marca { get; set; }


        [Required(ErrorMessage = "El Nombre de la Marca es Requerido")]
        public required String Marca_Name { get; set; }


        [Required(ErrorMessage = "El Estado de la Marca es Requerido")]
        public required bool Marca_State { get; set; }

        public ICollection<Producto> Productos { get; set; } = new List<Producto>();

    }
}
