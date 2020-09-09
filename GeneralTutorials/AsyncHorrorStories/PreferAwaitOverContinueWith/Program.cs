using System;
using System.Threading.Tasks;

namespace PreferAwaitOverContinueWith
{
    class Program
    {
        static async Task Main(string[] args)
        {
            var service = new SomeService();
            var number = await service.GetValueAsync();
            var finalNumber = number + 2;
            Console.WriteLine($"The magic number is: {finalNumber}");
        }
    }
}
