namespace GettersAndAutoProperties
{
    public class Employee
    {
        public Employee(string firstName, string lastName)
        {
            FirstName = firstName;
            LastName = lastName;
            FullName = $"{FirstName} {LastName}";
        }
        
        public string FirstName { get; }

        public string LastName { get; }

        public string FullName { get; }
    }
}