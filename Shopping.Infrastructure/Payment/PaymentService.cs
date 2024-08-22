using ErrorOr;
using Payment.gRPC;
using Shopping.Application.Common.Interfaces;

namespace Shopping.Infrastructure.Payment;

public class PaymentService (Cashier.CashierClient cashierClient) : IPaymentService
{
    private readonly Cashier.CashierClient _cashierClient = cashierClient;

    public Task<ErrorOr<Success>> CheckoutAsync (
        string merchantTradeNo,
        int totalAmount,
        string tradeDesc,
        string itemName,
        string returnUrl)
    {
        throw new NotImplementedException();
    }
}