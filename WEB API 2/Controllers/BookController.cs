using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WEB_API_2.Data;
using WEB_API_2.Models;

namespace WEB_API_2.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BookController : ControllerBase
    {
        private readonly ApplicationDbContext _dbContext;

        public BookController(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        [HttpGet]
        public async Task<ActionResult<IEnumerable<book>>> GetBooks()
        {
            if (_dbContext.bookss == null)
            {
                return NotFound();
            }
            return await _dbContext.bookss.ToListAsync();
        }
        [HttpGet("{id}")]
        public async Task<ActionResult<book>> GetBooks(int id)
        {
            if (_dbContext.bookss == null)
            {
                return NotFound();
            }
            var book = await _dbContext.bookss.FindAsync(id);
            if (book == null)
            {
                return NotFound();
            }
            return book;
        }


        [HttpPost]
        public async Task<ActionResult<book>> PostBook(book book)
        {
            _dbContext.bookss.Add(book);
            await _dbContext.SaveChangesAsync();
            return book;
        }
        [HttpPut("{id}")]
        public async Task<IActionResult> PutBooks(int id, book book)
        {
            if (id != book.Id)
            {
                return BadRequest();
            }
            _dbContext.Entry(book).State = EntityState.Modified;
            try
            {
                await _dbContext.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException) when (!BookExists(id))
            {
                return NotFound();
            }
            return NoContent();
        }
        private bool BookExists(long id)
        {
            throw new NotImplementedException();
        }
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteBooks(int id)
        {
            if (_dbContext.bookss == null)
            {
                return NotFound();
            }
            var book = await _dbContext.bookss.FindAsync(id);
            if (book == null)
            {
                return NotFound();
            }
            _dbContext.bookss.Remove(book);
            await _dbContext.SaveChangesAsync();
            return NoContent();
        }
        }
}
