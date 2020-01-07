using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.Azure.ServiceBus;
using Microsoft.Extensions.Hosting;
using Newtonsoft.Json;

namespace Microservice.Console
{
    public class ServiceBusConsumer : BackgroundService
    {
        private readonly IQueueClient _queueClient;

        public ServiceBusConsumer(IQueueClient queueClient)
        {
            _queueClient = queueClient;
        }

        protected override Task ExecuteAsync(CancellationToken stoppingToken)
        {
            RegisterOnMessageHandlerAndReceiveMessages();
            return Task.CompletedTask;
        }
        
        void RegisterOnMessageHandlerAndReceiveMessages()
        {
            // Configure the MessageHandler Options in terms of exception handling, number of concurrent messages to deliver etc.
            var messageHandlerOptions = new MessageHandlerOptions(ExceptionReceivedHandler)
            {
                // Maximum number of Concurrent calls to the callback `ProcessMessagesAsync`, set to 1 for simplicity.
                // Set it according to how many messages the application wants to process in parallel.
                MaxConcurrentCalls = 1,

                // Indicates whether MessagePump should automatically complete the messages after returning from User Callback.
                // False below indicates the Complete will be handled by the User Callback as in `ProcessMessagesAsync` below.
                AutoComplete = false
            };
            
            _queueClient.RegisterMessageHandler(ProcessMessagesAsync, messageHandlerOptions);
        }

        async Task ProcessMessagesAsync(Message message, CancellationToken token)
        {
            System.Console.WriteLine($"Received message: SequenceNumber:{message.SystemProperties.SequenceNumber} Body:{Encoding.UTF8.GetString(message.Body)}");

            //Map to your own object here and add your business logic
            var obj = JsonConvert.DeserializeObject(Encoding.UTF8.GetString(message.Body));
            
            await _queueClient.CompleteAsync(message.SystemProperties.LockToken);
        }

        Task ExceptionReceivedHandler(ExceptionReceivedEventArgs exceptionReceivedEventArgs)
        {
            System.Console.WriteLine($"Message handler encountered an exception {exceptionReceivedEventArgs.Exception}.");
            var context = exceptionReceivedEventArgs.ExceptionReceivedContext;
            System.Console.WriteLine("Exception context for troubleshooting:");
            System.Console.WriteLine($"- Endpoint: {context.Endpoint}");
            System.Console.WriteLine($"- Entity Path: {context.EntityPath}");
            System.Console.WriteLine($"- Executing Action: {context.Action}");
            return Task.CompletedTask;
        }
    }
}