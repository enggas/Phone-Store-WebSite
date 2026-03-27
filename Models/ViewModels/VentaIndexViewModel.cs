namespace PhoneStore_Website.Models.ViewModels;
using ClienteModel=PhoneStore_Website.Models.Cliente;

public class VentaIndexViewModel
{
    public required ClienteModel Cliente { get; set; }

    public List<Producto> Productos { get; set; } = new();

    public List<Carrito> Carrito { get; set; } = new();
}

