namespace Shopping.Application.Common.Interfaces;

public interface IPaymentService
{
    public Task<ErrorOr<Success>> CheckoutAsync (
        string merchantTradeNo,
        int totalAmount,
        string tradeDesc,
        string itemName,
        string returnUrl);
}