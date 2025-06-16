using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace PhoneStore_Website.ViewModels
{
    public class RegistrarCompraViewModel
    {
        [Required(ErrorMessage = "Debe seleccionar un proveedor")]
        [Display(Name = "Proveedor")]
        public int Prov_ID { get; set; }

        [Required(ErrorMessage = "Debe seleccionar un empleado")]
        [Display(Name = "Empleado")]
        public int Id_Empleado { get; set; }

        [Required]
        [Display(Name = "Número Documento")]
        public string Doc_Num { get; set; } = string.Empty;

        [Required]
        [Display(Name = "Tipo Documento")]
        public string Doc_Type { get; set; } = string.Empty;

        [Required]
        [Range(0.01, double.MaxValue, ErrorMessage = "El total debe ser mayor que cero.")]
        public decimal Total { get; set; }

        public List<ProductoCompraDetalle> ProductosSeleccionados { get; set; } = new();
    }

    public class ProductoCompraDetalle
    {
        public int ProductoId { get; set; }

        public string ProductoNombre { get; set; } = string.Empty;

        public decimal PrecioCompra { get; set; }

        public decimal PrecioVenta { get; set; }

        [Required]
        [Range(0, int.MaxValue, ErrorMessage = "La cantidad debe ser 0 o mayor.")]
        public int Cantidad { get; set; }

        public decimal Subtotal => Cantidad * PrecioCompra;
    }
}
