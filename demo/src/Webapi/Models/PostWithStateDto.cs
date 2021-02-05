namespace WebApi.Models
{
    public record PostWithStateDto : PostDto
    {
        public string State { get; init; } = "";
    }
}
