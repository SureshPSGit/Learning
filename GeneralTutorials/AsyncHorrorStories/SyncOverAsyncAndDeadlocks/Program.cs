﻿using System;
using System.Threading.Tasks;

namespace SyncOverAsyncAndDeadlocks
{
    class Program
    {
        static async Task Main(string[] args)
        {
            var service = new SomeService();

            var number = await service.GetValueAsync();

            Console.WriteLine($"The magic number is: {number}");
        }
    }
}
