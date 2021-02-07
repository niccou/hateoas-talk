namespace WebApi.Models.Shared
{
    public record ApiResponse : RestModel
    {
        private ApiResponse() { }

        public static ApiResponse Create() => new ApiResponse();
    }

    public record ApiResponse<TResult> : ApiResponse
    {
        private ApiResponse(ApiResponse original) : base(original) { }

        public TResult? Result { get; init; }

        public static ApiResponse<TResult> Create(TResult result) =>
            new ApiResponse<TResult>(Create())
            {
                Result = result
            };
    }
}
