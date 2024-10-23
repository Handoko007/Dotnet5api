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
    public class GeneralController : ControllerBase
    {
        private readonly GeneralDbContext _context;
        private readonly ILogger<GeneralController> _logger;

        public GeneralController(GeneralDbContext context, ILogger<GeneralController> logger)
        {
            _context = context;
            _logger = logger;
        }

        // GET: api/master/General
        [HttpGet]
        public async Task<ActionResult<IEnumerable<General>>> GetGeneral()
        {
            // var Generals = await _context.Generals.ToListAsync();

            var sSql = "SELECT * FROM m_general";
            var sqlQuerygen = SharedFunctions.GetGeneral(sSql);
            var Generals = await _context.Generals.FromSqlRaw(sqlQuerygen).ToListAsync();
            // Console.WriteLine(sqlQuerybrg);

            Console.WriteLine("Data dari tabel m_general :");

            foreach (var General in Generals)
            {
                Console.WriteLine($"ID: {General.id_general}, Kode: {General.kode_general}, Nama: {General.nama_general}, Group: {General.group_general}, Note: {General.note_general}, Parent1: {General.general_parent_id_1}, Parent2: {General.general_parent_id_2}, Parent3: {General.general_parent_id_3}, Active: {General.active}");
            }
            return Ok(Generals);
        }

        // GET: api/master/General/5
        [HttpGet("{id_general}")]
        public async Task<ActionResult<General>> GetGeneralById(long id_general)
        {
            var General = await _context.Generals.FindAsync(id_general);
            if (General == null)
            {
                return NotFound();
            }
            
            // Log informasi data yang ditemukan berdasarkan id
            _logger.LogInformation($"Data ditemukan dengan ID: {id_general}");
            
            return Ok(General);
        }

        // POST: api/master/General
        [HttpPost]
        public async Task<ActionResult<General>> PostGeneral(General General)
        {
            // Cek apakah kode_General sudah ada di database
            var existingKodeGeneral = await _context.Generals
                                            .FirstOrDefaultAsync(g => g.kode_general == General.kode_general);
        
            if (existingKodeGeneral != null)
            {
                // Jika kode_General sudah ada, return BadRequest dengan pesan error
                return BadRequest(new { message = $"Kode General '{General.kode_general}' sudah ada." });
            }

            // Cek apakah nama_General sudah ada di database
            var existingNamaGeneral = await _context.Generals
                                                .FirstOrDefaultAsync(g => g.nama_general == General.nama_general);
            
            if (existingNamaGeneral != null)
            {
                // Jika nama_General sudah ada, return BadRequest dengan pesan error
                return BadRequest(new { message = $"Nama General '{General.nama_general}' sudah ada." });
            }

            // Jika kode_General belum ada, lanjutkan untuk menambah data baru
            _context.Generals.Add(General);
            await _context.SaveChangesAsync();

            _logger.LogInformation($"Data baru disimpan dengan ID: {General.id_general}, Kode: {General.kode_general}, Nama: {General.nama_general}, Group: {General.group_general}, Note: {General.note_general}, Parent1: {General.general_parent_id_1}, Parent2: {General.general_parent_id_2}, Parent3: {General.general_parent_id_3}, Active: {General.active}");

            return CreatedAtAction(nameof(GetGeneralById), new { id_general = General.id_general }, General);
        }

        // PUT: api/master/General/5
        [HttpPut("{id_general}")]
        public async Task<IActionResult> PutGeneral(long id_general, General General)
        {
            if (id_general != General.id_general)
            {
                return BadRequest();
            }

            _context.Entry(General).State = EntityState.Modified;
            await _context.SaveChangesAsync();
            return NoContent();
        }

        // DELETE: api/master/General/5
        [HttpDelete("{id_general}")]
        public async Task<IActionResult> DeleteCategory(long id_general)
        {
            var General = await _context.Generals.FindAsync(id_general);
            if (General == null)
            {
                return NotFound();
            }

            _context.Generals.Remove(General);
            await _context.SaveChangesAsync();
            return NoContent();
        }
    }
}