using Microsoft.AspNetCore.Mvc;
using Shopping.Contracts.Books;

namespace Shopping.Api.Controllers;

[ApiController]
[Route("[controller]")]
public class BooksController : ApiController
{
    [HttpGet]
    [ProducesResponseType(typeof(ListBooksResponse),200)]
    public async Task<IActionResult> ListBooks (
        [FromQuery] string q,
        [FromQuery] int daysSinceBookReleased,
        [FromQuery] int offset,
        [FromQuery] int limit = 25)
    {
        throw new NotImplementedException();
    }
    
    [HttpGet("{bookId}")]
    [ProducesResponseType(typeof(GetBookDetailResponse), 200)]
    public async Task<IActionResult> GetBookById (string bookId)
    {
        throw new NotImplementedException();
    }
}