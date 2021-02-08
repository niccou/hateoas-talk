namespace Front.Models
{
    public record Response<T> : ModelWithActions
    {
        public T? Result { get; set; }
    }
}
