using Grpc.Net.Client;
using Microsoft.AspNetCore.Mvc;
using Payment.gRPC;
using Shopping.Contracts.Payments;

namespace Shopping.Api.Controllers;

public class PaymentsController : ControllerBase
{
    public PaymentsController ()
    {
        var channel = GrpcChannel.ForAddress("https://localhost:5001");
        var client = new Tester.TesterClient(channel);
    }
    [HttpPost("checkout")]
    public async Task<IActionResult> Checkout (PaymentCheckoutRequest request)
    {
        throw new NotImplementedException();
    }
}