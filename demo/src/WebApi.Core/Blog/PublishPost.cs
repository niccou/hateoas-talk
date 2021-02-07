using System;
using WebApi.Core.Shared;

namespace WebApi.Core.Blog
{
    internal class PublishPost : IPublishPost
    {
        private readonly Services.IPublishPost _publisher;

        public PublishPost(Services.IPublishPost publisher)
        {
            _publisher = publisher;
        }

        public OperationResult Publish(string id) => _publisher.Publish(id);

        public OperationResult Unpublish(string id) => _publisher.Unpublish(id);
    }
}
