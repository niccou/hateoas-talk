using System.Collections.Generic;

namespace Front.Models
{
    public record ModelWithActions
    {
        public IReadOnlyCollection<Link> Links { get; init; } = new List<Link>();
    }
}
