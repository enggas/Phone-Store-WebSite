using PhoneStore_Website.Models;
using Microsoft.EntityFrameworkCore;


namespace PhoneStore_Website.Data
{
    public class AplicationDBContext : DbContext
    {

        public AplicationDBContext(DbContextOptions<AplicationDBContext> options) : base(options)
        {



        }
        //Aqui Se Agregan todos los modelos(las tablas de las base de datos)
      


    }
}
