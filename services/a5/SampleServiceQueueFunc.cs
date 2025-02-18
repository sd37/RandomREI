using System;
using System.Threading.Tasks;
using Azure.Messaging.ServiceBus;
using Microsoft.Azure.Functions.Worker;
using Microsoft.Extensions.Logging;

namespace a5
{
    public class SampleServiceQueueFunc
    {
        private readonly ILogger<SampleServiceQueueFunc> _logger;

        public SampleServiceQueueFunc(ILogger<SampleServiceQueueFunc> logger)
        {
            _logger = logger;
        }

        [Function(nameof(SampleServiceQueueFunc))]
        public async Task Run(
            [ServiceBusTrigger("sample", Connection = "samplequeueconnstr")]
            ServiceBusReceivedMessage message,
            ServiceBusMessageActions messageActions)
        {
            _logger.LogInformation("Message ID: {id}", message.MessageId);
            _logger.LogInformation("Message Body: {body}", message.Body);
            _logger.LogInformation("Message Content-Type: {contentType}", message.ContentType);

            // Complete the message
            await messageActions.CompleteMessageAsync(message);
        }
    }
}
