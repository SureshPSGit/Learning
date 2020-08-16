using System;

namespace OneOfTutorial.WithOneOf.Models
{
    public class User
    {
        public Guid Id { get; set; } = Guid.NewGuid();

        public string Email { get; set; }

        public string FullName { get; set; }
    }
}
