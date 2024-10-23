using System;
using System.ComponentModel.DataAnnotations;

namespace Dotnet5api.Models
{
//     [Table("m_barang")]  // Pastikan nama tabelnya sesuai dengan yang ada di database SQL Server
    public class Barang
    {
        [Key]
        public long id_brg { get; set; }

        [Required]
        [MaxLength(50)]
        public string kode_brg { get; set; }

        [Required]
        [MaxLength(250)]
        public string nama_brg { get; set; }

        [Required]
        [MaxLength(15)]
        public string type_brg { get; set; }

        [Required]
        [MaxLength(50)]
        public string part_no { get; set; }

        [Required]
        [MaxLength(15)]
        public string merk_brg { get; set; }

        [Required]
        [MaxLength(250)]
        public string note_brg { get; set; }

        public long qty { get; set; }

        public int id_unit { get; set; }

        public decimal berat { get; set; }

        public int id_sup { get; set; }

        [Required]
        [MaxLength(10)]
        public string active { get; set; }
    }
}