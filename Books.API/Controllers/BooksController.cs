using Books.API.Contracts;
using Books.Application.Services;
using Microsoft.AspNetCore.Mvc;

namespace Books.API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class BooksController : ControllerBase
    {
        private readonly IBooksService _booksService;

        public BooksController(IBooksService booksService)
        {
            _booksService = booksService;
        }
        [HttpGet]
        public async Task<ActionResult<List<BooksResponse>>> GetBooks()
        {
            var books = await _booksService.GetAllBooks();
            var response = books.Select(b => new BooksResponse(b.Id, b.Title, b.Description, b.Price));
            return Ok(response);
        }
        [HttpPost]
        public async Task<ActionResult<Guid>> CreateBook([FromBody] BooksRequest request)
        {
            var (book, error) = Book.Create(
                Guid.NewGuid(),
                request.Title,
                request.Description,
                request.Price);

            if (!string.IsNullOrEmpty(error)) return BadRequest(error);

            var bookId = _booksService.CreateBook(book);
            return Ok(bookId);
        }
        [HttpPut("{id:guid}")]
        public async Task<ActionResult<Guid>> UpdateBook(Guid id, [FromBody] BooksRequest request)
        {
            var bookId = _booksService.UpdateBook(id, request.Title, request.Description, request.Price);
            return Ok(bookId);
        }
        [HttpDelete("{id:guid}")]
        public async Task<ActionResult<Guid>> DeleteBook(Guid id)
        {
            return Ok(_booksService.DeleteBook(id));
        }
    }
}
