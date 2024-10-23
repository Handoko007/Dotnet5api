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
    public class BarangController : ControllerBase
    {
        private readonly BarangDbContext _context;
        private readonly ILogger<BarangController> _logger;

        public BarangController(BarangDbContext context, ILogger<BarangController> logger)
        {
            _context = context;
            _logger = logger;
        }

        // GET: api/master/Barang
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Barang>>> GetBarang()
        {
            // var Barangs = await _context.Barangs.ToListAsync();

            var sSql = "SELECT * FROM m_barang";
            var sqlQuerybrg = SharedFunctions.GetBarang(sSql);
            var Barangs = await _context.Barangs.FromSqlRaw(sqlQuerybrg).ToListAsync();
            // Console.WriteLine(sqlQuerybrg);

            Console.WriteLine("Data dari tabel m_barang :");

            foreach (var Barang in Barangs)
            {
                Console.WriteLine($"ID: {Barang.id_brg}, Kode: {Barang.kode_brg}, Nama: {Barang.nama_brg}, Type_Brg: {Barang.type_brg}, QTY: {Barang.qty}, Id_Unit: {Barang.id_unit}, id_Sup: {Barang.id_sup}, Active: {Barang.active}");
            }
            return Ok(Barangs);
        }

        // GET: api/master/Barang/5
        [HttpGet("{id_brg}")]
        public async Task<ActionResult<Barang>> GetBarangById(long id_brg)
        {
            var Barang = await _context.Barangs.FindAsync(id_brg);
            if (Barang == null)
            {
                return NotFound();
            }
            
            // Log informasi data yang ditemukan berdasarkan id
            _logger.LogInformation($"Data ditemukan dengan ID: {id_brg}");
            
            return Ok(Barang);
        }

        // POST: api/master/Barang
        [HttpPost]
        public async Task<ActionResult<Barang>> PostBarang(Barang Barang)
        {
            // Cek apakah kode_Barang sudah ada di database
            var existingKodeBarang = await _context.Barangs
                                            .FirstOrDefaultAsync(b => b.kode_brg == Barang.kode_brg);
        
            if (existingKodeBarang != null)
            {
                // Jika kode_Barang sudah ada, return BadRequest dengan pesan error
                return BadRequest(new { message = $"Kode Barang '{Barang.kode_brg}' sudah ada." });
            }

            // Cek apakah nama_Barang sudah ada di database
            var existingNamaBarang = await _context.Barangs
                                                .FirstOrDefaultAsync(b => b.nama_brg == Barang.nama_brg);
            
            if (existingNamaBarang != null)
            {
                // Jika nama_Barang sudah ada, return BadRequest dengan pesan error
                return BadRequest(new { message = $"Nama Barang '{Barang.nama_brg}' sudah ada." });
            }

            // Jika kode_Barang belum ada, lanjutkan untuk menambah data baru
            _context.Barangs.Add(Barang);
            await _context.SaveChangesAsync();

            _logger.LogInformation($"Data baru disimpan dengan ID: {Barang.id_brg}, Kode: {Barang.kode_brg}, Nama: {Barang.nama_brg}, Type_Brg: {Barang.type_brg}, Part_no: {Barang.part_no}, Merk_brg: {Barang.merk_brg}, Note: {Barang.note_brg}, QTY: {Barang.qty}, Id_Unit: {Barang.id_unit}, Berat: {Barang.berat}, id_Sup: {Barang.id_sup}, Active: {Barang.active}");

            return CreatedAtAction(nameof(GetBarangById), new { id_brg = Barang.id_brg }, Barang);
        }

        // PUT: api/master/Barang/5
        [HttpPut("{id_brg}")]
        public async Task<IActionResult> PutBarang(long id_brg, Barang Barang)
        {
            if (id_brg != Barang.id_brg)
            {
                return BadRequest();
            }

            _context.Entry(Barang).State = EntityState.Modified;
            await _context.SaveChangesAsync();
            return NoContent();
        }

        // DELETE: api/master/Barang/5
        [HttpDelete("{id_brg}")]
        public async Task<IActionResult> DeleteCategory(long id_brg)
        {
            var Barang = await _context.Barangs.FindAsync(id_brg);
            if (Barang == null)
            {
                return NotFound();
            }

            _context.Barangs.Remove(Barang);
            await _context.SaveChangesAsync();
            return NoContent();
        }
    }
}