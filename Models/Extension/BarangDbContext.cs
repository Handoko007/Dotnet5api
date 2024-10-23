using Microsoft.EntityFrameworkCore;
using Dotnet5api.Models;

namespace Dotnet5api.Models  //Data
{
    public class BarangDbContext : DbContext
    {
        public BarangDbContext(DbContextOptions<BarangDbContext> options) : base(options) { }

        // Deklarasi data
     
       public DbSet<Barang> Barangs { get; set; }

       // Jika Anda ingin mendefinisikan primary key secara eksplisit
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // Barang
            modelBuilder.Entity<Barang>()
                .HasKey(b => b.id_brg);  // Menentukan id_category sebagai primary key
            modelBuilder.Entity<Barang>()
                .ToTable("m_barang"); 

             base.OnModelCreating(modelBuilder);
            
        }      
    }
}