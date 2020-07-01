using System;
using System.Collections.Concurrent;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace GetOrAddConcurrentDictionary
{
    class Program
    {
        private static int _visitorCount = 0;
        static readonly ConcurrentDictionary<string, Lazy<string>> Dictionary = new ConcurrentDictionary<string, Lazy<string>>();
        
        static async Task Main(string[] args)
        {
            var firstCallTask = Task.Run(() => AddAndPrint("First call"));
            var secondCallTask = Task.Run(() => AddAndPrint("Second call"));
            
            await Task.WhenAll(firstCallTask, secondCallTask);
            
            AddAndPrint("Third call");
            Console.WriteLine($"Called {_visitorCount} times");
        }

        private static void AddAndPrint(string callText)
        {
            var callValue = Dictionary.GetOrAdd("somekey", x =>
                new Lazy<string>(() =>
                {
                    Interlocked.Increment(ref _visitorCount);
                    return callText;
                })
            );
            Console.WriteLine(callValue.Value);
        }
    }
}