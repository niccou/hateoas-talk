using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Front.Models
{
    public static class LinkExtensions
    {
        public static bool CanPublish(this IEnumerable<Link> links)
            => links.PublishPost() is not null;

        public static bool CanUnpublish(this IEnumerable<Link> links)
            => links.UnpublishPost() is not null;

        public static Link? PublishPost(this IEnumerable<Link> links)
            => links.SingleOrDefault(_ => _.Rel == "publish");

        public static Link? UnpublishPost(this IEnumerable<Link> links)
            => links.SingleOrDefault(_ => _.Rel == "unpublish");
    }
}