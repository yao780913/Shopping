namespace Shopping.Application.Common.Interfaces;

public interface IMessagingService
{
    public Task SendMessageAsync(string queueOrTopicName, string context);
    public Task SendMessagesAsync(string queueOrTopicName, List<string> contexts);
    
}