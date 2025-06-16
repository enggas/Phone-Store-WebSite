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

            modelBuilder.Entity<Det_Compra>()
                .ToTable("Det_Compra");  // Ya lo tienes en el modelo, pero no está de más aquí también.

            modelBuilder.Entity<Det_Compra>()
                .HasOne(dc => dc.compra)
                .WithMany(c => c.Det_Compras)
                .HasForeignKey(dc => dc.Purchase_Id)
                .OnDelete(DeleteBehavior.Restrict); // Opcional, para evitar cascadas no deseadas.

            modelBuilder.Entity<Det_Compra>()
                .HasOne(dc => dc.producto)
                .WithMany(p => p.Det_Compras)
                .HasForeignKey(dc => dc.Prod_Id)
                .OnDelete(DeleteBehavior.Restrict);

            // Aquí puedes agregar otras configuraciones que ya tengas

            base.OnModelCreating(modelBuilder);
        }







    }
}
