using Microsoft.AspNetCore.Mvc;
using Web_Api;

namespace WebApplication2.Controllers
{
    [Route("api/[controller]")]
    [ApiController]


    public class BookControler : ControllerBase
    {
        private static List<Book> _books = new List<Book>();

        [HttpGet]
        public IActionResult GetAllBooks()
        {
            return Ok(_books);
        }

        [HttpGet("{id}")]
        public IActionResult GetBookById(int id)
        {
            var book = _books.FirstOrDefault(b => b.Id == id);
            if (book == null)
            {
                return NotFound();
            }
            return Ok(book);
        }

        [HttpPost]
        public IActionResult CreateBook(Book book)
        {
            book.Id = _books.Count + 1;
            _books.Add(book);
            return CreatedAtAction(nameof(GetBookById), new { id = book.Id }, book);
        }
        [HttpPut("{id}")]
        public IActionResult UpdateBook(int id, Book updatedBook)
        {
            var book = _books.FirstOrDefault(b => b.Id == id);
            if (book == null)
            {
                return NotFound();
            }
            book.Name = updatedBook.Name;
            book.Author = updatedBook.Author;
            return NoContent();
        }

        // DELETE: api/books/1
        [HttpDelete("{id}")]
        public IActionResult DeleteBook(int id)
        {
            var book = _books.FirstOrDefault(b => b.Id == id);
            if (book == null)
            {
                return NotFound();
            }
            _books.Remove(book);
            return NoContent();
        }


    }
}