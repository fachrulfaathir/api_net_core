using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using testing_net_api.Models;

namespace testing_net_api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BooksController : ControllerBase
    {
        static private List<Book> books = new List<Book>
        {
             new Book
                {
                    Id = 1,
                    Title = "Clean Code",
                    Author = "Robert C. Martin",
                    YearPblished = 2008
                },
                new Book
                {
                    Id = 2,
                    Title = "The Pragmatic Programmer",
                    Author = "Andrew Hunt & David Thomas",
                    YearPblished = 1999
                },
                new Book
                {
                    Id = 3,
                    Title = "Design Patterns",
                    Author = "Erich Gamma, Richard Helm, Ralph Johnson, John Vlissides",
                    YearPblished = 1994
                }
        };

        [HttpGet]
        public ActionResult <List<Book>> GetBooks()
        {
            return Ok(books);
        }

        [HttpGet("{id}")]
        public ActionResult<Book> GetBookById(int id)
        {
            var book = books.FirstOrDefault(x => x.Id == id);
            if (book == null)
            {
                return NotFound();
            }

            return Ok(book);
        }

        [HttpPost]
        public ActionResult<Book> AddBook (Book newBook)
        {
            if (newBook == null)
                return BadRequest();

            books.Add(newBook);
            return CreatedAtAction(nameof(GetBookById), new {id = newBook.Id}, newBook);
        }

        [HttpPut("{id}")]
        public IActionResult UpdateBook(int id, Book newBook)
        {
            var book = books.FirstOrDefault(x => x.Id == id);
            if (book == null)
            {
                return NotFound();
            }

            book.Id = newBook.Id;
            book.Author = newBook.Author;
            book.Title = newBook.Title;
            book.YearPblished = newBook.YearPblished;

            return NoContent();

        }

        [HttpDelete("{id}")]
        public IActionResult DeleteBook(int id)
        {
            var book = books.FirstOrDefault(x=>x.Id == id);
            if(book == null)
            {
                return NotFound();
            }

            books.Remove(book);

            return NoContent();
        }
    }

}
