using System;
using WebApi.Core.Shared;

namespace WebApi.Core.Services
{
    public interface IPublishPost
    {
        OperationResult Publish(string id);
        OperationResult Unpublish(string id);
    }
}
