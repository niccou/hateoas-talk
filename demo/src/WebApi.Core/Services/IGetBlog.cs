using WebApi.Core.Shared;

namespace WebApi.Core.Services
{
    public interface IGetBlog
    {
        OperationResult<Models.Blog> Get();
    }
}
