using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Dotnet5api.Models;


// SharedFunctions.cs
namespace Dotnet5api.Helpers  // This should be your project's namespace
{
    public static class SharedFunctions
    {
        // Satuan
        public static string GetSatuan(string sqlQuery)
        {
            return sqlQuery;  // Just return the query string as it is
        }

        // Kategori    
         public static string Getkategori(string sqlQuery)
        {
            return sqlQuery;  // Just return the query string as it is
        }

        // Barang    
         public static string GetBarang(string sqlQuerybrg)
        {
            return sqlQuerybrg;  // Just return the query string as it is
        }
    }
}