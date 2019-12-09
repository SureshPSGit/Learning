using System;

namespace ScrutorExample.Responses
{
    public class ProductResponse
    {
        public Guid Id { get; set; }

        public string Name { get; set; }
        
        public decimal Price { get; set; }

        public DateTime ReleaseDate { get; set; }
    }
}