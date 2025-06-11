using System.ComponentModel.DataAnnotations;

namespace PhoneStore_Website.Models
{
    public class Proveedores
    {

        [Key]
        public int Prov_Id { get; set; }


        [Required(ErrorMessage = "El Documento es Requerido")]
        public required String Document { get; set; }


        [Required(ErrorMessage = "El Nombre del Proveedor es Requerido")]
        public required String Prov_Name { get; set; }


        [Required(ErrorMessage = "El Gmail es Requerido")]
        public required String Gmail { get; set; }


        [Required(ErrorMessage = "El Numero de Telefono del Proveedor es Requerido")]
        public required String Telephone { get; set; }


        [Required(ErrorMessage = "La Direccion del Proveedor es Requerida")]
        public required String Prov_Address { get; set; }


        [Required(ErrorMessage = "El Estado del Proveedor es Requerido")]
        public required bool Prov_State { get; set; }


        public ICollection<Compra> Compras { get; set; } = new List<Compra>();
    }
}
