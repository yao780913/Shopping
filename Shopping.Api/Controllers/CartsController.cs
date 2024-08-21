using Microsoft.AspNetCore.Mvc;

namespace Shopping.Api.Controllers;

[ApiController]
[Route("[controller]")]
public class CartsController:ControllerBase
{
    [HttpGet("{cartId}")]
    public Task<IActionResult> GetCart(string cartId)
    {
        throw new NotImplementedException();
    }
    
    [HttpPost("{cartId}/addItem")]
    public Task<IActionResult> AddItemToCart(string cartId, [FromBody] AddItemToCartRequest request)
    {
        throw new NotImplementedException();
    }
    
    [HttpDelete("{cartId}")]
    public Task<IActionResult> ClearCart(string cartId)
    {
        throw new NotImplementedException();
    }
    
    [HttpDelete("{cartId}/items/{cartItemId}")]
    public Task<IActionResult> RemoveItemFromCart(string cartId, string cartItemId)
    {
        throw new NotImplementedException();
    }
}

public class AddItemToCartRequest { }