using System;  // Pastikan ini ada
using Microsoft.Extensions.Logging; // Tambahkan ini untuk menggunakan ILogger
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Dotnet5api.Models;

[Route("api/[controller]")]
[ApiController]
public class SatuanController : ControllerBase
{
    private readonly ApplicationDbContext _context;
    private readonly ILogger<SatuanController> _logger;  // Deklarasikan _logger

    public SatuanController(ApplicationDbContext context, ILogger<SatuanController> logger)
    {
        _context = context;
        _logger = logger;
    }

    // GET: api/satuan
    [HttpGet()]
    public async Task<ActionResult<IEnumerable<Satuan>>> GetSatuans()     // asli    
    {
        
        // return await _context.Satuans.ToListAsync();     // asli 

        var satuans = await _context.Satuans.ToListAsync();

        // Menampilkan data ke terminal
        // Console.WriteLine("Data dari tabel m_satuan:");
         _logger.LogInformation("Data dari tabel m_satuan:");
        foreach (var satuan in satuans)
        {
            // Console.WriteLine($"ID: {satuan.id_unit}, Kode: {satuan.kode_unit}, Nama: {satuan.nama_unit}, Note: {satuan.note_unit}, Active: {satuan.active}");
            _logger.LogInformation($"ID: {satuan.id_unit}, Kode: {satuan.kode_unit}, Nama: {satuan.nama_unit}, Note: {satuan.note_unit}, Active: {satuan.active}");
        }

        return satuans;
               
    }

    // GET: api/satuan/5
    [HttpGet("{id_unit}")]
    public async Task<ActionResult<Satuan>> GetSatuanById(int id_unit)
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

    // POST: api/satuan
    [HttpPost]
    public async Task<ActionResult<Satuan>> PostSatuan(Satuan satuan)
    {
        _context.Satuans.Add(satuan);
        await _context.SaveChangesAsync();

         // Setelah data disimpan, log informasi
        _logger.LogInformation($"Data baru disimpan dengan ID: {satuan.id_unit}");

        return CreatedAtAction(nameof(GetSatuanById), new { id_unit = satuan.id_unit }, satuan);
    }

    // PUT: api/satuan/5
    [HttpPut("{id_unit}")]
    public async Task<IActionResult> PutSatuan(int id_unit, Satuan satuan)
    {
        if (id_unit != satuan.id_unit)
        {
            return BadRequest();
        }

        _context.Entry(satuan).State = EntityState.Modified;
        await _context.SaveChangesAsync();

        return NoContent();
    }

    // DELETE: api/satuan/5
    [HttpDelete("{id_unit}")]
    public async Task<IActionResult> DeleteSatuan(int id_unit)
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