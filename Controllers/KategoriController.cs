using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Dotnet5api.Models;
using Dotnet5api.Helpers;  // Pastikan SharedFunctions diimport

namespace Dotnet5api.Controllers
{
    [Route("api/Master/[controller]")]
    [ApiController]
    public class KategoriController : ControllerBase
    {
        private readonly KategoriDbContext _context;
        private readonly ILogger<KategoriController> _logger;

        public KategoriController(KategoriDbContext context, ILogger<KategoriController> logger)
        {
            _context = context;
            _logger = logger;
        }

        // GET: api/master/kategori
        [HttpGet]
        public async Task<ActionResult<IEnumerable<kategori>>> Getkategori()
        {
            // var categories = await _context.Categories.ToListAsync();

            var sSql = "SELECT * FROM m_kategori";
            var sqlQuery = SharedFunctions.Getkategori(sSql);
            var kategoris = await _context.kategoris.FromSqlRaw(sqlQuery).ToListAsync();

            // Query raw SQL untuk mengambil data dari tabel m_category
            // var sqlQuery = "SELECT * FROM m_category";
        
            // Menggunakan SharedFunctions untuk menjalankan query SQL dan mendapatkan data Category
            // var categories = await SharedFunctions.Getkategori(_context, sqlQuery);

            Console.WriteLine("Data dari tabel m_kategori:");

            foreach (var kategori in kategoris)
        {
            Console.WriteLine($"ID: {kategori.id_kategori}, Kode: {kategori.kode_kategori}, Nama: {kategori.nama_kategori}, Note: {kategori.type_kategori}, Active: {kategori.active}");
        }
            return Ok(kategoris);
        }

        // GET: api/master/kategori/5
        [HttpGet("{id_kategori}")]
        public async Task<ActionResult<kategori>> GetkategoriById(long id_kategori)
        {
            var kategori = await _context.kategoris.FindAsync(id_kategori);
            if (kategori == null)
            {
                return NotFound();
            }
            
            // Log informasi data yang ditemukan berdasarkan id
            _logger.LogInformation($"Data ditemukan dengan ID: {id_kategori}");
            
            return Ok(kategori);
        }

        // POST: api/master/kategori
        [HttpPost]
        public async Task<ActionResult<kategori>> Postkategori(kategori kategori)
        {
            // Cek apakah kode_kategori sudah ada di database
            var existingKodekategori = await _context.kategoris
                                            .FirstOrDefaultAsync(k => k.kode_kategori == kategori.kode_kategori);
        
            if (existingKodekategori != null)
            {
                // Jika kode_kategori sudah ada, return BadRequest dengan pesan error
                return BadRequest(new { message = $"Kode Kategori '{kategori.kode_kategori}' sudah ada." });
            }

            // Cek apakah nama_kategori sudah ada di database
            var existingNamakategori = await _context.kategoris
                                                .FirstOrDefaultAsync(s => s.nama_kategori == kategori.nama_kategori);
            
            if (existingNamakategori != null)
            {
                // Jika nama_kategori sudah ada, return BadRequest dengan pesan error
                return BadRequest(new { message = $"Nama Kategori '{kategori.nama_kategori}' sudah ada." });
            }

            // Jika kode_kategori belum ada, lanjutkan untuk menambah data baru
            _context.kategoris.Add(kategori);
            await _context.SaveChangesAsync();
            _logger.LogInformation($"Data baru disimpan dengan ID: {kategori.id_kategori}");
            return CreatedAtAction(nameof(GetkategoriById), new { id_kategori = kategori.id_kategori }, kategori);
        }

        // PUT: api/master/kategori/5
        [HttpPut("{id_kategori}")]
        public async Task<IActionResult> Putkategori(long id_kategori, kategori kategori)
        {
            if (id_kategori != kategori.id_kategori)
            {
                return BadRequest();
            }

            _context.Entry(kategori).State = EntityState.Modified;
            await _context.SaveChangesAsync();
            return NoContent();
        }

        // DELETE: api/master/kategori/5
        [HttpDelete("{id_kategori}")]
        public async Task<IActionResult> DeleteCategory(long id_kategori)
        {
            var kategori = await _context.kategoris.FindAsync(id_kategori);
            if (kategori == null)
            {
                return NotFound();
            }

            _context.kategoris.Remove(kategori);
            await _context.SaveChangesAsync();
            return NoContent();
        }
    }
}