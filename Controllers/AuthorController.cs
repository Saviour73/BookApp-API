using BookApp.DataLayer;
using BookApp.DTOs.RequestDTOs;
using BookApp.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;

namespace BookApp.Controllers
{
    [Route("author")]
    public class AuthorController : ControllerBase
    {
        private readonly AppDatabaseContext _context;
        public AuthorController(AppDatabaseContext context)
        {
            _context = context;
        }


        //To add author to the record
        [HttpPost]
        [Route("addAuthor")]
        public IActionResult AddAuthor([FromBody] AuthorRequestDTO authordto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var author = new Author() { AuthorName = authordto.AuthorName };
            var AddNewAuthor = _context.Authors.Add(author);
            int isSaved = _context.SaveChanges();
            if (isSaved < 1)
            {
                return BadRequest("Record not saved");
            }
            return Ok("addnewAuthor Entity");
        }

        [HttpGet]
        [Route("get-all-authors")]
        public async Task<IActionResult> GetAllAuthors()
        {
            var authors = await _context.Authors.Include(a => a.Books).ToListAsync();
            return Ok(authors);

        }
    }
}
