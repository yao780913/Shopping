using Microsoft.AspNetCore.Mvc;
using Shopping.Contracts.Carts;

namespace Shopping.Api.Controllers;

public class CartItemsController : ApiController
{
    [HttpPost("{cartId}/items")]
    public Task<IActionResult> AddItemToCart(string cartId, [FromBody] CreateCartItemRequest request)
    {
        throw new NotImplementedException();
    }
    
    [HttpPatch("{cartId}/items/{cartItemId}")]
    public Task<IActionResult> UpdateItemFromCart(string cartId, [FromBody] UpdateCartItemRequest request)
    {
        throw new NotImplementedException();
    }

    
    [HttpDelete("{cartId}/items/{cartItemId}")]
    public Task<IActionResult> RemoveItemFromCart(string cartId, string cartItemId)
    {
        throw new NotImplementedException();
    }

}