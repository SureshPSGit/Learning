using System;

namespace ServerBlazor.Services
{
    public class RandomService
    {
        public Guid RandomId { get; } = Guid.NewGuid();
    }
}