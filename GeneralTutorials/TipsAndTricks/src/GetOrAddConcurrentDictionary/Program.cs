using System;
using System.Collections.Concurrent;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace GetOrAddConcurrentDictionary
{
    class Program
    {
        static readonly ConcurrentDictionary<string, string> Dictionary = new ConcurrentDictionary<string, string>();
        
        static async Task Main(string[] args)
        {
            
            var firstCallTask = Task.Run(() => AddAndPrint("First call"));
            var secondCallTask = Task.Run(() => AddAndPrint("Second call"));
            
            await Task.WhenAll(firstCallTask, secondCallTask);
            
            AddAndPrint("Third call");
        }

        private static void AddAndPrint(string callText)
        {
            var callValue = Dictionary.GetOrAdd("somekey", x =>
            {
                return callText;
            });
            Console.WriteLine(callValue);
        }
    }
}