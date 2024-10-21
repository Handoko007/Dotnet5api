using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Dotnet5api.Models;
using System.Data.SqlClient;

namespace Dotnet5api
{
    public class Program
    {
        public static void Main(string[] args)
        {
            CreateHostBuilder(args).Build().Run();
        }

        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                .ConfigureWebHostDefaults(webBuilder =>
                {
                    webBuilder.UseStartup<Startup>();
                });


    //     static async Task Main(string[] args)
    // {
    //      // Ganti dengan connection string yang sesuai dengan database SQL Server Anda
    //     string connectionString = "Server=localhost;Database=IGB;User Id=sa;Password=aku;";

    //     using (SqlConnection connection = new SqlConnection(connectionString))
    //     {
    //         try
    //         {
    //             // Membuka koneksi
    //             await connection.OpenAsync();
    //             Console.WriteLine("Koneksi ke SQL Server berhasil!");

    //             // Lakukan operasi database, misalnya query
    //             string query = "SELECT COUNT(*) FROM m_satuan";
    //             using (SqlCommand command = new SqlCommand(query, connection))
    //             {
    //                 int rowCount = (int)await command.ExecuteScalarAsync();
    //                 Console.WriteLine($"Jumlah baris dalam tabel: {rowCount}");
    //             }
    //         }
    //         catch (Exception ex)
    //         {
    //             Console.WriteLine("Terjadi kesalahan: " + ex.Message);
    //         }
    //     }
    //     }


     }

                
}
