using Grpc.Core;

namespace Payment.gRPC.Services;

public class PaymentService : Cashier.CashierBase
{
    public override async Task<PaymentReply> Checkout (PaymentRequest request, ServerCallContext context)
    {
        await Task.Delay(2000);
        var result = request.TotalAmount % 3;

        return result switch
        {
            0 => new PaymentReply { Result = PaymentResult.Success, Message = "Payment processed successfully" },
            1 => new PaymentReply { Result = PaymentResult.Failed, Message = "Payment failed" },
            2 => new PaymentReply { Result = PaymentResult.Error, Message = "Payment error" },
            _ => new PaymentReply { Result = PaymentResult.Error, Message = "Payment error" }
        };
    }
}