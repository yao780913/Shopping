namespace Shopping.Infrastructure.Messaging;

public class AzureServiceBusSettings
{
    public static string Section => "AzureServiceBusSettings";
    public string ConnectionString { get; set; }
    public string QueueName { get; set; }
    public string TopicName { get; set; }
}