using Azure.Messaging.ServiceBus;
using Microsoft.Extensions.Azure;
using Shopping.Application.Common.Interfaces;

namespace Shopping.Infrastructure.Messaging;

public class MessagingService (
    IAzureClientFactory<ServiceBusClient> azureClientFactory) : IMessagingService
{
    private readonly ServiceBusClient _serviceBusClient = azureClientFactory.CreateClient("ServiceBusClient");

    public async Task SendMessageAsync (string queueOrTopicName, string context)
    {
        await using var sender = _serviceBusClient.CreateSender(queueOrTopicName);
        
        var message = new ServiceBusMessage(context);
        await sender.SendMessageAsync(message);

    }

    public async Task SendMessagesAsync (string queueOrTopicName, List<string> contexts)
    {
        await using var sender = _serviceBusClient.CreateSender(queueOrTopicName);
        using var messageBatch = await sender.CreateMessageBatchAsync();
        
        foreach (var text in contexts)
        {
            var message = new ServiceBusMessage(text);
            if (messageBatch.TryAddMessage(message) is false)
            {
                throw new InvalidOperationException("The message is too large to fit in the batch.");
            }
        }
        
        await sender.SendMessagesAsync(messageBatch);
    }
}