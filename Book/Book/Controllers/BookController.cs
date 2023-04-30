using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace Book
{
    [ApiController]
    [Route("api/[controller]")]
    public class BookController : ControllerBase
    {
        private readonly bookClient _client;

        public BookController(bookClient client)
        {
            _client = client;
        }

        [HttpGet("{query}")]
        public async Task<IActionResult> Search(string query)
        {
            var books = await _client.SearchBooksAsync(query);

            if (books != null)
            {
                return Ok(books);
            }
            else
            {
                return NotFound();
            }
        }
    }
}

