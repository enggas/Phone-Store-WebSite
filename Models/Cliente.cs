using System.ComponentModel.DataAnnotations;

namespace PhoneStore_Website.Models
{
    public class Cliente
    {

        [Key]
        public int Client_Id { get; set; }


        [Required(ErrorMessage = "La Cedula del Cliente es Requerida")]
        public required String Cedula { get; set; }


        [Required(ErrorMessage = "El Nombre Completo del Cliente es Requerido")]
        public required String Client_Fullname { get; set; }

        public required String Gmail { get; set; }

        public required String Pssword { get; set; }

        [Required(ErrorMessage = "El Numero de Celular del Cliente es Requerido")]
        public required String Telephone { get; set; }





    }
}
