using Microsoft.EntityFrameworkCore;
using Dotnet5api.Models;

namespace Dotnet5api.Models  //Data
{
    public class KategoriDbContext : DbContext
    {
        public KategoriDbContext(DbContextOptions<KategoriDbContext> options) : base(options) { }

        // Deklarasi data
     
       public DbSet<kategori> kategoris { get; set; }

       // Jika Anda ingin mendefinisikan primary key secara eksplisit
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // Kategori
            modelBuilder.Entity<kategori>()
                .HasKey(k => k.id_kategori);  // Menentukan id_category sebagai primary key
            modelBuilder.Entity<kategori>()
                .ToTable("m_kategori"); 

             base.OnModelCreating(modelBuilder);
            
        }      
    }
}