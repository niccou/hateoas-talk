using WebApi.Core.Shared;

namespace WebApi.Core.Blog
{
    public interface IPublishPost
    {
        OperationResult Publish(string id);
        OperationResult Unpublish(string id);
    }
}
