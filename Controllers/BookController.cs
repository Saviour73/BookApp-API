using AutoMapper;
using BookApp.DataLayer;
using BookApp.DTOs.RequestDTOs;
using BookApp.Entities;
using Microsoft.AspNetCore.Mvc;
using System.Linq;

namespace BookApp.Controllers
{

    [ApiController]
    public class BookController : ControllerBase
    {
        private readonly AppDatabaseContext _context;
        private readonly IMapper _mapper;
        public BookController(AppDatabaseContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }


        //To add book to the record
        [HttpPost]
        [Route("addBook")]
        public IActionResult AddBook([FromBody] BookRequestDTO bookdto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            //var book = new Book()
            //{
            //    AuthorId = bookdto.AuthorId,
            //    Title = bookdto.Title,
            //    Quantity = bookdto.Quantity,
            //    Price = bookdto.Price
            //};
            var book = _mapper.Map<Book>(bookdto);
            var AddNewBook = _context.Books.Add(book);
            int isSaved = _context.SaveChanges();
            if (isSaved < 1)
            {
                return BadRequest("Record not saved");
            }
            return Ok(new
            {
                message = "Book added successfully",
                data = book
            }) ;
             
        }


        //To get all book in the record
        [HttpGet]
        [Route("getAllBooks")]
        public IActionResult GetBooks()
        {
            var books = _context.Books.ToList();
            if (books.Count()  > 0)
            {
                return Ok(books);
            }
            return NotFound("No record found");
        }


        //To Get book by Id
        [HttpGet]
        [Route ("getBook/{id}")]
        public IActionResult GetBook(int id)
        {
            var book = _context.Books.Where(x => x.BookId == id).FirstOrDefault();
            if (book == null)
            {
                return NotFound($"Book of id of {id} does not exist");
            }
            return Ok(book);
        }

        //To delete from the record
        [HttpDelete]
        [Route("deleteBook/{id}")]
        public IActionResult DeleteBook(int id)
        {
            var book = _context.Books.Where(x => x.BookId == id).FirstOrDefault();
            if (book == null)
            {
                return BadRequest();
            }
           _context.Books.Remove(book);
            _context.SaveChanges();
            return NoContent();
        }

        //To update book
        [HttpPut]
        [Route("updateBook/{id}")]
        public IActionResult UpdateBook(int id, [FromBody] Book updatedBook)
        {
            var existingBook = _context.Books.FirstOrDefault(x => x.BookId == id);

            if (existingBook == null)
            {
                return NotFound($"Book with ID {id} not found.");
            }

            existingBook.BookId = updatedBook.BookId;
            existingBook.Title = updatedBook.Title;
            existingBook.Author = updatedBook.Author;
            existingBook.Price = updatedBook.Price;
            existingBook.Quantity = updatedBook.Quantity;
            

            _context.SaveChanges(); 

            return Ok(existingBook);
        }


    }
}
