using Microsoft.AspNetCore.Authorization;

namespace ServerBlazor.Authorization
{
    public class EmailRequirement : IAuthorizationRequirement
    {
        public string EmailSuffix { get; }

        public EmailRequirement(string emailSuffix)
        {
            EmailSuffix = emailSuffix;
        }
    }
}