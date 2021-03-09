using WebApi.Core.Models;

namespace WebApi.Models
{
    public record PostDetailDto : PostSummaryDto
    {
        public string State { get; init; } = "";
        public string Content { get; init; } = "";
    }
}