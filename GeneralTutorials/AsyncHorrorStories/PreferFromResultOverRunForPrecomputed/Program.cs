using System;
using System.Threading.Tasks;

namespace PreferFromResultOverRunForPrecomputed
{
    class Program
    {
        static async Task Main(string[] args)
        {
            var service = new SomeService();

            var number = await service.GetValueAsync(10);

            Console.WriteLine($"The number is {number}");
        }
    }
}
