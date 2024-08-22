using Microsoft.AspNetCore.Mvc;
using Shopping.Contracts.Payments;

namespace Shopping.Api.Controllers;

public class PaymentsController : ApiController
{
    [HttpPost("checkout")]
    public async Task<IActionResult> Checkout (PaymentCheckoutRequest request)
    {
        throw new NotImplementedException();
    }
}