using System;
using System.Threading;
using System.Threading.Tasks;

namespace AsyncActionsAreNotAwaited
{
    class Program
    {
        static async Task Main(string[] args)
        {
            await SomeMethodThatAcceptsDelegate(async () =>
            {
                await Task.Delay(1000);
                Console.WriteLine("Test");
            });
        }

        private static async Task SomeMethodThatAcceptsDelegate(Action content)
        {
            await Task.Delay(1);
            content();
        }
    }
}