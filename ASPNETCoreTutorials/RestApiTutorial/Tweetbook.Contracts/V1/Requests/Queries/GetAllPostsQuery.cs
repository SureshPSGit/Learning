using Microsoft.AspNetCore.Mvc;

namespace Tweetbook.Contracts.V1.Requests.Queries
{
    public class GetAllPostsQuery
    {
        [FromQuery(Name = "userId")]
        public string UserId { get; set; }
    }
}