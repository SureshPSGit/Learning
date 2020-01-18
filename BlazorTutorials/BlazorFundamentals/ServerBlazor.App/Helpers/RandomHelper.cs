using System;
using System.Threading.Tasks;
using Microsoft.JSInterop;

namespace ServerBlazor.Helpers
{
    public class RandomHelper
    {
        [JSInvokable]
        public Task<int> GenerateRandomInt(int maxValue)
        {
            return Task.FromResult(new Random().Next(maxValue));
        }
    }
}