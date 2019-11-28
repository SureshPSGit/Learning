using System.Linq;

namespace Tweetbook.Domain
{
    public class PaginationFilter
    {
        public int PageNumber { get; set; }

        public int PageSize { get; set; }
    }
}