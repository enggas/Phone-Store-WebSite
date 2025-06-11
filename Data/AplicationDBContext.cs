using PhoneStore_Website.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.Identity.Client;


namespace PhoneStore_Website.Data
{
    public class AplicationDBContext : DbContext
    {

        public AplicationDBContext(DbContextOptions<AplicationDBContext> options) : base(options)
        {



        }
        //Aqui Se Agregan todos los modelos(las tablas de las base de datos)

        public DbSet<Proveedores> Proveedores { get; set; }
        public DbSet<Sucursal> sucursales { get; set; }
        public DbSet<Cliente> clientes { get; set; }
        public DbSet<Cuenta_Web> cuenta_Webs { get; set; }
        public DbSet<Empleado> Empleados { get; set; }
        public DbSet<Marca> Marcas { get; set; }
        public DbSet<Producto> Productos { get; set; }
        public DbSet<Compra> Compras { get; set; }
        public DbSet<Det_Compra> Det_Compras { get; set; }
        public DbSet<Tipos_Pago> Tipos_Pagos { get; set; }
        public DbSet<Estado_Pago> Estado_Pagos { get; set; }
        public DbSet<Venta> Ventas { get; set; }
        public DbSet<Det_Venta> Det_Ventas { get; set; }
        public DbSet<Abonos> Abonos { get; set; }
        public DbSet<Historial_Actividades> Historial_Actividades { get; set; }





    }
}
