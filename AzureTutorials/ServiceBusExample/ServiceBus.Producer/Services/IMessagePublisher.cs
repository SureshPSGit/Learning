using System.Threading.Tasks;
using ServiceBus.Contracts;

namespace ServiceBus.Producer.Services
{
    public interface IMessagePublisher
    {
        Task Publish<T>(T obj);
        
        Task Publish(string raw);
    }
}