using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PhoneStore_Website.Models
{
    public class Cuenta_Web
    {

        [Key]
        public int Cuenta_Id { get; set; }


        [ForeignKey("Client_Id")]
        public required int Client_Id { get; set; }
        public Cliente Cliente { get; set; } = null!;


        [Required(ErrorMessage = "El Nombre de Usuario es Requerido")]
        public required String Usuario { get; set; }


        [Required(ErrorMessage = "El Gmail del Usuario es Requerido")]
        public required String Gmail { get; set; }


        [Required(ErrorMessage = "La Contraseña es Requerida")]
        public required String Password { get; set; }


        [Required(ErrorMessage = "El Estado de la Cuenta es Requerido")]
        public required bool Estado { get; set; }





    }
}
