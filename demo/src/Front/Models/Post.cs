namespace Front.Models
{
    public record Post : ModelWithActions
    {
        public string Title { get; init; } = "";
        public string Author { get; init; } = "";
    }
}
