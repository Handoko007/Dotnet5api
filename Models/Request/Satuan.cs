using System;
using System.ComponentModel.DataAnnotations;

namespace Dotnet5api.Models
{
    public class Satuan
    {
        public int id_unit { get; set; }
        public string kode_unit { get; set; }
        public string nama_unit { get; set; }
        public string note_unit{ get; set; }
        public string active { get; set; }
    }
}