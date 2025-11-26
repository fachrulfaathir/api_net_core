using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using testing_net_api.Context;
using testing_net_api.Models;

namespace testing_net_api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BooksController : ControllerBase
    {
        //static private List<Book> books = new List<Book>
        //{
        //     new Book
        //        {
        //            Id = 1,
        //            Title = "Clean Code",
        //            Author = "Robert C. Martin",
        //            YearPblished = 2008
        //        },
        //        new Book
        //        {
        //            Id = 2,
        //            Title = "The Pragmatic Programmer",
        //            Author = "Andrew Hunt & David Thomas",
        //            YearPblished = 1999
        //        },
        //        new Book
        //        {
        //            Id = 3,
        //            Title = "Design Patterns",
        //            Author = "Erich Gamma, Richard Helm, Ralph Johnson, John Vlissides",
        //            YearPblished = 1994
        //        }
        //};

        private readonly ApplicationDbContext _appContext;

        public BooksController(ApplicationDbContext applicationDb)
        {
            _appContext = applicationDb;
        }

        [HttpGet]
        //public ActionResult <List<Book>> GetBooks()
        //{
        //    //var books = new List<Book>();
        //    return Ok(books);
        //}

        public IActionResult GetBooks()
        {
            var books = _appContext.Books.ToList();
            return Ok(books);
        }

        [HttpGet("{id}")]
        public ActionResult<Book> GetBookById(int id)
        {
            var book = _appContext.Books.FirstOrDefault(x => x.Id == id);
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

            _appContext.Books.Add(newBook);
            _appContext.SaveChanges();
            return CreatedAtAction(nameof(GetBookById), new {id = newBook.Id}, newBook);
        }

        [HttpPut("{id}")]
        public IActionResult UpdateBook(int id, Book newBook)
        {
            var book = _appContext.Books.FirstOrDefault(x => x.Id == id);
            if (book == null)
            {
                return NotFound();
            }

            book.Id = newBook.Id;
            book.Author = newBook.Author;
            book.Title = newBook.Title;
            book.YearPblished = newBook.YearPblished;

            _appContext.SaveChanges();


            return NoContent();

        }

        [HttpDelete("{id}")]
        public IActionResult DeleteBook(int id)
        {
            var book = _appContext.Books.FirstOrDefault(x=>x.Id == id);
            if(book == null)
            {
                return NotFound();
            }

           _appContext.Books.Remove(book);
            _appContext.SaveChanges();

            return NoContent();
        }
    }

}
