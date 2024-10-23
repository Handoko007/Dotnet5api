using System;
using System.ComponentModel.DataAnnotations;

namespace Dotnet5api.Models
{
//     [Table("m_category")]  // Pastikan nama tabelnya sesuai dengan yang ada di database SQL Server
    public class kategori
    {
        [Key]
        public long id_kategori { get; set; }

        [Required]
        [MaxLength(10)]
        public string kode_kategori { get; set; }

        [Required]
        [MaxLength(100)]
        public string nama_kategori { get; set; }

        [Required]
        [MaxLength(15)]
        public string type_kategori { get; set; }

        public int kategori_parent_id { get; set; }

        public int kategori_level { get; set; }

        public int kategori_tag_type_id { get; set; }

        public int kategori_tag_id { get; set; }

        [MaxLength(100)]
        public string kategori_note { get; set; }

        [Required]
        [MaxLength(10)]
        public string active { get; set; }

        [Required]
        [MaxLength(20)]
        public string created_by { get; set; }

        [Required]
        public DateTime created_at { get; set; }

        [Required]
        [MaxLength(20)]
        public string last_edited_by { get; set; }

        [Required]
        public DateTime last_edited_at { get; set; }
    }
}