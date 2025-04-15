using Azure.Messaging.EventHubs;
using Azure.Messaging.EventHubs.Producer;
using System.Text;

public class EventHubService
{
    private readonly string _connectionString = "Endpoint=sb://esehsg5wmsjx27mmunb0ez.servicebus.windows.net/;SharedAccessKeyName=key_544b8814-e29a-4dd4-907b-d17f19001a33;SharedAccessKey=NhlMLDLnpNFVoZfibX3k69KmXxEn11ceT+AEhH0ZNK8=;EntityPath=es_3ac4f070-2e2e-467a-b247-8927b54fb4cd";

    public async Task SendEventAsync(string message)
    {
        await using var producerClient = new EventHubProducerClient(_connectionString);

        using EventDataBatch eventBatch = await producerClient.CreateBatchAsync();
        if (!eventBatch.TryAdd(new EventData(Encoding.UTF8.GetBytes(message))))
        {
            throw new Exception("Event is too large to fit in the batch.");
        }

        await producerClient.SendAsync(eventBatch);
    }
}
