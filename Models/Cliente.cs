using System.ComponentModel.DataAnnotations;

namespace PhoneStore_Website.Models
{
    public class Cliente
    {

        [Key]
        public int Cliente_Id { get; set; }


        [Required(ErrorMessage = "La Cedula del Cliente es Requerida")]
        public required String Cedula { get; set; }


        [Required(ErrorMessage = "El Nombre Completo del Cliente es Requerido")]
        public required String Client_Fullname { get; set; }


        [Required(ErrorMessage = "El Gmail del Cliente es Requerido")]
        public required String Gmail { get; set; }


        [Required(ErrorMessage = "El Numero de Celular del Cliente es Requerido")]
        public required String Telephone { get; set; }


        [Required(ErrorMessage = "El Estado del Cliente es Requerido")]
        public required bool Cliente_Estado { get; set; }


        public ICollection<Cuenta_Web> Cuenta_Webs { get; set; } = new List<Cuenta_Web>();

    }
}
