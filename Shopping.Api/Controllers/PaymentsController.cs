using Microsoft.AspNetCore.Mvc;
using Shopping.Contracts.Payments;

namespace Shopping.Api.Controllers;

public class PaymentsController : ControllerBase
{
    [HttpPost("checkout")]
    public async Task<IActionResult> CheckOut (PaymentCheckoutRequest request)
    {
        throw new NotImplementedException();
    }
}