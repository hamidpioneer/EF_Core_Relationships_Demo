using Microsoft.AspNetCore.Mvc;
using WebAPI.Data;
using WebAPI.Data.Dtos;
using WebAPI.Services;

namespace WebAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class BooksController : ControllerBase
    {
        private BooksService _booksServcie;
        public BooksController(BooksService booksServcie)
        {
            _booksServcie = booksServcie;
        }


        [HttpPost]
        [Route("add")]
        public IActionResult Add(BookCreateDto book)
        {
            var data = _booksServcie.Add(book);
            return Ok(data);
        }

        [HttpGet("getAll")]
        public IActionResult GetAll()
        {
            var allBooks = _booksServcie.GetAll();
            return Ok(allBooks);
        }
        
        [HttpGet("get/{bookId}")]
        public ActionResult<BookReadDto> GetById(int bookId)
        {
            var bookById = _booksServcie.GetById(bookId);

            return Ok(bookById);
        }

        [HttpPut("update/{bookId}")]
        public IActionResult UpdateById(int bookId, [FromBody] BookCreateDto book)
        {
            BookReadDto updatedBook = _booksServcie.UpdateById(bookId, book);
            
            if(updatedBook != null)
                return Ok(updatedBook);
            return BadRequest();
        }

        [HttpDelete("delete/{bookId}")]
        public IActionResult DeleteById(int bookId)
        {
            var isDeleted = _booksServcie.DeleteById(bookId);   
            if(isDeleted)
                return NoContent();
            return NotFound();
        }
    }
}
