using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.OData.Query;
using Microsoft.AspNetCore.OData.Routing.Controllers;
using demo_odata.Models;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.OData.Formatter;
using Microsoft.AspNetCore.OData.Deltas;
using Microsoft.EntityFrameworkCore;

namespace demo_odata.Controllers
{
    public class BooksController : ODataController
    {
        private readonly AppDbContext _db;

        public BooksController(AppDbContext db)
        {
            _db = db;
        }

        [EnableQuery]
        public ActionResult<IQueryable<Book>> Get()
        {
            return Ok(_db.Books.AsQueryable());
        }

        [EnableQuery]
        public ActionResult<Book> Get([FromODataUri] int key)
        {
            var book = _db.Books
                    .Include(b => b.Location)
                    .Include(b => b.Press)
                    .SingleOrDefault(b => b.Id == key);

            if (book == null)
            {
                return NotFound();
            }

            return Ok(book);
        }

        [EnableQuery]
        public async Task<ActionResult<Book>> Post([FromBody] Book book)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            _db.Books.Add(book);
            await _db.SaveChangesAsync();

            return Created(book);
        }

        [EnableQuery]
        public async Task<IActionResult> Patch([FromODataUri] int key, [FromBody] Delta<Book> patch)
        {
            var book = await _db.Books.FindAsync(key);
            if (book == null)
            {
                return NotFound();
            }

            patch.Patch(book);
            await _db.SaveChangesAsync();

            return Updated(book);
        }

        [EnableQuery]
        public async Task<IActionResult> Delete([FromODataUri] int key)
        {
            var book = await _db.Books.FindAsync(key);
            if (book == null)
            {
                return NotFound();
            }

            _db.Books.Remove(book);
            await _db.SaveChangesAsync();

            return NoContent();
        }
    }
}
