using Desaisiv.Data;
using Desaisiv.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Desaisiv.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BookController : ControllerBase
    {
      private  AppDbContext _db;
        public BookController(AppDbContext db)
        {
            _db = db;
        }
        [HttpGet]
        public ActionResult GetAllBook()
        {
          
            return Ok(_db.Books);
        }
        [HttpGet("id")]
        public ActionResult GetBook(int id)
        {
      if (id == null)
            {
                return BadRequest();

            }
            var data = _db.Books.Find(id);
            if (data == null)
            {
                return NotFound();

            }      
            return Ok(data);    
        }
        [HttpPost]
        public async Task<ActionResult<Book>> PostBook(Book book)
        {

            if (book == null)
            {
                return BadRequest();
            }
            _db.Books.Add(book);
            await _db.SaveChangesAsync();
            return Ok();


        }

        [HttpPut]
        public async Task<ActionResult<Book>> PutBook(Book book)

        {
            if (book == null)
            {
                return BadRequest();

            }
            _db.Books.Update(book); 
            await _db.SaveChangesAsync();
            return Ok();
        }
        [HttpDelete("id")]
        public async Task <ActionResult<Book>> DeleteBook(int id)
        {
            if (id == null)
            {
                return BadRequest();

            }
            var data = _db.Books.Find(id);
            if (data == null)
            {
                return NotFound();

            }
            _db.Books.Remove(data);
          await  _db.SaveChangesAsync();
                  return NoContent();
             
        }

    }
}
