using System;
using System.Collections.Generic;
using System.Linq;
using BenchmarkDotNet.Attributes;
using BenchmarkDotNet.Running;

namespace AnyCountAndLinq
{
    class Program
    {
        static void Main(string[] args)
        {
            BenchmarkRunner.Run<Bench>();
        }
    }
    
    public class ToTest
    {
        private List<Guid> List { get; } = new List<Guid>(Enumerable.Range(0, 10000).Select(x=> Guid.NewGuid()));

        public IEnumerable<Guid> ListDate()
        {
            foreach (var item in List)
            {
                yield return item;
            }
        }
    }
    
    public class Bench
    {
        private static readonly ToTest ToTest = new ToTest();
        
        [Benchmark]
        public bool TestAny() => ToTest.ListDate().Any();
        
        [Benchmark]
        public bool TestCount() => ToTest.ListDate().Count() > 0;
    }
}