using WebApi.Models.Shared;

namespace WebApi.Models
{
    public record PostSummaryDto : RestModel
    {
        public string Title { get; init; } = "";
        public string Author { get; init; } = "";
    }
}
