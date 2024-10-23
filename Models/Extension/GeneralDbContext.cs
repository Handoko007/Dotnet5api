using Microsoft.EntityFrameworkCore;
using Dotnet5api.Models;

namespace Dotnet5api.Models  //Data
{
    public class GeneralDbContext : DbContext
    {
        public GeneralDbContext(DbContextOptions<GeneralDbContext> options) : base(options) { }

        // Deklarasi data
     
       public DbSet<General> Generals { get; set; }

       // Jika Anda ingin mendefinisikan primary key secara eksplisit
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // General
            modelBuilder.Entity<General>()
                .HasKey(g => g.id_general);  // Menentukan id_category sebagai primary key
            modelBuilder.Entity<General>()
                .ToTable("m_general"); 

             base.OnModelCreating(modelBuilder);
            
        }      
    }
}