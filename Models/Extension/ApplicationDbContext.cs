using Microsoft.EntityFrameworkCore;
using Dotnet5api.Models;

namespace Dotnet5api.Models  //Satuan.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) { }

       public DbSet<Satuan> Satuans { get; set; }

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