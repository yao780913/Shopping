using Microsoft.AspNetCore.Mvc;
using Shopping.Contracts.Carts;

namespace Shopping.Api.Controllers;

[ApiController]
[Route("[controller]")]
public class CartsController : ApiController
{
    [HttpGet("{cartId}")]
    [ProducesResponseType<GetCartDetailResponse>(200)]
    public Task<IActionResult> GetCart(string cartId)
    {
        throw new NotImplementedException();
    }
    
    [HttpPost]
    [ProducesResponseType<CreateCartResponse>(201)]
    public Task<IActionResult> CreateCart([FromBody] CreateCartRequest request)
    {
        throw new NotImplementedException();
    }
}