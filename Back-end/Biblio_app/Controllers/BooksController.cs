using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Encodings.Web;
using System.Threading.Tasks;
using Biblio_app.Data;
using Biblio_app.Models;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace LibraryApp.Controllers
{

    [Route("api/[controller]")]
    [ApiController]
    
    public class BooksController : ControllerBase
    {
        private readonly LibraryContext _dbContext;

        public BooksController(LibraryContext dbContext)
        {
            _dbContext = dbContext;
        }

        // GET: api/books
        [HttpGet]
        public ActionResult<IEnumerable<Book>> GetBooks()
        {
            // Use parameterized queries to prevent SQL injection
            var books = _dbContext.Books.FromSqlRaw("SELECT * FROM Books").ToList();
            return Ok(books);
        }

        // GET: api/books/{id}
        [HttpGet("{id}")]
        public ActionResult<Book> GetBook(int id)
        {
            // Use parameterized queries to prevent SQL injection
            var book = _dbContext.Books.FromSqlRaw("SELECT * FROM Books WHERE Id = {0}", id).FirstOrDefault();

            if (book == null)
            {
                return NotFound();
            }

            return Ok(book);
        }

        // POST: api/books
        [HttpPost]
        public ActionResult<Book> AddBook(Book book)
        {
            // Sanitize user inputs to prevent XSS attacks
            book.Title = SanitizeInput(book.Title);
            book.Author = SanitizeInput(book.Author);

            _dbContext.Books.Add(book);
            _dbContext.SaveChanges();

            return CreatedAtAction(nameof(GetBook), new { id = book.Id }, book);
        }

        // PUT: api/books/{id}
        [HttpPut("{id}")]
        public IActionResult UpdateBook(int id, Book updatedBook)
        {
            // Use parameterized queries to prevent SQL injection
            var existingBook = _dbContext.Books.Find(id);

            if (existingBook == null)
            {
                return NotFound();
            }

            // Sanitize user inputs to prevent XSS attacks
            updatedBook.Title = SanitizeInput(updatedBook.Title);
            updatedBook.Author = SanitizeInput(updatedBook.Author);

            existingBook.Title = updatedBook.Title;
            existingBook.Author = updatedBook.Author;
            existingBook.PublicationYear = updatedBook.PublicationYear;

            _dbContext.SaveChanges();

            return NoContent();
        }

        // DELETE: api/books/{id}
        [HttpDelete("{id}")]
        public IActionResult DeleteBook(int id)
        {
            var book = _dbContext.Books.Find(id);

            if (book == null)
            {
                return NotFound();
            }

            _dbContext.Books.Remove(book);
            _dbContext.SaveChanges();

            return NoContent();
        }

        // Sanitize user inputs to prevent XSS attacks
        private string SanitizeInput(string input)
        {
            string sanitizedInput = HtmlEncoder.Default.Encode(input);

            return sanitizedInput;
        }
    }
}
