using Azure.Messaging.ServiceBus;
using ErrorOr;
using Microsoft.Extensions.Azure;
using Payment.gRPC;
using Shopping.Application.Common.Interfaces;

namespace Shopping.Infrastructure.Payment;

public class PaymentService (
    Cashier.CashierClient cashierClient, 
    IAzureClientFactory<ServiceBusClient> clientFactory) : IPaymentService
{
    private readonly Cashier.CashierClient _cashierClient = cashierClient;
    private readonly ServiceBusClient _serviceBusClient = clientFactory.CreateClient("ServiceBusClient");

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