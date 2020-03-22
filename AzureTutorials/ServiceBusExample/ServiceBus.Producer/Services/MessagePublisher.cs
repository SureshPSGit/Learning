using System.Text;
using System.Threading.Tasks;
using Microsoft.Azure.ServiceBus;
using Newtonsoft.Json;

namespace ServiceBus.Producer.Services
{
    public class MessagePublisher : IMessagePublisher
    {
        private readonly ITopicClient _topicClient;

        public MessagePublisher(ITopicClient topicClient)
        {
            _topicClient = topicClient;
        }

        public Task Publish<T>(T obj)
        {
            var objAsText = JsonConvert.SerializeObject(obj);
            var message = new Message(Encoding.UTF8.GetBytes(objAsText));
            message.UserProperties["messageType"] = typeof(T).Name;
            return _topicClient.SendAsync(message);
        }

        public Task Publish(string raw)
        {
            var message = new Message(Encoding.UTF8.GetBytes(raw));
            message.UserProperties["messageType"] = "Raw";
            return _topicClient.SendAsync(message);
        }
    }
}