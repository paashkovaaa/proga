using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace Book
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
    }
}