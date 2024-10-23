using System;
using System.ComponentModel.DataAnnotations;

namespace Dotnet5api.Models
{
//     [Table("m_category")]  // Pastikan nama tabelnya sesuai dengan yang ada di database SQL Server
    public class General
    {
        [Key]
        public long id_general { get; set; }

        [Required]
        [MaxLength(15)]
        public string kode_general { get; set; }

        [Required]
        [MaxLength(250)]
        public string nama_general { get; set; }

        [Required]
        [MaxLength(50)]
        public string group_general { get; set; }

        [MaxLength(100)]
        public string note_general { get; set; }

        public int general_parent_id_1 { get; set; }

        public int general_parent_id_2 { get; set; }

        public int general_parent_id_3 { get; set; }

        [Required]
        [MaxLength(10)]
        public string active { get; set; }
    }
}