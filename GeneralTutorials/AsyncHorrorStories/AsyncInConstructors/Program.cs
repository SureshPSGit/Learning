using System;
using System.Threading.Tasks;

namespace AsyncInConstructors
{
    class Program
    {
        static async Task Main(string[] args)
        {
            var connectionFactory = new ConnectionFactory();
            var someService = await SomeService.CreateAsync(connectionFactory);

            Console.WriteLine("Hello World!");
        }
    }
}
