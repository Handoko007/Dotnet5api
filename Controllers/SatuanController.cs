using System;  // Pastikan ini ada
using Microsoft.Extensions.Logging; // Tambahkan ini untuk menggunakan ILogger
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Dotnet5api.Models;
using Dotnet5api.Helpers;  // Ensure this is included to reference SharedFunctions

[Route("api/Master/[controller]")]
[ApiController]
public class SatuanController : ControllerBase
{
    private readonly SatuanDbContext _context;
    private readonly ILogger<SatuanController> _logger;  // Deklarasikan _logger

    public SatuanController(SatuanDbContext context, ILogger<SatuanController> logger)
    {
        _context = context;
        _logger = logger;
    }


    // GET: api/master/satuan
    [HttpGet()]
    public async Task<ActionResult<IEnumerable<Satuan>>> GetSatuans()     // asli    
    {
        
        // return await _context.Satuans.ToListAsync();     // asli 
        
         // Query raw SQL
        var sSql = "SELECT * FROM m_satuan";
        var sqlQuery = SharedFunctions.GetSatuan(sSql);
        var satuans = await _context.Satuans.FromSqlRaw(sqlQuery).ToListAsync();
        // var result = await Task.Run(() => new SharedSqlConnection().GetDataTable(sqlQuery, "m_satuan"));

        // Menampilkan data ke terminal
        Console.WriteLine("Data dari tabel m_satuan:");
        //  _logger.LogInformation("Data dari tabel m_satuan:");
        foreach (var satuan in satuans)
        {
            Console.WriteLine($"ID: {satuan.id_unit}, Kode: {satuan.kode_unit}, Nama: {satuan.nama_unit}, Note: {satuan.note_unit}, Active: {satuan.active}");
            // _logger.LogInformation($"ID: {satuan.id_unit}, Kode: {satuan.kode_unit}, Nama: {satuan.nama_unit}, Note: {satuan.note_unit}, Active: {satuan.active}");
        }

        return satuans;
               
    }


    // GET: api/master/satuan/5
    [HttpGet("{id_unit}")]
    public async Task<ActionResult<Satuan>> GetSatuanById(long id_unit)
    {
        var satuan = await _context.Satuans.FindAsync(id_unit);

        if (satuan == null)
        {
            return NotFound();
        }

        // Log informasi data yang ditemukan berdasarkan id
        _logger.LogInformation($"Data ditemukan dengan ID: {id_unit}");

        return satuan;
    }


    // POST: api/master/satuan
    [HttpPost]
    public async Task<ActionResult<Satuan>> PostSatuan(Satuan satuan)
    {
         // Cek apakah kode_unit sudah ada di database
        var existingKodeUnit = await _context.Satuans
                                         .FirstOrDefaultAsync(s => s.kode_unit == satuan.kode_unit);
    
        if (existingKodeUnit != null)
        {
            // Jika kode_unit sudah ada, return BadRequest dengan pesan error
            return BadRequest(new { message = $"Kode unit '{satuan.kode_unit}' sudah ada." });
        }

        // Cek apakah nama_unit sudah ada di database
        var existingNamaUnit = await _context.Satuans
                                            .FirstOrDefaultAsync(s => s.nama_unit == satuan.nama_unit);
        
        if (existingNamaUnit != null)
        {
            // Jika nama_unit sudah ada, return BadRequest dengan pesan error
            return BadRequest(new { message = $"Nama unit '{satuan.nama_unit}' sudah ada." });
        }

        // Jika kode_unit belum ada, lanjutkan untuk menambah data baru
        _context.Satuans.Add(satuan);
        await _context.SaveChangesAsync();

         // Setelah data disimpan, log informasi
        _logger.LogInformation($"Data baru disimpan dengan ID: {satuan.id_unit}");

        return CreatedAtAction(nameof(GetSatuanById), new { id_unit = satuan.id_unit }, satuan);
    }


    // PUT: api/master/satuan/5
    [HttpPut("{id_unit}")]
    public async Task<IActionResult> PutSatuan(long id_unit, Satuan satuan)
    {
        if (id_unit != satuan.id_unit)
        {
            return BadRequest();
        }

        //  // Cek apakah kode_unit sudah ada di database
        // var existingKodeUnit = await _context.Satuans
        //                                  .FirstOrDefaultAsync(s => s.kode_unit == satuan.kode_unit);
    
        // if (existingKodeUnit != null)
        // {
        //     // Jika kode_unit sudah ada, return BadRequest dengan pesan error
        //     return BadRequest(new { message = $"Kode unit '{satuan.kode_unit}' sudah ada." });
        // }

        // // Cek apakah nama_unit sudah ada di database
        // var existingNamaUnit = await _context.Satuans
        //                                     .FirstOrDefaultAsync(s => s.nama_unit == satuan.nama_unit);
        
        // if (existingNamaUnit != null)
        // {
        //     // Jika nama_unit sudah ada, return BadRequest dengan pesan error
        //     return BadRequest(new { message = $"Nama unit '{satuan.nama_unit}' sudah ada." });
        // }


        _context.Entry(satuan).State = EntityState.Modified;
        await _context.SaveChangesAsync();

        return NoContent();
    }


    // DELETE: api/master/satuan/5
    [HttpDelete("{id_unit}")]
    public async Task<IActionResult> DeleteSatuan(long id_unit)
    {
        var satuan = await _context.Satuans.FindAsync(id_unit);
        if (satuan == null)
        {
            return NotFound();
        }

        _context.Satuans.Remove(satuan);
        await _context.SaveChangesAsync();

        return NoContent();
    }
}