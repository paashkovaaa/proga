using Microsoft.AspNetCore.Mvc;

namespace booksReviews.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class BookController : ControllerBase
    {
        private readonly ILogger<BookController> _logger;
        public BookController(ILogger<BookController> logger)
        {
            _logger = logger;
        }

        [HttpGet("book")]
        public async Task<IActionResult> Search(string query)
        {
            bookClient client = new bookClient();
            return Ok(await client.SearchBooksAsync(query));
        }
        [HttpPut("book/{title}")]
        public async Task<IActionResult> AddBook(string title)
        {
            bookClient client = new bookClient();
            var book = await client.SearchBooksAsync(title);
            if (book.Items.Count == 0)
            {
                return BadRequest("Could not find book with given ID");
            }
            var volumeInfo = book.Items.First().VolumeInfo;
            Database db = new Database();
            await db.AddBookAsync(volumeInfo, title);
            return Ok();
        }

    }
}