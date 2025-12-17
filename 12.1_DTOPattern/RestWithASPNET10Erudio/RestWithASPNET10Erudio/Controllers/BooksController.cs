using Microsoft.AspNetCore.Mvc;
using RestWithASPNET10Erudio.Data.DTO;
using RestWithASPNET10Erudio.Services;

namespace RestWithASPNET10Erudio.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BooksController : ControllerBase
    {
        private IBooksServices _booksService;
        private readonly ILogger<BooksController> _logger;

        public BooksController(IBooksServices booksService,
            ILogger<BooksController> logger)
        {
            _booksService = booksService;
            _logger = logger;
        }

        [HttpGet]
        public IActionResult Get()
        {
            _logger.LogInformation("Getting all books");
            return Ok(_booksService.FindAll());
        }

        [HttpGet("{id}")]
        public IActionResult Get(long id)
        {
            _logger.LogInformation("Getting book with id {Id}", id);

            var book = _booksService.FindById(id);
            if (book == null)
            {
                _logger.LogWarning("Book with id {Id} not found", id);
                return NotFound();
            }
            return Ok(book);
        }

        [HttpPost]
        public IActionResult Post([FromBody] BooksDTO books)
        {
            _logger.LogInformation("Creating a new book {title}", books.Title);

            var createdBook = _booksService.Create(books);
            if (createdBook == null)
            {
                _logger.LogError("Error creating book {title}", books.Title);
                return BadRequest();
            }
            return Ok(createdBook);
        }

        [HttpPut]
        public IActionResult Put([FromBody] BooksDTO books)
        {
            _logger.LogInformation("Updating book with id {Id}", books.Id);

            var updatedBook = _booksService.Update(books);
            if (updatedBook == null)
            {
                _logger.LogError("Error updating book with id {Id}", books.Id);
                return BadRequest();
            }

            _logger.LogDebug("Book with id {Id} updated successfully", books.Id);
            return Ok(updatedBook);
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            _logger.LogInformation("Deleting book with id {Id}", id);

            _booksService.Delete(id);
            _logger.LogDebug("Book with id {Id} deleted successfully", id);
            return NoContent();
        }
    }
}
