// using System;
// using System.Collections.Generic;
// using System.Linq;
// using System.Threading.Tasks;
// using Microsoft.AspNetCore.Mvc;
// using Microsoft.EntityFrameworkCore;
// using Microsoft.Extensions.Logging;
// using Dotnet5api.Models;
// using Dotnet5api.Helpers;  // Pastikan SharedFunctions diimport

// namespace Dotnet5api.Controllers
// {
//     [Route("api/[controller]")]
//     [ApiController]
//     public class CategoryController : ControllerBase
//     {
//         private readonly ApplicationDbContext _context;
//         private readonly ILogger<CategoryController> _logger;

//         public CategoryController(ApplicationDbContext context, ILogger<CategoryController> logger)
//         {
//             _context = context;
//             _logger = logger;
//         }

//         // GET: api/category
//         [HttpGet]
//         public async Task<ActionResult<IEnumerable<Category>>> GetCategories()
//         {
//             // var categories = await _context.Categories.ToListAsync();

//             var sSql1 = "SELECT * FROM m_category";
//             var sqlQuery1 = SharedFunctions.GetCategories(sSql1);
//             var categories = await _context.categories.FromSqlRaw(sqlQuery1).ToListAsync();

//             // Query raw SQL untuk mengambil data dari tabel m_category
//             // var sqlQuery = "SELECT * FROM m_category";
        
//             // Menggunakan SharedFunctions untuk menjalankan query SQL dan mendapatkan data Category
//             // var categories = await SharedFunctions.GetCategories(_context, sqlQuery);

//             Console.WriteLine("Data dari tabel m_category:");

//             foreach (var Category in Categories)
//         {
//             Console.WriteLine($"ID: {Category.id_category}, Kode: {Category.category_code}, Nama: {Category.category_name}, Note: {Category.category_type}, Active: {Category.active}");
//         }
//             return Ok(categories);
//         }

//         // GET: api/category/5
//         [HttpGet("{id_category}")]
//         public async Task<ActionResult<Category>> GetCategoryById(int id_category)
//         {
//             var Category = await _context.Categories.FindAsync(id_category);
//             if (Category == null)
//             {
//                 return NotFound();
//             }
            
//             // Log informasi data yang ditemukan berdasarkan id
//             _logger.LogInformation($"Data ditemukan dengan ID: {id_category}");
            
//             return Ok(Category);
//         }

//         // POST: api/category
//         [HttpPost]
//         public async Task<ActionResult<Category>> PostCategory(Category category)
//         {
//             _context.Categories.Add(Category);
//             await _context.SaveChangesAsync();
//             _logger.LogInformation($"Data baru disimpan dengan ID: {Category.id_category}");
//             return CreatedAtAction(nameof(GetCategoryById), new { id_category = Category.id_category }, Category);
//         }

//         // PUT: api/category/5
//         [HttpPut("{id_category}")]
//         public async Task<IActionResult> PutCategory(int id_category, Category category)
//         {
//             if (id_category != Category.id_category)
//             {
//                 return BadRequest();
//             }

//             _context.Entry(Category).State = EntityState.Modified;
//             await _context.SaveChangesAsync();
//             return NoContent();
//         }

//         // DELETE: api/category/5
//         [HttpDelete("{id_category}")]
//         public async Task<IActionResult> DeleteCategory(int id_category)
//         {
//             var Category = await _context.Categories.FindAsync(id_category);
//             if (Category == null)
//             {
//                 return NotFound();
//             }

//             _context.Categories.Remove(Category);
//             await _context.SaveChangesAsync();
//             return NoContent();
//         }
//     }
// }