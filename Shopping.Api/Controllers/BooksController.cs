using Microsoft.AspNetCore.Mvc;
using Shopping.Contracts.Books;

namespace Shopping.Api.Controllers;

[ApiController]
[Route("[controller]")]
public class BooksController : ControllerBase
{
    [HttpGet]
    public async Task<IActionResult> ListBooks ()
    {
        throw new NotImplementedException();
    }
    
    [HttpGet("{bookId}")]
    public async Task<IActionResult> GetBookById (string bookId)
    {
        throw new NotImplementedException();
    }

    [HttpPost("Search")]
    public async Task<IActionResult> SearchBooks ([FromBody] SearchBooksRequest request)
    {
        throw new NotImplementedException();
    }
    
    [HttpGet("/authors")]
    public async Task<IActionResult> GetAuthors ([FromQuery] string authorId)
    {
        throw new NotImplementedException();
    }
}