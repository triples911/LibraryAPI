using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using LibraryAPI.Models; // تأكد أن هذا يطابق اسم مشروعك

[Route("api/[controller]")]
[ApiController]
public class LibrariesController : ControllerBase
{
    private readonly AppDbContext _context;

    public LibrariesController(AppDbContext context)
    {
        _context = context;
    }

    // 1. جلب كل البيانات (GET)
    [HttpGet]
    public async Task<ActionResult<IEnumerable<Library>>> GetLibraries()
    {
        return await _context.Libraries.Include(l => l.LibraryAddress).ToListAsync();
    }

    // 2. جلب سجل محدد بالـ ID (GET)
    [HttpGet("{id}")]
    public async Task<ActionResult<Library>> GetLibrary(int id)
    {
        var library = await _context.Libraries.Include(l => l.LibraryAddress).FirstOrDefaultAsync(l => l.Id == id);
        if (library == null) return NotFound();
        return library;
    }

    // 3. إضافة سجل جديد (POST)
    [HttpPost]
    public async Task<ActionResult<Library>> PostLibrary(Library library)
    {
        _context.Libraries.Add(library);
        await _context.SaveChangesAsync();
        return CreatedAtAction(nameof(GetLibrary), new { id = library.Id }, library);
    }

    // 4. حذف سجل (DELETE)
    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteLibrary(int id)
    {
        var library = await _context.Libraries.FindAsync(id);
        if (library == null) return NotFound();
        _context.Libraries.Remove(library);
        await _context.SaveChangesAsync();
        return NoContent();
    }
}