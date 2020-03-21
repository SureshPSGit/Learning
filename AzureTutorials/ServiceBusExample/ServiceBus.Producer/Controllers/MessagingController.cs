using System.IO;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using ServiceBus.Contracts;
using ServiceBus.Producer.Services;

namespace ServiceBus.Producer.Controllers
{
    public class MessagingController : ControllerBase
    {
        private readonly IMessagePublisher _messagePublisher;
        
        public MessagingController(IMessagePublisher messagePublisher)
        {
            _messagePublisher = messagePublisher;
        }

        [HttpPost("publish/text")]
        public async Task<IActionResult> PublishText()
        {
            using var reader = new StreamReader(Request.Body);
            var bodyAsText = await reader.ReadToEndAsync();
            await _messagePublisher.Publish(bodyAsText);
            return Ok();
        }
        
        [HttpPost("publish/customer")]
        public async Task<IActionResult> PublishCustomer([FromBody] Customer customer)
        {
            await _messagePublisher.Publish(customer);
            return Ok();
        }
    }
}