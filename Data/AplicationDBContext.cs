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
        public DbSet<Cliente> Cliente { get; set; }
        public DbSet<Empleado> Empleado { get; set; }
        public DbSet<Marca> Marca { get; set; }
        public DbSet<Producto> Producto { get; set; }
        public DbSet<Compra> Compras { get; set; }
        public DbSet<Det_Compra> Det_Compras { get; set; }
        public DbSet<Tipos_Pago> Tipos_Pagos { get; set; }
        public DbSet<Estado_Pago> Estado_Pagos { get; set; }
        public DbSet<Venta> Venta { get; set; }
        public DbSet<Det_Venta> Det_Venta { get; set; }




        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Producto>()
                .HasOne(p => p.Marca)
                .WithMany(m => m.Productos)
                .HasForeignKey(p => p.Id_Marca);
            base.OnModelCreating(modelBuilder);
        }




    }
}
