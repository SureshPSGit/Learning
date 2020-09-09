using System;
using System.Threading.Tasks;

namespace OnceAsyncAlwaysAsync
{
    class Program
    {
        static async Task Main(string[] args)
        {
            var repository = new SomeRepository();
            var number = await repository.GetValueAsync();
            Console.WriteLine($"The number is {number}");
        }
    }
}
