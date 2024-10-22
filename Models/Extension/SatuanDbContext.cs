using Microsoft.EntityFrameworkCore;
using Dotnet5api.Models;

namespace Dotnet5api.Models  //Data
{
    public class SatuanDbContext : DbContext
    {
        public SatuanDbContext(DbContextOptions<SatuanDbContext> options) : base(options) { }

        // Deklarasi data
       public DbSet<Satuan> Satuans { get; set; }
       public DbSet<kategori> kategoris { get; set; }

       // Jika Anda ingin mendefinisikan primary key secara eksplisit
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // Satuan
            modelBuilder.Entity<Satuan>()            
                .HasKey(s => s.id_unit);  // Definisikan id_unit sebagai primary key

            modelBuilder.Entity<Satuan>()
                .ToTable("m_satuan");    // Ganti dengan nama tabel yang sesuai
            
            base.OnModelCreating(modelBuilder);


            // // Kategori
            // modelBuilder.Entity<kategori>()
            //     .HasKey(c => c.id_kategori);  // Menentukan id_category sebagai primary key
            // modelBuilder.Entity<kategori>()
            //     .ToTable("m_kategori"); 
            
        }      
    }

    //  public DbSet<m_satuan> m_satuans { get; set; }

    // // If your table name is not "Satuans", you can specify the table name explicitly
    //     protected override void OnModelCreating(ModelBuilder modelBuilder)
    //     {
    //         base.OnModelCreating(modelBuilder);
            
    //         // If the table name in SQL Server is "m_satuan"
    //         modelBuilder.Entity<Satuan>().ToTable("m_satuan");

    //         // Memanggil base class untuk memastikan konfigurasi dasar tidak hilang
    //         base.OnModelCreating(modelBuilder); // Memanggil konfigurasi yang sudah ada di DbContext
    //     }

    //      public class ApplicationDbContext : DbContext
    // {
    //     // public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) { }

    //    public DbSet<Satuan> Satuans { get; set; }

    // }

}