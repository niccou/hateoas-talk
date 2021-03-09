using System.Collections.Generic;
using System.Linq;

namespace Front.Models
{
    public record ModelWithActions
    {
        private const string Detail = "detail";

        public IReadOnlyCollection<Link> Links { get; init; } = new List<Link>();

        public bool HasDetail => Links.Any(link => link.Rel == Detail);

        public Link DetailLink => Links.SingleOrDefault(link => link.Rel == Detail) ?? new Link();
    }
}