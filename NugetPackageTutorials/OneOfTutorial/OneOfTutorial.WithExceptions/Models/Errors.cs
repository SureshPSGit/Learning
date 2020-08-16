namespace OneOfTutorial.WithExceptions.Models
{
    public static class Errors
    {
        public static readonly Error EmailAlreadyExistsError = new Error("EmailExists", "There is already an account with this email");

        public static readonly Error NotValidEmail = new Error("InvalidEmail", "The email provided does not have the right format");
    }
}
