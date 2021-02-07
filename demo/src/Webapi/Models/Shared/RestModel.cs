using System.Collections.Generic;

namespace WebApi.Models.Shared
{
    public record RestModel
    {
        private readonly List<Link> _links = new List<Link>();

        public IReadOnlyCollection<Link> Links => _links;

        public void Add(Link link)
        {
            if (link == new Link())
            {
                return;
            }

            _links.Add(link);
        }
    }
}
