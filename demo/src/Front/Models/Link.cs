namespace Front.Models
{
    public record Link
    {
        public string Href { get; init; } = "";
        public string Type { get; init; } = "";
        public string Rel { get; init; } = "";
    }
}
