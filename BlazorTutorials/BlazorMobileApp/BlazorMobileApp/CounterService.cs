using System;

namespace BlazorMobileApp
{
    public class CounterService
    {
        public int Increment(int counter)
        {
            return counter + new Random().Next(1, 5);
        }
    }
}